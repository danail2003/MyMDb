namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TVShow
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

        public ICollection<TVShowGenre> TVShowGenres { get; set; } = new HashSet<TVShowGenre>();

        public ICollection<TVShowActor> TVShowActors { get; set; } = new HashSet<TVShowActor>();

        public ICollection<UserTVShow> UsersTVShow { get; set; } = new HashSet<UserTVShow>();
    }
}
