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
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await employeesProvider.GetEmployeesAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Employees);
            }
            return NotFound();
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            var result = await employeesProvider.GetEmployeeAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Employee);
            }
            return NotFound();
        }
        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await employeesProvider.DeleteEmployeeAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee employee)
        {
            var result = await employeesProvider.InsertEmployeeAsync(employee);
            if (result.IsSuccess)
            {
                return Ok(result);
                //return CreatedAtAction("GetEmployeeAsync", new { id = employee.ID }, employee);
            }

            return StatusCode(500);

        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {

            var result = await employeesProvider.UpdateEmployeeAsync(employee);
            if (result.IsSuccess)
            {
                //return CreatedAtAction("GetEmployeeAsync", new { id = employee.ID }, employee);
                return Ok(result);

            }
            return StatusCode(500);

        }
    }
}