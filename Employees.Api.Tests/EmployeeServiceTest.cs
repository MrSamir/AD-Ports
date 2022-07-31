using AutoMapper;
using EmployeeManagment.Api.Employees.Profiles;
using EmployeeManagment.Api.Employees.Db;
 
using EmployeeManagment.Api.Employees.Providers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagment.Api.Employees.Tests
{
    public class EmployeeServiceTest
    {
        [Fact]
        public async Task GetEmployeesReturnsAllEmployees()
        {
            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(nameof(GetEmployeesReturnsAllEmployees))
                .Options;
            var dbContext = new EmployeeDbContext(options);
            CreateEmployees(dbContext);

            var employeeProfile = new EmployeeProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(employeeProfile));
            var mapper = new Mapper(configuration);

            var employeesProvider = new EmployeesProvider(dbContext, null, mapper);

            var employee = await employeesProvider.GetEmployeesAsync();
            Assert.True(employee.IsSuccess);
            Assert.True(employee.Employees.Any());
            Assert.Null(employee.ErrorMessage);
        }

        [Fact]
        public async Task GetEmployeeReturnsProductUsingValidId()
        {
            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(nameof(GetEmployeeReturnsProductUsingValidId))
                .Options;
            var dbContext = new EmployeeDbContext(options);
            CreateEmployees(dbContext);

            var employeeProfile = new EmployeeProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(employeeProfile));
            var mapper = new Mapper(configuration);

            var employeesProvider = new EmployeesProvider(dbContext, null, mapper);

            var employee = await employeesProvider.GetEmployeeAsync(1);
            Assert.True(employee.IsSuccess);
            Assert.NotNull(employee.Employee);
            Assert.True(employee.Employee.ID == 1);
            Assert.Null(employee.ErrorMessage);
        }

        [Fact]
        public async Task GetEmployeeReturnsEmployeeUsingInvalidId()
        {
            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(nameof(GetEmployeeReturnsEmployeeUsingInvalidId))
                .Options;
            var dbContext = new EmployeeDbContext(options);
            CreateEmployees(dbContext);

            var employeeProfile = new EmployeeProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(employeeProfile));
            var mapper = new Mapper(configuration);

            var employeesProvider = new EmployeesProvider(dbContext, null, mapper);

            var employee = await employeesProvider.GetEmployeeAsync(-1);
            Assert.False(employee.IsSuccess);
            Assert.Null(employee.Employee);
            Assert.NotNull(employee.ErrorMessage);
        }

        private void CreateEmployees(EmployeeDbContext dbContext)
        {
            for (int i = 1; i <= 10; i++)
            {
                dbContext.Employees.Add(new Employee()
                {
                    ID = 1,

                    FirstName = Guid.NewGuid().ToString(),
                    LastName = Guid.NewGuid().ToString(),
                    Age = Guid.NewGuid().ToString()
                }); 
            }
            dbContext.SaveChanges();
        }
    }
}
