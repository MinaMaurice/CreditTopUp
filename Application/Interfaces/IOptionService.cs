using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOptionService
    {
        Task<List<TopUpOptionDTO>> GetAllOptionsAsync();
        Task<int?> GetOptionIdByAmountAsync(decimal amount);

    }
}
