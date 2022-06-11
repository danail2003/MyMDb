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

        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
