namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TVShow
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Country { get; set; }

        public DateTime ReleaseDate => DateTime.UtcNow;

        [Required]
        public string Description { get; set; }

        public int Year { get; set; }

        public int Duration { get; set; }

        public int Budget { get; set; }

        public int Gross { get; set; }

        public double Rating { get; set; }

        public string VideoUrl { get; set; }

        [ForeignKey(nameof(Image))]
        public Guid ImageId { get; set; }

        public Image Image { get; set; }

        public ICollection<Episode> Episodes { get; set; } = new HashSet<Episode>();

        public ICollection<Image> MovieImages { get; set; } = new HashSet<Image>();

        public ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();

        public ICollection<TVShowActor> Actors { get; set; } = new HashSet<TVShowActor>();

        public ICollection<UserTVShow> UsersTVShow { get; set; } = new HashSet<UserTVShow>();
    }
}
