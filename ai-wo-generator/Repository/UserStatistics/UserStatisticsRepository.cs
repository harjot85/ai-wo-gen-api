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
                                          ,[DateOfBirth]
                                          ,[WeightInLbs]
                                          ,[HeightInInches]
                                          ,[BiologicalSex]
                                          ,[ExperienceLevel]
                                          ,[Profession]
                                          ,[ChronicPhysicalLimitations]
                                          ,[MedicalIssues]
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

        public async Task<int?> Insert(UserStatistics userStatistics)
        {
            try
            { 
                using var connection = _dbConnectionFactory.CreateConnection();
                const string sql = @"INSERT INTO [dbo].[UserStatistics]
                                           ([UserId]
                                           ,[DateOfBirth]
                                           ,[WeightInLbs]
                                           ,[HeightInInches]
                                           ,[BiologicalSex]
                                           ,[ExperienceLevel]
                                           ,[Profession]
                                           ,[ChronicPhysicalLimitations]
                                           ,[MedicalIssues]
                                           ,[CreatedAt]
                                           ,[UpdatedAt])
                                     VALUES
                                           (@UserId
                                           ,@DateOfBirth
                                           ,@WeightInLbs
                                           ,@HeightInInches
                                           ,@BiologicalSex
                                           ,@ExperienceLevel
                                           ,@Profession
                                           ,@ChronicPhysicalLimitations
                                           ,@MedicalIssues
                                           ,GETDATE()
                                           ,GETDATE());
                                     SELECT CAST(SCOPE_IDENTITY() as int);";
                var result = await connection.ExecuteScalarAsync<int>(sql, userStatistics);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
