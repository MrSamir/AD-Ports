using ECommerce.Api.Employees.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Employees.Controllers
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
    }
}