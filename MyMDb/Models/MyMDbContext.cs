using Microsoft.EntityFrameworkCore;

namespace MyMDb.Models
{
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

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<MovieActor> MoviesActors { get; set; }

        public DbSet<UserMovie> UsersMovies { get; set; }

        public DbSet<UserActor> UsersActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.MovieId, x.ActorId });
            modelBuilder.Entity<UserMovie>().HasKey(x => new { x.MovieId, x.MovieUserId });
            modelBuilder.Entity<UserActor>().HasKey(x => new { x.ActorUserId, x.ActorId });

            modelBuilder.Entity<User>().HasMany(x => x.RatedMovies).WithOne(x => x.User).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Image>().HasOne(x => x.Movie).WithOne(x => x.Image).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
