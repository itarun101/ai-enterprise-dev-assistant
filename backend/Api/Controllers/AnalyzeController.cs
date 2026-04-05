
using Microsoft.AspNetCore.Mvc;
using Api.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyzeController : ControllerBase
    {
        private readonly AIService _aiService;

        public AnalyzeController(AIService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost]
        public async Task<IActionResult> Analyze([FromBody] string input)
        {
            if (string.IsNullOrEmpty(input))
                return BadRequest("Input cannot be empty");

            var result = await _aiService.AnalyzeInputAsync(input);

            return Ok(result);
        }
    }
}
