using Application.DTOs;
using Application.Interfaces;
using CreditTopUp.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Application.Enums;

namespace CreditTopUp.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("topup")]
        public async Task<IActionResult> AddTopUpTransaction(TransactionRequest request)
        {

            if (request == null || request.UserId <= 0 || request.BeneficiaryId <= 0 || request.Amount <= 0)
            {
                return BadRequest("Invalid transaction request.");
            }

            // Add the top-up transaction
            var result = await _transactionService.TopUpAsync(request.UserId,request.BeneficiaryId,request.Amount);

            if (result == TopUpResult.Success)
            {
                return Ok("Top-up transaction added successfully.");
            }
            else
            {
                return BadRequest($"Failed to add top-up transaction: {result}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTransactionsByUserId(int userId)
        {
            // Perform validation if needed
            if (userId <= 0)
            {
                return BadRequest("Invalid user ID.");
            }

            // Get all transactions for the specified user ID
            var transactions = await _transactionService.GetTransactionsByUserIdAsync(userId);

            if (transactions != null)
            {
                return Ok(transactions);
            }
            else
            {
                return NotFound($"No transactions found for user with ID: {userId}");
            }
        }
    }
}
