using Application.DTOs;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class OptionRepository : IOptionRepository
    {
        private readonly AppDbContext _context;

        public OptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TopUpOptionDTO>> GetTopUpOptionsAsync()
        {
            var topUpOptions = await _context.Options
                .Select(option => new TopUpOptionDTO
                {
                    Id = option.OptionID,
                    Amount = option.Amount,
                })
                .ToListAsync();

            return topUpOptions;
        }

        public async Task<int?> GetOptionIdByAmountAsync(decimal amount)
        {
            var optionId = await _context.Options
                .Where(option => option.Amount == amount)
                .Select(option => (int?)option.OptionID)
                .FirstOrDefaultAsync();

            return optionId;
        }
    }
}
