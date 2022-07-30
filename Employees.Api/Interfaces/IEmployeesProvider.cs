using ECommerce.Api.Employees.Models;
 

namespace ECommerce.Api.Employees.Interfaces
{
    public interface IEmployeesProvider
    {
        Task<(bool IsSuccess, IEnumerable<Employee> Employees, string ErrorMessage)> GetEmployeesAsync();
        Task<(bool IsSuccess, Employee Employee, string ErrorMessage)> GetEmployeeAsync(int id);


    }
}
