using EMPLOYEE_CRUID_API.IServiceRepository;
using EMPLOYEE_CRUID_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EMPLOYEE_CRUID_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        public EmployeesController(IEmployeeRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> List() => Ok(await _repo.ListAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var emp = await _repo.GetAsync(id);
            return emp is null ? NotFound() : Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee emp)
        {
            var newId = await _repo.CreateAsync(emp);
            var created = await _repo.GetAsync(newId);
            return CreatedAtAction(nameof(Get), new { id = newId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Employee emp)
        {
            emp.EmployeeId = id;
            var ok = await _repo.UpdateAsync(emp);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _repo.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
