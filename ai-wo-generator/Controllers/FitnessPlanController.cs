using ai_wo_generator.Models;
using ai_wo_generator.Services;
using Microsoft.AspNetCore.Mvc;

namespace ai_wo_generator.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FitnessPlanController(IFitnessPlanService fitnessPlanService) : ControllerBase
    {
        public readonly IFitnessPlanService _fitnessPlanService = fitnessPlanService;

        [HttpPost("plan/generate")]
        public async Task<IActionResult> GetFitnessPlan([FromBody] FitnessPlanGenerate fitnessPlanGenerateRequest)
        {
            if (fitnessPlanGenerateRequest == null)
            {

                // temporary
                string userPrompt = "Create one day workout plan for a 30 years old male in less than 100 words.";

                fitnessPlanGenerateRequest = new FitnessPlanGenerate()
                {
                    Goal = userPrompt,
                    Preference = "Include the exercises easy on the shoulders.",
                };
            }

            var result = await _fitnessPlanService.GetFitnessPlan(fitnessPlanGenerateRequest);
            return Ok(result);
        }

        [HttpPost("plan/save")]
        public async Task<IActionResult> SaveFitnessPlan([FromBody] FitnessPlanSave fitnessPlan)
        {
            if (fitnessPlan == null)
            {
                return BadRequest("Required data missing");
            }

            // Service call to Insert/Update Fitness plan

            return Created();
        }
    }
}
