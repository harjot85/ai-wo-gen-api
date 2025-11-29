using ai_wo_generator.Models;
using ai_wo_generator.Repository.UserStats;

namespace ai_wo_generator.Services.UserStats
{
    public class UserStatisticsService(IUserStatisticsRepository userStatsRepository): IUserStatisticsService
    {
        private readonly IUserStatisticsRepository _userStatsRepository = userStatsRepository;
        
        public async Task<UserStatistics?> GetUserStatistics(int id)
        {
            var userStats = await _userStatsRepository.GetById(id);

            if (userStats == null)
            {
                throw new Exception("No Statistics found");
            }

            return userStats;
        }

      
    }
}
