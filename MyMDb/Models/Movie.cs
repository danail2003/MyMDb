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

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public bool IsReleased { get; set; }

        public int Year { get; set; }

        public string? Duration { get; set; }

        public string? Budget { get; set; }

        public string? Gross { get; set; }

        public double Rating { get; set; }

        public string Video { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public ICollection<MovieGenre> MovieGenres { get; set; } = new HashSet<MovieGenre>();

        public ICollection<MovieActor> Actors { get; set; } = new HashSet<MovieActor>();

        public ICollection<UserMovie> UsersMovie { get; set; } = new HashSet<UserMovie>();
    }
}
