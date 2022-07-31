using EmployeeManagment.Api.Employees.Models;


namespace EmployeeManagment.Api.Employees.Interfaces
{
    public interface IEmployeesProvider
    {
        Task<(bool IsSuccess, IEnumerable<Employee> Employees, string ErrorMessage)> GetEmployeesAsync();
        Task<(bool IsSuccess, Employee Employee, string ErrorMessage)> GetEmployeeAsync(int id);
        Task<(bool IsSuccess,int EmployeeID, string ErrorMessage)> InsertEmployeeAsync(Employee Employee);
        Task<(bool IsSuccess,int result ,string ErrorMessage)> UpdateEmployeeAsync(Employee Employee);
        Task<(bool IsSuccess,int result, string ErrorMessage)> DeleteEmployeeAsync(int id);
        




    }
}
