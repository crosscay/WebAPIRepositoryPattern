using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPIRepositoryPattern.DTOs;
using WebAPIRepositoryPattern.Models;
using WebAPIRepositoryPattern.Paging;
using WebAPIRepositoryPattern.Repository;

namespace WebAPIRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductssController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public ProductssController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }


        //api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetProductss([FromQuery] PagingParameters pagingParameters)
        {
            return await _employeeRepository.GetEmployees(pagingParameters);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetProducttById(int id)
        {
            var employee = await _employeeRepository.FindEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateProductt([FromBody] EmployeeAddDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return BadRequest("Employee object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var employee = _mapper.Map<Employee>(employeeDTO);
            await _employeeRepository.CreateEmployee(employee);
            return Ok(CreatedAtRoute("EmpId", new { id = employee.EmpId }, employee));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductt(int id, [FromBody] Employee employee)
        {
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
        public async Task<ActionResult> DeleteProductt(int id)
        {
            var dbemp = await _employeeRepository.FindEmployee(id);
            if (dbemp.EmpId.Equals(id))
            {
                await _employeeRepository.DeleteEmployee(dbemp, id);
            }

            return NoContent();
        }

    }
}
