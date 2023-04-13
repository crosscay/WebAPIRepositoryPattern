using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIRepositoryPattern.Models;
using WebAPIRepositoryPattern.Paging;
using WebAPIRepositoryPattern.Repository;

namespace WebAPIRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees([FromQuery] PagingParameters pagingParameters) 
        {
            return await _employeeRepository.GetEmployees(pagingParameters);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id) 
        {
            var employee = await _employeeRepository.FindEmployee(id);

            if (employee == null) 
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
        {
            // employee = _employeeRepository.GetEmployee(id);

            if (employee == null)
            {
                return BadRequest("Employee object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            await _employeeRepository.CreateEmployee(employee);
            return Ok(CreatedAtRoute("EmpId", new { id = employee.EmpId}, employee));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOwner(int id, [FromBody] Employee employee)
        {
            // employee = _employeeRepository.GetEmployee(id);

            if (employee == null)
            {
                return BadRequest("Employee object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var dbemp = await _employeeRepository.FindEmployee(id);
            if (!dbemp.EmpId.Equals(id))
            {
                return NotFound();
            }

            await _employeeRepository.UpdateEmployee(employee, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var dbemp = await _employeeRepository.FindEmployee(id);
            if (dbemp.EmpId.Equals(id)) 
            {
                return NoContent();
            }
            await _employeeRepository.DeleteEmployee(dbemp, id);
            return NoContent();
        }
    }
}
