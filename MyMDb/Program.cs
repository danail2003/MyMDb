using Microsoft.EntityFrameworkCore;
using MyMDb.Constants;
using MyMDb.Models;
using MyMDb.Services;

var builder = WebApplication.CreateBuilder(args);

var dbContext = new MyMDbContext();
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddDbContext<MyMDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(SettingKeys.ConnectionString)));
builder.Services.AddTransient<IMoviesService, MoviesService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
