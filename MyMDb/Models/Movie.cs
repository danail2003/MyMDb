using System.ComponentModel.DataAnnotations.Schema;

namespace MyMDb.Models
{
    public class Movie
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string Country { get; set; }

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

        public ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();

        public ICollection<Actor> Actors { get; set; } = new HashSet<Actor>();
    }
}
