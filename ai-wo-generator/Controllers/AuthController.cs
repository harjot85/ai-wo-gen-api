using ai_wo_generator.DTOs.Authentication;
using ai_wo_generator.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace ai_wo_generator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserService userService, ILogger<AuthController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest loginRequest)
        {
            _logger.LogInformation("Login attempt for email: {Email}", loginRequest?.Email);

            try
            {
                if (loginRequest == null)
                {
                    return Unauthorized("Login credentials missing");
                }

                var userId = await _userService.LoginAsync(loginRequest);

                if (userId == -1)
                {
                    return Unauthorized("Invalid email or password");
                }

                return Ok(new { userId });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
