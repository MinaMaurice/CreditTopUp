using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<TransactionDTO>> GetTransactionsByUserIdAsync(int userId);
        Task AddTransactionAsync(TransactionDTO transaction);
        Task<decimal> GetTotalMonthlyTopUpPerBeneficiaryAsync(int userId, int beneficiaryId);
        Task<decimal> GetTotalMonthlyTopUpAsync(int userId);
    }
}
