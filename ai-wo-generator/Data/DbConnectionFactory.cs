using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace ai_wo_generator.Data
{
    public class SqlConnectionSettings
    {
        public string DefaultConnection { get; set; } = string.Empty;
    }

    public class DbConnectionFactory(IOptions<SqlConnectionSettings> options)
    {
        private readonly SqlConnectionSettings _settings = options.Value;

        public IDbConnection CreateConnection()
        {
            var connectionString = _settings.DefaultConnection ?? throw new Exception("Missing Default Connection");
            return new SqlConnection(connectionString);
        }
    }
}
