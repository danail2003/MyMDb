namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<UserMovie> RatedMovies { get; set; } = new HashSet<UserMovie>();

        public ICollection<UserMovie> WatchList { get; set; } = new HashSet<UserMovie>();
    }
}
