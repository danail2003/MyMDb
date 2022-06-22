using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMDb.Models
{
    public class Image
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(5)]
        public string Extension { get; set; }

        [ForeignKey(nameof(Movie))]
        public Guid MovieImageId { get; set; }

        public Movie Movie { get; set; }
    }
}
