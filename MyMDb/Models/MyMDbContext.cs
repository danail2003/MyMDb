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

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieGenre> MovieGenres { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<MovieActor> MoviesActors { get; set; }

        public DbSet<UserMovie> UsersMovies { get; set; }

        public DbSet<UserActor> UsersActors { get; set; }

        public DbSet<TVShow> TVShows { get; set; }

        public DbSet<TVShowGenre> TVShowGenres { get; set; }

        public DbSet<UserTVShow> UserTVShows { get; set; }

        public DbSet<TVShowActor> TVShowActors { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.MovieId, x.ActorId });
            modelBuilder.Entity<UserMovie>().HasKey(x => new { x.MovieId, x.UserId });
            modelBuilder.Entity<UserActor>().HasKey(x => new { x.UserId, x.ActorId });
            modelBuilder.Entity<UserTVShow>().HasKey(x => new {x.TVShowId, x.UserId});
            modelBuilder.Entity<TVShowActor>().HasKey(x => new { x.ActorId, x.TVShowId });
            modelBuilder.Entity<MovieGenre>().HasKey(x => new { x.MovieId, x.GenreId });
            modelBuilder.Entity<TVShowGenre>().HasKey(x => new { x.TVShowId, x.GenreId });

            modelBuilder.Entity<User>().HasMany(x => x.RatedMovies).WithOne(x => x.User).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
