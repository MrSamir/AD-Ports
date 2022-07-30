using AutoMapper;
using ECommerce.Api.Employees.Db;
using ECommerce.Api.Employees.Interfaces;
using ECommerce.Api.Employees.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Employees.Providers
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
                var product = await dbContext.Employees.FirstOrDefaultAsync(p => p.ID == id);

                if (product != null)
                {
                    var result = mapper.Map<Db.Employee, Models.Employee>(product);
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
    }
}
