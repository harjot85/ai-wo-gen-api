using ai_wo_generator.DTOs.UserProfile;
using ai_wo_generator.Repository.User;
using ai_wo_generator.Repository.UserStats;

namespace ai_wo_generator.Services.UserService
{
    public class UserService(IUserRepository userRepository, IUserStatisticsRepository userStatisticsRepository): IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserStatisticsRepository _userStatisticsRepository = userStatisticsRepository;
       
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
                User = new()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName ?? string.Empty,
                },
                Statistics = userStats
            };

            return userProfileDto;
        }
    }
}
