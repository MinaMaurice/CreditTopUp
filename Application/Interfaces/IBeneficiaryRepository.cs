using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBeneficiaryRepository
    {
        Task<List<BeneficiaryDTO>> GetBeneficiariesAsync(int userId);
        Task<int> AddBeneficiaryAsync(int userId, string nickname);
        Task<int> GetBeneficiaryCountAsync(int userId);
        Task<bool> DoesBeneficiaryExistAsync(int userId, int beneficiaryId);

    }
}
