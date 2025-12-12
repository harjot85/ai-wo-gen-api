using ai_wo_generator.DTOs;
using ai_wo_generator.Services.FitnessPlanService;
using Microsoft.AspNetCore.Mvc;

namespace ai_wo_generator.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class FitnessPlanController(IFitnessPlanService fitnessPlanService) : ControllerBase
    {
        public readonly IFitnessPlanService _fitnessPlanService = fitnessPlanService;

        [HttpPost("generate")]
        public async Task<IActionResult> GetFitnessPlan([FromBody] UserFitnessPlanParameters fitnessPlanGenerateRequest)
        {
            if (fitnessPlanGenerateRequest == null)
            {
                return BadRequest("Required data missing");
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
