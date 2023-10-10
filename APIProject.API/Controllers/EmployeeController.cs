using APIProject.Entities;
using APIProject.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetEmployees();
            if (employees is not null)
            {
                return Ok(employees);
            }
            else
                return BadRequest();
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee is not null)
            {
                return Ok(employee);
            }
            else 
                return NotFound();
        }
        [HttpGet]
        [Route("[action]/{department}")]
        public IActionResult GetEmployeeByDeparment(string deparment)
        {
            var employees = _employeeService.GetEmployeesByDepartment(deparment);
            if (employees.Count>0)
            {
                return Ok(employees);
            }
            else
                return NotFound();
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            _employeeService.AddEmployee(employee);
            return CreatedAtAction("GetEmployee",new { id = employee.Id},employee);
        }
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
            return Ok();
        }
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok("Personel Silindi");
        }
    }
}
