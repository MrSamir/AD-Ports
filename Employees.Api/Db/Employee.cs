using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.Employees.Db
{
    public class Employee
    {

        public int ID { get; set; }

        [Required]
        public string? FirstName  { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Age { get; set; }

        
       
    }
}
