using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Services.AddOcelot();

#region JWT Authentication
var secret = builder.Configuration["SecretApiKey"];
var key = Encoding.ASCII.GetBytes(secret);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(key),

        //For this small system will be only validate key
        ValidateIssuerSigningKey = true,

        //not validating server
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
#endregion



//Enable CORS
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var origins = builder.Configuration["AllowedOrigin"].Split(";");
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        options =>
        {
            options.WithOrigins(origins)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .AllowAnyHeader();
        });
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((hosts) => true));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseCors("CORSPolicy");
app.UseCors(myAllowSpecificOrigins);



//adding Ocelot Middleware
//await app.UseOcelot();
app.UseOcelot().Wait();



app.UseHttpsRedirection();

app.UseAuthorization();
// app.UseAuthentication();
app.MapControllers();

app.Run();
