using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
            private readonly AppDbContext _context;

            public UserRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<UserDTO> GetUserByIdAsync(int userId)
            {
                var user = await _context.Users.FindAsync(userId);

                if (user == null)
                {
                    return null; // User not found
                }

                var userDto = new UserDTO
                {
                    Id = user.UserID,
                    Username = user.UserName,
                    Balance = user.Balance,
                    IsVerified = user.VerificationStatus
                };

                return userDto;
            }

            public async Task<bool> IsUserVerifiedAsync(int userId)
            {
                var user = await _context.Users.FindAsync(userId);

                if (user == null)
                {
                    throw new InvalidOperationException($"User with ID {userId} not found.");
                }

                return user.VerificationStatus;
            }
            public async Task<bool> DeductBalanceAsync(int userId, decimal amount)
            {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false; // User not found
            }

            if (user.Balance < amount)
            {
                return false; 
            }

            user.Balance -= amount;

            try
            {
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

}

