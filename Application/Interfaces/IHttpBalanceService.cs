using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHttpBalanceService
    {
        Task<decimal> GetBalanceAsync(int userId);
        Task<bool> DeductBalanceAsync(int userId, decimal amount);
    }
}
