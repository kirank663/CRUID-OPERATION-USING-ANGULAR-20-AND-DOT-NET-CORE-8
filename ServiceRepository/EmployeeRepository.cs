using Dapper;
using EMPLOYEE_CRUID_API.DapperContextDB;
using EMPLOYEE_CRUID_API.IServiceRepository;
using EMPLOYEE_CRUID_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMPLOYEE_CRUID_API.ServiceRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _ctx;
        public EmployeeRepository(DapperContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            using var conn = _ctx.CreateConnection();
            return await conn.QueryAsync<Employee>("dbo.usp_Employees_List",
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<Employee> GetAsync(int id)
        {
            using var conn = _ctx.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<Employee>("dbo.usp_Employees_GetById",
                new { EmployeeId = id }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> CreateAsync(Employee emp)
        {
            using var conn = _ctx.CreateConnection();
            return await conn.ExecuteScalarAsync<int>("dbo.usp_Employees_Insert", new
            {
                emp.FirstName,
                emp.LastName,
                emp.Email,
                emp.Phone,
                emp.Title,
                emp.IsActive
            }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateAsync(Employee emp)
        {
            using var conn = _ctx.CreateConnection();
            var rows = await conn.ExecuteScalarAsync<int>("dbo.usp_Employees_Update", new
            {
                emp.EmployeeId,
                emp.FirstName,
                emp.LastName,
                emp.Email,
                emp.Phone,
                emp.Title,
                emp.IsActive
            }, commandType: System.Data.CommandType.StoredProcedure);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = _ctx.CreateConnection();
            var rows = await conn.ExecuteScalarAsync<int>("dbo.usp_Employees_Delete",
                new { EmployeeId = id }, commandType: System.Data.CommandType.StoredProcedure);
            return rows > 0;
        }
    }
}
