namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class TVShowGenre
    {
        [ForeignKey(nameof(TVShow))]
        public Guid TVShowId { get; set; }

        public TVShow TVShow { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
