using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EMPLOYEE_CRUID_API.DapperContextDB
{
    public class DapperContext
    {
        private readonly IConfiguration _config;
        public DapperContext(IConfiguration config) 
        { 
        _config = config;
        }
        public IDbConnection CreateConnection()
        {         
           return new SqlConnection(_config.GetConnectionString("DatabaseConnection"));
        }
    }
}


