using ai_wo_generator.Models;
using ai_wo_generator.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace ai_wo_generator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterationRequest request)
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

        [HttpGet("getuser")]
        public async Task<IActionResult> GetUser([FromQuery] int id)
        {
            try
            {
                var user = await _userService.GetUserAsync(id);
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest loginRequest)
        {
            try
            {
                if (loginRequest == null)
                {
                    return Unauthorized("Login credentials missing");
                }

                var user = await _userService.LoginAsync(loginRequest);

                if (user == null)
                {
                    return Unauthorized("Invalid email or password");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
