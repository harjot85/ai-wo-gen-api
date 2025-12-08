using ai_wo_generator.DTOs.Authentication;
using ai_wo_generator.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace ai_wo_generator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest loginRequest)
        {
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

                return Ok(userId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
