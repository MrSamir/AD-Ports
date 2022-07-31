using AutoMapper;
using EmployeeManagment.Api.Employees.Db;
using EmployeeManagment.Api.Employees.Interfaces;
using EmployeeManagment.Api.Employees.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Api.Employees.Providers
{
    public class EmployeesProvider : IEmployeesProvider
    {
        private readonly EmployeeDbContext dbContext;
        private readonly ILogger<EmployeesProvider> logger;
        private readonly IMapper mapper;

        public EmployeesProvider(EmployeeDbContext dbContext,ILogger<EmployeesProvider> logger,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            //SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Employees.Any())
            {
                dbContext.Employees.Add(new Db.Employee() { ID = 1, FirstName = "Jack", LastName = "Anderson", Age = "30" });
                dbContext.Employees.Add(new Db.Employee() { ID = 2, FirstName = "Lighting", LastName = "Mqueen", Age = "30" });

                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Employee> Employees, string ErrorMessage)> GetEmployeesAsync()
        {
            try
            {
                var employees = await dbContext.Employees.ToListAsync();
                if (employees != null && employees.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Employee>, IEnumerable<Models.Employee>>(employees);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Models.Employee Employee, string ErrorMessage)> GetEmployeeAsync(int id)
        {
            try
            {
                var employee = await dbContext.Employees.FirstOrDefaultAsync(p => p.ID == id);

                if (employee != null)
                {
                    var result = mapper.Map<Db.Employee, Models.Employee>(employee);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess,int EmployeeID, string ErrorMessage)> InsertEmployeeAsync(Models.Employee newEmployee)
        {
            try
            {
               
             

                //var result = mapper.Map<Db.Employee, Models.Employee>(newEmployee);
                var emp = mapper.Map<Models.Employee,Db.Employee>(newEmployee);

                await dbContext.Employees.AddAsync(emp);
                await dbContext.SaveChangesAsync();
                 
                if (emp.ID != 0)
                {
                    //var result = mapper.Map<Db.Employee, Models.Employee>(newEmployee);
                    return (true, emp.ID, null);
                }
                return (false,0, "Adding Failed");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false,0, ex.Message);
            }
        }

        public async Task<(bool IsSuccess,int result, string ErrorMessage)> UpdateEmployeeAsync(Models.Employee oldEmployee)
        {
            try
            {
                var employee = await dbContext.Employees.FirstOrDefaultAsync(p => p.ID == oldEmployee.ID);

                if (employee != null)
                {
                    var result = mapper.Map<Db.Employee, Models.Employee>(employee);

                     dbContext.Employees.Update(employee);
                    await dbContext.SaveChangesAsync();

                    return (true, 1, null);
                }
                return (false, 0, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, 0, ex.Message);
            }


        }









        public async Task<(bool IsSuccess,int result, string ErrorMessage)> DeleteEmployeeAsync(int id)
        {
           
            try
            {
               
                var employee = await dbContext.Employees.FirstOrDefaultAsync(p => p.ID == id);

                if (employee != null)
                {
                    //Delete Employee
                     dbContext.Employees.Remove(employee);

                    //Commit the transaction
                  var  result = await dbContext.SaveChangesAsync();

                    return (true, result, null);
                }
                return (false, 0, "Delete Failed");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, 0, ex.Message);
            }
        }

       
    }
}
