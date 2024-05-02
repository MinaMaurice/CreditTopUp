using Application.DTOs;
using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITransactionService
    {
        Task<TopUpResult> TopUpAsync(int userId, int beneficiaryId, decimal amount);
        Task<List<TransactionDTO>> GetTransactionsByUserIdAsync(int userId);

    }
}
