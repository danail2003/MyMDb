namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string ReleaseDate { get; set; }

        public int Year { get; set; }

        public string? Duration { get; set; }

        public string Gross { get; set; }

        public double Rating { get; set; }

        [Required]
        public string Image { get; set; } = string.Empty;

        [Required]
        public string Genres { get; set; } = string.Empty;

        [Required]
        public string Actors { get; set; } = string.Empty;

        public ICollection<UserMovie> UsersMovie { get; set; } = new HashSet<UserMovie>();
    }
}
