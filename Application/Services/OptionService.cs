using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _optionRepository;

        public OptionService(IOptionRepository optionRepository)
        {
            _optionRepository = optionRepository;
        }

        public async Task<List<TopUpOptionDTO>> GetAllOptionsAsync()
        {
            return await _optionRepository.GetTopUpOptionsAsync();
        }

        public async Task<int?> GetOptionIdByAmountAsync(decimal amount)
        {
            return await _optionRepository.GetOptionIdByAmountAsync(amount);
        }

    }
}
