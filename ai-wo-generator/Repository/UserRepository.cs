using ai_wo_generator.Data;
using ai_wo_generator.Models;
using Dapper;

namespace ai_wo_generator.Repository
{
    public class UserRepository(DbConnectionFactory dbConnectionFactory) : IUserRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

        public async Task<int> CreateAsync(User user)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            const string sql = @"INSERT INTO [dbo].[Users] (Email, PasswordHash, FullName, CreatedAt)
                                 VALUES (@Email, @PasswordHash, @FullName, @CreatedAt);
                                 SELECT CAST(SCOPE_IDENTITY() as int)";

            return await connection.ExecuteScalarAsync<int>(sql, user);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            const string sql = @"SELECT Id, Email, PasswordHash, FullName, CreatedAt
                                 FROM [dbo].[Users]
                                 WHERE Email = @Email";
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Email = email });
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            const string sql = @"SELECT Id, Email, PasswordHash, FullName, CreatedAt
                                 FROM [dbo].[Users]
                                 WHERE Id = @id";
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
        }
    }
}
