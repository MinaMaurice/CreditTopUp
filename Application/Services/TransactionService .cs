using Application.DTOs;
using Application.Enums;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserService _userService;
        private readonly IHttpBalanceService _httpBalanceService;
        private readonly IOptionService _optionService;
        private readonly IBeneficiaryRepository _beneficiaryRepository;

        public TransactionService(ITransactionRepository transactionRepository, IUserService userService, 
            IHttpBalanceService httpBalanceService, IOptionService optionService, IBeneficiaryRepository beneficiaryRepository)
        {
            _transactionRepository = transactionRepository;
            _userService = userService;
            _httpBalanceService = httpBalanceService;
            _optionService = optionService;
            _beneficiaryRepository = beneficiaryRepository;
        }

        public async Task<TopUpResult> TopUpAsync(int userId, int beneficiaryId, decimal amount)
        {
            // Retrieve user information
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return TopUpResult.UserNotFound;
            }

            // Retrieve Option Id 
            var optionId = await _optionService.GetOptionIdByAmountAsync(amount);
            if (optionId == null)
            {
                return TopUpResult.OptionNotFound;
            }

            // check Beneficiary 
            var beneficiary = await _beneficiaryRepository.DoesBeneficiaryExistAsync(userId,beneficiaryId);
            if (!beneficiary)
            {
                return TopUpResult.BeneficiaryNotFound;
            }

            // Check if the user is verified
            bool isVerified = user.IsVerified;

            // Retrieve user's balance from external HTTP service
            decimal balance = await _httpBalanceService.GetBalanceAsync(userId);

            // Check if the amount to top-up is less than or equal to the user's balance
            if (amount > balance)
            {
                return TopUpResult.InsufficientBalance;
            }

            decimal totalAmount = amount + 1; // AED 1 charge for every top-up transaction

            // Check if the user has reached the maximum monthly top-up limit per beneficiary
            decimal totalMonthlyTopUp = await _transactionRepository.GetTotalMonthlyTopUpPerBeneficiaryAsync(userId, beneficiaryId);
            decimal maxTopUpPerMonth = isVerified ? 500 : 1000; 

            if (totalMonthlyTopUp + totalAmount > maxTopUpPerMonth)
            {
                return TopUpResult.MaxTopUpPerMonthExceeded;
            }

            // Check if the user has reached the maximum monthly top-up limit for all beneficiaries
            decimal totalMonthlyTopUpAll = await _transactionRepository.GetTotalMonthlyTopUpAsync(userId);
            decimal maxTotalTopUpPerMonth = 3000;

            if (totalMonthlyTopUpAll + totalAmount > maxTotalTopUpPerMonth)
            {
                return TopUpResult.MaxTotalTopUpPerMonthExceeded;
            }

            // Deduct the amount from the user's balance
            bool deducted = await _httpBalanceService.DeductBalanceAsync(userId, totalAmount);
            if (!deducted)
            {
                return TopUpResult.InsufficientBalance;
            }

            var transactionDto = new TransactionDTO
            {
                UserId = userId,
                BeneficiaryId = beneficiaryId,
                TransactionAmount = amount,
                OptionId = (int)optionId
            };
            await _transactionRepository.AddTransactionAsync(transactionDto);

            return TopUpResult.Success;
        }
        public async Task<List<TransactionDTO>> GetTransactionsByUserIdAsync(int userId)
        {

          return await _transactionRepository.GetTransactionsByUserIdAsync(userId);
        }
    }

}
