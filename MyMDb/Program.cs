using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyMDb.Constants;
using MyMDb.Models;
using MyMDb.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var dbContext = new MyMDbContext();
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddDbContext<MyMDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(SettingKeys.ConnectionString)));
builder.Services.AddTransient<IMoviesService, MoviesService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("SecretToken:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false

        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
});

using var scope = app.Services.CreateScope();
var dataContext = scope.ServiceProvider.GetRequiredService<MyMDbContext>();
dataContext.Database.Migrate();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
