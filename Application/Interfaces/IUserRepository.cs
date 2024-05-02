using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDTO> GetUserByIdAsync(int userId);
        Task<bool> IsUserVerifiedAsync(int userId);
        Task<bool> DeductBalanceAsync(int userId, decimal amount);
    }
}
