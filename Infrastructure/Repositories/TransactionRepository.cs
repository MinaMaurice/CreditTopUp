using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransactionDTO>> GetTransactionsByUserIdAsync(int userId)
        {
            return await _context.Transactions
                .Where(t => t.UserID == userId)
                .Select(t => new TransactionDTO
                {
                    // Map entity properties to DTO properties
                    Id = t.TransactionID,
                    UserId = t.UserID,
                    BeneficiaryId = t.BeneficiaryID,
                    OptionId = t.OptionID,
                    TransactionAmount = t.TransactionAmount,
                    TransactionDate = t.TransactionDate
                })
                .ToListAsync();
        }
        public async Task AddTransactionAsync(TransactionDTO transaction)
        {
            var newTransaction = new Transaction
            {
                UserID = transaction.UserId,
                BeneficiaryID = transaction.BeneficiaryId,
                OptionID = transaction.OptionId,
                TransactionAmount = transaction.TransactionAmount,
                TransactionDate = DateTime.UtcNow
            };

            _context.Transactions.Add(newTransaction);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetTotalMonthlyTopUpPerBeneficiaryAsync(int userId, int beneficiaryId)
        {
            // Get the total monthly top-up amount for the specified beneficiary
            var totalTopUp = await _context.Transactions
                .Where(t => t.UserID == userId && t.BeneficiaryID == beneficiaryId &&
                            t.TransactionDate.Year == DateTime.UtcNow.Year &&
                            t.TransactionDate.Month == DateTime.UtcNow.Month)
                .SumAsync(t => t.TransactionAmount);

            return totalTopUp;
        }

        public async Task<decimal> GetTotalMonthlyTopUpAsync(int userId)
        {
            // Get the total monthly top-up amount for the specified user
            var totalTopUp = await _context.Transactions
                .Where(t => t.UserID == userId &&
                            t.TransactionDate.Year == DateTime.UtcNow.Year &&
                            t.TransactionDate.Month == DateTime.UtcNow.Month)
                .SumAsync(t => t.TransactionAmount);

            return totalTopUp;
        }
    }
}
