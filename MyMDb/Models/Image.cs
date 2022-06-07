using System.ComponentModel.DataAnnotations.Schema;

namespace MyMDb.Models
{
    public class Image
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Extension { get; set; }

        [ForeignKey(nameof(Movie))]
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
