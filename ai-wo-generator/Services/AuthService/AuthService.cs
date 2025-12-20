using ai_wo_generator.DTOs.Authentication;
using ai_wo_generator.DTOs.UserProfile;
using ai_wo_generator.Models;
using ai_wo_generator.Repository.User;

namespace ai_wo_generator.Services.AuthService
{
    public class AuthService(IUserRepository _userRepository, JwtService jwtService) : IAuthService
    {
        private readonly JwtService _jwtService = jwtService;
        public async Task<UserLoginResponseDto> RegisterAsync(UserRegisterationRequest request)
        {
            try
            {
                var existingUser = await _userRepository.GetByEmailAsync(request.Email);
                if (existingUser != null)
                {
                    throw new Exception("User with this email already exists.");
                }
                var user = new User
                {
                    Email = request.Email,
                    PasswordHash = HashPassword(request.Password),
                    FullName = request.FullName!,
                    CreatedAt = DateTime.UtcNow
                };

                var createdUser = await _userRepository.CreateAsync(user);

                var token = _jwtService.GenerateToken(user);

                var response = new UserLoginResponseDto
                {
                    Token = token,
                    User = new UserDto
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FullName = user.FullName
                    }
                };

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string HashPassword(string password)
        {

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task<UserLoginResponseDto> LoginAsync(UserLoginRequest loginRequest)
        {
            var user = await _userRepository.GetByEmailAsync(loginRequest.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            var token = _jwtService.GenerateToken(user);

            var response = new UserLoginResponseDto
            {
                Token = token,
                ExpiryInMinutes = _jwtService.GetTokenExpiryInMinutes(),
                User = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName
                }
            };

            return response;
        }
    }
}
