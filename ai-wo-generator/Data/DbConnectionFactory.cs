using Microsoft.Data.SqlClient;
using System.Data;

namespace ai_wo_generator.Data
{
    
    public class DbConnectionFactory(IConfiguration configuration)
    {
        private readonly string _cnnectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Missing Default Connection");

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_cnnectionString);
        }
    }
}
