using ai_wo_generator.DTOs.Authentication;
using ai_wo_generator.DTOs.UserProfile;
using ai_wo_generator.Models;
using ai_wo_generator.Repository.User;
using ai_wo_generator.Repository.UserStats;

namespace ai_wo_generator.Services.UserService
{
    public class UserService(IUserRepository userRepository, IUserStatisticsRepository userStatisticsRepository): IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserStatisticsRepository _userStatisticsRepository = userStatisticsRepository;

        public async Task<int> RegisterAsync(UserRegisterationRequest request)
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
                FullName = request.FullName,
                CreatedAt = DateTime.UtcNow
            };
            return await _userRepository.CreateAsync(user);
        }
        
        public async Task<UserProfileResponseDto?> GetUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }
            var userStats = await _userStatisticsRepository.GetById(user.Id);
            UserProfileResponseDto userProfileDto = new()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.FullName ?? string.Empty,
                Statistics = userStats
            };

            return userProfileDto;
        }

        private string HashPassword(string password)
        {
            
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task<int> LoginAsync(UserLoginRequest loginRequest)
        {
            var user = await _userRepository.GetByEmailAsync(loginRequest.Email);

            if (user == null)
            {
                return -1;
            }

            if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash))
            {
                return -1;
            }

            return user.Id;
        }
    }
}
