using ai_wo_generator.DTOs.Authentication;
using ai_wo_generator.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace ai_wo_generator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
           _authService = authService;
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

                var result = await _authService.LoginAsync(loginRequest);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterationRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request data");
                }
                
                var user = await _authService.RegisterAsync(request);

                if (user == null)
                {
                    return BadRequest("User registration failed");
                }

                return CreatedAtAction(nameof(Register), user, null);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
