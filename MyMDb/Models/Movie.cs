namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Country { get; set; } = string.Empty;

        public DateTime ReleaseDate => DateTime.UtcNow;

        [Required]
        public string Description { get; set; } = string.Empty;

        public bool IsReleased { get; set; }

        public int Year { get; set; }

        public int Duration { get; set; }

        public int Budget { get; set; }

        public int Gross { get; set; }

        public double Rating { get; set; }

        public string Video { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();

        public ICollection<MovieActor> Actors { get; set; } = new HashSet<MovieActor>();

        public ICollection<UserMovie> UsersMovie { get; set; } = new HashSet<UserMovie>();
    }
}
