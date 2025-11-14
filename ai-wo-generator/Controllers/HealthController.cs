using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ai_wo_generator.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("health")]
        public IActionResult GetHealthStatus()
        {
            return Ok(new { status = "Healthy" });
        }
    }
}
