using ai_wo_generator.DTOs.UserProfile;
using ai_wo_generator.Models;
using ai_wo_generator.Repository.UserStats;
using ai_wo_generator.Services.UserService;

namespace ai_wo_generator.Services.UserStats
{
    public class UserStatisticsService(IUserStatisticsRepository userStatsRepository, IUserService userService): IUserStatisticsService
    {
        private readonly IUserStatisticsRepository _userStatsRepository = userStatsRepository;
        private readonly IUserService _userService = userService;

        public async Task<UserStatistics?> GetUserStatistics(int id)
        {
            var userStats = await _userStatsRepository.GetById(id);

            if (userStats == null)
            {
                throw new Exception("No Statistics found");
            }

            return userStats;
        }

        public async Task<int> InsertAsync(UserStatisticsCreateDto request)
        {
            var existingUser = await _userService.GetUserAsync(request.UserId);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            var userStatistics = new UserStatistics()
            {
                UserId = request.UserId,
                BiologicalSex = request.BiologicalSex,
                DateOfBirth = request.DateOfBirth,
                HeightInInches = request.HeightInInches,
                WeightInLbs = request.WeightInLbs,
                ExperienceLevel = request.ExperienceLevel,
                Profession = request.Profession,
                ChronicPhysicalLimitations = request.ChronicPhysicalLimitations,
                MedicalIssues = request.MedicalIssues
            };

            var reponse = await _userStatsRepository.Insert(userStatistics);

            return reponse == request.UserId ? 1 : 0;
        }
    }
}
