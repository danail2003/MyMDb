using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMDb.Models
{
    public class Movie
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Country { get; set; }

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

        public ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();

        public ICollection<MovieActor> Actors { get; set; } = new HashSet<MovieActor>();

        public ICollection<UserMovie> UsersMovie { get; set; } = new HashSet<UserMovie>();
    }
}
