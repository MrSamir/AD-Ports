using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagment.Api.Employees.Db
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string? FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string? LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(3)")]
        public string? Age { get; set; }




    }
}
