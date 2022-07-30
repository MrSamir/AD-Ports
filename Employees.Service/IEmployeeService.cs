using Employees.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(long id);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(long id);



        //Task<(bool IsSuccess, IEnumerable<Employee> Employees, string ErrorMessage)> GetEmployeesAsync();
        //Task<(bool IsSuccess, Employee Employee, string ErrorMessage)> GetEmployeeAsync(int id);

        //Task<(bool IsSuccess, Employee Product, string ErrorMessage)> GetEmployeeAsync(int id);

        //Task<(bool IsSuccess, Employee Product, string ErrorMessage)> GetEmployeeAsync(int id);
    }
}
