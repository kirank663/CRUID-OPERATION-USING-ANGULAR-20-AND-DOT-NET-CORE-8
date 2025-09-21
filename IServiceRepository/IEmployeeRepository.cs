using EMPLOYEE_CRUID_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMPLOYEE_CRUID_API.IServiceRepository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> ListAsync();
        Task<Employee> GetAsync(int id);
        Task<int> CreateAsync(Employee emp);
        Task<bool> UpdateAsync(Employee emp);
        Task<bool> DeleteAsync(int id);
    }
}
