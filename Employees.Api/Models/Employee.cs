using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Api.Employees.Models
{
    public class Employee
    {


        public int ID { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Age { get; set; }


    }
}
