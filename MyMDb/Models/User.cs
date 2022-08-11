namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public ICollection<UserMovie> RatedMovies { get; set; } = new HashSet<UserMovie>();

        public ICollection<UserMovie> WatchList { get; set; } = new HashSet<UserMovie>();

        public ICollection<UserActor> UsersActors { get; set; } = new HashSet<UserActor>();
    }
}
