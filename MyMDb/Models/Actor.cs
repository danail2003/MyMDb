using System.ComponentModel.DataAnnotations;

namespace MyMDb.Models
{
    public class Actor
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime BornDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string CountryBorn { get; set; }

        [Required]
        [MaxLength(25)]
        public string CityBorn { get; set; }

        public ICollection<UserActor> UsersActors { get; set; } = new HashSet<UserActor>();

        public ICollection<Image> Photos { get; set; } = new HashSet<Image>();

        public ICollection<MovieActor> Movies { get; set; } = new HashSet<MovieActor>();
    }
}
