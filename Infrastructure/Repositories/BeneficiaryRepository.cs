using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly AppDbContext _context;

        public BeneficiaryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BeneficiaryDTO>> GetBeneficiariesAsync(int userId)
        {
            var beneficiaries = await _context.Beneficiaries
                .Where(b => b.UserID == userId)
                .Select(b => new BeneficiaryDTO
                {
                    Id = b.BeneficiaryID,
                    Nickname = b.Nickname,
                })
                .ToListAsync();

            return beneficiaries;
        }
        public async Task<int> AddBeneficiaryAsync(int userId, string nickname)
        {
            var beneficiary = new Beneficiary
            {
                UserID = userId,
                Nickname = nickname,
                // Set other properties as needed
            };

            _context.Beneficiaries.Add(beneficiary);
            await _context.SaveChangesAsync();

            return beneficiary.BeneficiaryID;
        }
        public async Task<int> GetBeneficiaryCountAsync(int userId)
        {
            var beneficiaryCount = await _context.Beneficiaries
                .Where(b => b.UserID == userId)
                .CountAsync();

            return beneficiaryCount;
        }

        public async Task<bool> DoesBeneficiaryExistAsync(int userId, int beneficiaryId)
        {
            return await _context.Beneficiaries
                .AnyAsync(b => b.UserID == userId && b.BeneficiaryID == beneficiaryId);
        }

    }
}
