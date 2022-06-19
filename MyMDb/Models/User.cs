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

        public ICollection<UserMovie> RatedMovies { get; set; } = new HashSet<UserMovie>();

        public ICollection<UserMovie> WatchList { get; set; } = new HashSet<UserMovie>();

        public ICollection<UserActor> UsersActors { get; set; } = new HashSet<UserActor>();
    }
}
