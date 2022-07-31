using Microsoft.EntityFrameworkCore;
using EmployeeManagment.Api.Employees.Models;
using System.Diagnostics;

namespace EmployeeManagment.Api.Employees.Db
{
    public class EmployeeDbContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }


        public EmployeeDbContext(DbContextOptions options):base(options)
        {
            //Debug.Write(Database.GetDbConnection().ConnectionString);
            //Debug.Write(Database.GetConnectionString());

            //Debug.Write(Database.GetDbConnection().Database);

            //Debug.Write(Database.GetDbConnection().DataSource);
        }


  
        
    }
}
