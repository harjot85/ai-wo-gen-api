using ai_wo_generator.DTOs.Authentication;
using ai_wo_generator.DTOs.UserProfile;
using ai_wo_generator.Services.UserService;
using ai_wo_generator.Services.UserStats;
using Microsoft.AspNetCore.Mvc;

namespace ai_wo_generator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController(IUserService userService, IUserStatisticsService userStatisticsService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IUserStatisticsService _userStatisticsService = userStatisticsService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterationRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request data");
                }
                var userId = await _userService.RegisterAsync(request);

                return CreatedAtAction(nameof(Register), new { id = userId }, null);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}/profile")]
        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
                var user = await _userService.GetUserAsync(userId);
                if (user == null)
                {
                    return NotFound("User not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("profile/insert")]
        public async Task<IActionResult> Insert([FromBody] UserStatisticsCreateDto request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request data");
                }
                var userId = await _userStatisticsService.InsertAsync(request);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
