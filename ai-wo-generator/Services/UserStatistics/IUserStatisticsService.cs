using ai_wo_generator.DTOs.UserProfile;
using ai_wo_generator.Models;

namespace ai_wo_generator.Services.UserStats
{
    public interface IUserStatisticsService
    {
        Task<UserStatistics?> GetUserStatistics(int id);
        Task<int> InsertAsync(UserStatisticsCreateDto request);
    }
}
