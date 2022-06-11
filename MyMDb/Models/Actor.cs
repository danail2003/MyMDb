using System.ComponentModel.DataAnnotations;

namespace MyMDb.Models
{
    public class Actor
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime BornDate { get; set; }

        [Required]
        public string CountryBorn { get; set; }

        [Required]
        public string CityBorn { get; set; }

        public ICollection<Image> Photos { get; set; } = new HashSet<Image>();

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
