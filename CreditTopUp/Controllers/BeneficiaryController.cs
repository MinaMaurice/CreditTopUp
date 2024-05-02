using Application.Interfaces;
using CreditTopUp.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CreditTopUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly IBeneficiaryService _beneficiaryService;

        public BeneficiaryController(IBeneficiaryService beneficiaryService)
        {
            _beneficiaryService = beneficiaryService;
        }
        
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBeneficiaries(int userId)
        {
            var beneficiaries = await _beneficiaryService.GetBeneficiariesAsync(userId);
            return Ok(beneficiaries);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AddBeneficiary(int userId, [FromBody] BeneficiaryAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _beneficiaryService.AddBeneficiaryAsync(userId, request.Nickname);
            if (success)
            {
                return Ok("Beneficiary added successfully.");
            }
            else
            {
                return BadRequest("Failed to add beneficiary. Maximum limit reached.");
            }
        }
    }
}
