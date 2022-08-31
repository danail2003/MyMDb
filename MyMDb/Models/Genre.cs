namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        public ICollection<MovieGenre> GenresMovies { get; set; } = new HashSet<MovieGenre>();

        public ICollection<TVShowGenre> GenresTVShows { get; set; } = new HashSet<TVShowGenre>();
    }
}
