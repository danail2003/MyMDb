namespace MyMDb.Models
{
    using Microsoft.EntityFrameworkCore;

    public class MyMDbContext : DbContext
    {
        public MyMDbContext()
        {

        }

        public MyMDbContext(DbContextOptions<MyMDbContext> options)
            : base(options)
        {

        }

        internal static MyMDbContext CreateContext()
        {
            bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
            string appSettingsFile = isDevelopment ? "appsettings.Development.json" : "appsettings.json";
            return new MyMDbContext(new DbContextOptionsBuilder<MyMDbContext>().UseSqlServer(
                 new ConfigurationBuilder()
                     .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), appSettingsFile))
                     .AddEnvironmentVariables()
                     .Build()
                     .GetConnectionString("MyMDbConn")).Options);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<UserMovie> UsersMovies { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMovie>().HasKey(x => new { x.MovieId, x.UserId });

            modelBuilder.Entity<User>().HasMany(x => x.RatedMovies).WithOne(x => x.User).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
