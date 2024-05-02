using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BeneficiaryService : IBeneficiaryService
    {
        private readonly IBeneficiaryRepository _beneficiaryRepository;

        public BeneficiaryService(IBeneficiaryRepository beneficiaryRepository)
        {
            _beneficiaryRepository = beneficiaryRepository;
        }

        public async Task<bool> CanAddBeneficiaryAsync(int userId)
        {
            var beneficiaryCount = await _beneficiaryRepository.GetBeneficiaryCountAsync(userId);
            return beneficiaryCount < 5;
        }
        public async Task<bool> AddBeneficiaryAsync(int userId, string nickname)
        {
            var canAddBeneficiary = await CanAddBeneficiaryAsync(userId);
            if (!canAddBeneficiary)
            {
                return false; 
            }

            await _beneficiaryRepository.AddBeneficiaryAsync(userId, nickname);
            return true;
        }

        public async Task<List<BeneficiaryDTO>> GetBeneficiariesAsync(int userId)
        {
            return await _beneficiaryRepository.GetBeneficiariesAsync(userId);
        }

        public async Task<bool> DoesBeneficiaryExistAsync(int userId, int beneficiaryId)
        {
            return await _beneficiaryRepository.DoesBeneficiaryExistAsync(userId, beneficiaryId);
        }
    }
}
