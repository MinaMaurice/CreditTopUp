using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CreditTopUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly IOptionService _optionService;

        public OptionsController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOptions()
        {
            var options = await _optionService.GetAllOptionsAsync();
            return Ok(options);
        }
    }
}
