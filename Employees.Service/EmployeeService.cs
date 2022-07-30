using Employees.Data;
using Employees.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> employeeRepository;
 
        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = this.employeeRepository;
           
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employeeRepository.GetAll();
        }

        public Employee GetEmployee(long id)
        {
            return employeeRepository.Get(id);
        }

        public void InsertEmployee(Employee employee)
        {
            employeeRepository.Insert(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            employeeRepository.Update(employee);
        }

        public void DeleteEmployee(long id)
        {
            
            Employee employee = GetEmployee(id);
            employeeRepository.Remove(employee);
             employeeRepository.SaveChanges();
        }
    }
}
