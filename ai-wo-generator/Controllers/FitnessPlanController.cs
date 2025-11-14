using ai_wo_generator.Services;
using Microsoft.AspNetCore.Mvc;

namespace ai_wo_generator.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FitnessPlanController(IFitnessPlanService fitnessPlanService) : ControllerBase
    {
        public readonly IFitnessPlanService _fitnessPlanService = fitnessPlanService;

        [HttpGet("plan")]
        public async Task<IActionResult> GetFitnessPlan()
        {
            string userPrompt = "Create one day workout plan for a 30 years old male in less than 100 words.";
            var result = await _fitnessPlanService.GetFitnessPlan(userPrompt);
            return Ok(result);
        }
    }
}
