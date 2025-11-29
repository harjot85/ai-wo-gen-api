using ai_wo_generator.Models;

namespace ai_wo_generator.Repository.UserStats
{
    public interface IUserStatisticsRepository
    {
        Task<UserStatistics?> GetById(int id);
        Task<UserStatistics?> Save(UserStatistics userStatistics);
        
    }
}
