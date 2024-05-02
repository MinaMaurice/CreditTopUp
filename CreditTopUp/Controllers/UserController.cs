using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditTopUp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{userId}/balance")]
        public async Task<ActionResult<decimal>> GetUserBalance(int userId)
        {
            // Retrieve the user from the repository
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound(); // User not found
            }

            // Return the user's balance in the response
            return Ok(user.Balance);
        }

        [HttpPost("{userId}/deduct-balance")]
        public async Task<ActionResult> DeductBalance(int userId, [FromQuery] decimal amount)
        {
            bool deducted = await _userRepository.DeductBalanceAsync(userId, amount);

            if (deducted)
            {
                return Ok(); // Deduction successful
            }
            else
            {
                return BadRequest("Failed to deduct balance."); // Deduction failed
            }
        }
    }
}
