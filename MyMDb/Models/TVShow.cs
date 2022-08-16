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

        public ICollection<Episode> Episodes { get; set; } = new HashSet<Episode>();

        public ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();

        public ICollection<TVShowActor> Actors { get; set; } = new HashSet<TVShowActor>();

        public ICollection<UserTVShow> UsersTVShow { get; set; } = new HashSet<UserTVShow>();
    }
}
