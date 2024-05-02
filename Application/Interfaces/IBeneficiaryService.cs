using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBeneficiaryService
    {
        Task<bool> CanAddBeneficiaryAsync(int userId);
        Task<bool> AddBeneficiaryAsync(int userId, string nickname);
        Task<List<BeneficiaryDTO>> GetBeneficiariesAsync(int userId);
        Task<bool> DoesBeneficiaryExistAsync(int userId, int beneficiaryId);

    }
}
