using ai_wo_generator.Data;
using Dapper;

namespace ai_wo_generator.Repository.User
{
    public class UserRepository(DbConnectionFactory dbConnectionFactory) : IUserRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

        public async Task<int> CreateAsync(Models.User user)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            const string sql = @"INSERT INTO [dbo].[Users] (Email, PasswordHash, FullName, CreatedAt)
                                 VALUES (@Email, @PasswordHash, @FullName, @CreatedAt);
                                 SELECT CAST(SCOPE_IDENTITY() as int)";

            return await connection.ExecuteScalarAsync<int>(sql, user);
        }

        public async Task<Models.User?> GetByEmailAsync(string email)
        {
            try
            {   
                using var connection = _dbConnectionFactory.CreateConnection();
                const string sql = @"SELECT Id, Email, PasswordHash, FullName, CreatedAt
                                 FROM [dbo].[Users]
                                 WHERE Email = @Email";

                // Todo: 
                var result = await connection.QuerySingleOrDefaultAsync<Models.User>(sql, new { Email = email });

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Models.User?> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            const string sql = @"SELECT Id, Email, PasswordHash, FullName, CreatedAt
                                 FROM [dbo].[Users]
                                 WHERE Id = @id";
            return await connection.QuerySingleOrDefaultAsync<Models.User>(sql, new { Id = id });
        }
    }
}
