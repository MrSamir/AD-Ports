
using ECommerce.Api.Employees.Db;
using ECommerce.Api.Employees.Interfaces;
using ECommerce.Api.Employees.Providers;
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

builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnection"));
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
