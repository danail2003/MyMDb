namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Episode
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public double Rating { get; set; }

        public DateTime ReleaseDate => DateTime.UtcNow;

        public TimeSpan Duration { get; set; }

        public string Image { get; set; } = string.Empty;

        [ForeignKey(nameof(TVShow))]
        public Guid TVShowId { get; set; }

        public TVShow TVShow { get; set; }

        public ICollection<TVShowActor> Actors { get; set; } = new HashSet<TVShowActor>();
    }
}
