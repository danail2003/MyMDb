namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Episode
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }

        public DateTime ReleaseDate => DateTime.UtcNow;

        public TimeSpan Duration { get; set; }

        [ForeignKey(nameof(Image))]
        public Guid ImageId { get; set; }

        public Image Image { get; set; }

        [ForeignKey(nameof(TVShow))]
        public Guid TVShowId { get; set; }

        public TVShow TVShow { get; set; }

        public ICollection<TVShowActor> Actors { get; set; } = new HashSet<TVShowActor>();
    }
}
