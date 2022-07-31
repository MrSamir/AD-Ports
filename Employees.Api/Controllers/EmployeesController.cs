using EmployeeManagment.Api.Employees.Interfaces;
using EmployeeManagment.Api.Employees.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeManagment.Api.Employees.Controllers
{
    [ApiController]
    [Route("api/employees")]


    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesProvider employeesProvider;

        public EmployeesController(IEmployeesProvider employeesProvider)
        {
            this.employeesProvider = employeesProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var result = await employeesProvider.GetEmployeesAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Employees);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            var result = await employeesProvider.GetEmployeeAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Employee);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            var result = await employeesProvider.DeleteEmployeeAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployeeAsync(Employee employee)
        {
            var result = await employeesProvider.InsertEmployeeAsync(employee);
            if (result.IsSuccess)
            {
                return CreatedAtAction("Get", new { id = employee.ID }, employee);
            }

            return StatusCode(500);

        }


        [HttpPut]
        public async Task<IActionResult> UpdatEmployeeAsync([FromBody] Employee employee)
        {

            var result = await employeesProvider.UpdateEmployeeAsync(employee);
            if (result.IsSuccess)
            {
                return CreatedAtAction("Get", new { id = employee.ID }, employee);

            }
            return StatusCode(500);

        }
    }
}