using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOptionRepository
    {
        Task<List<TopUpOptionDTO>> GetTopUpOptionsAsync();
        Task<int?> GetOptionIdByAmountAsync(decimal amount);
    }
}
