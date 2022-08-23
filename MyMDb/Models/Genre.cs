using System.ComponentModel.DataAnnotations;

namespace MyMDb.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

        public ICollection<TVShow> TVShows { get; set; } = new HashSet<TVShow>();
    }
}
