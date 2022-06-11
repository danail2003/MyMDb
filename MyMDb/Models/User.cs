using System.ComponentModel.DataAnnotations;

namespace MyMDb.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Movie> RatedMovies { get; set; } = new HashSet<Movie>();

        public ICollection<Movie> WatchList { get; set; } = new HashSet<Movie>();

        public ICollection<Actor> Actors { get; set; } = new HashSet<Actor>();
    }
}
