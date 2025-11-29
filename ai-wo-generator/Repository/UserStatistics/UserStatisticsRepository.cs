using ai_wo_generator.Data;
using ai_wo_generator.Models;
using Dapper;

namespace ai_wo_generator.Repository.UserStats
{
    public class UserStatisticsRepository(DbConnectionFactory dbConnectionFactory) : IUserStatisticsRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

        public async Task<UserStatistics?> GetById(int id)
        {
            try
            {
                using var connection = _dbConnectionFactory.CreateConnection();
                const string sql = @"SELECT TOP (1000) [UserId]
                                      ,[HeightInInches]
                                      ,[WeightInPounds]
                                      ,[Gender]
                                      ,[DateOfBirth]
                                      ,[CreatedAt]
                                      ,[UpdatedAt]
                                  FROM [dbo].[UserStatistics]
                                    WHERE UserId = @UserId";

                var result = await connection.QuerySingleOrDefaultAsync<UserStatistics>(sql, new { UserId = id });

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<UserStatistics?> Save(UserStatistics userStatistics)
        {
            throw new NotImplementedException();
        }
    }
}
