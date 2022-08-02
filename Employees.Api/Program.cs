
using EmployeeManagment.Api.Employees.Db;
using EmployeeManagment.Api.Employees.Interfaces;
using EmployeeManagment.Api.Employees.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeesProvider, EmployeesProvider>();
builder.Services.AddAutoMapper(typeof(Program));

//Setting Up connection string
var server = builder.Configuration["DBServer"] ?? "ms-sql-server";
var port = builder.Configuration["DBPort"] ?? "1433";
var user = builder.Configuration["DBUser"] ?? "SA";
var password = builder.Configuration["DBPassword"] ?? "Pass@word1";
var database = builder.Configuration["DBName"] ?? "EmployeeManagment";

builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    // options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnection"));
    var connection = $"Server={server},{port};Database={database};Trusted_Connection=True;User Id={user};Password={password}";
    options.UseSqlServer(connection);
});


// Enable CORS
var origins = builder.Configuration["AllowedOrigin"].Split(";");
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        options =>
        {
            options.WithOrigins(origins)
            .AllowAnyMethod()
            .WithExposedHeaders("content-disposition")
            .SetPreflightMaxAge(TimeSpan.FromSeconds(3600))
            .AllowCredentials()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(myAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
