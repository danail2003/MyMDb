namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Actor
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public DateTime BornDate { get; set; }

        [Required]
        [MaxLength(30)]
        public string CountryBorn { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string CityBorn { get; set; } = string.Empty;

        public ICollection<UserActor> UsersActors { get; set; } = new HashSet<UserActor>();

        public ICollection<MovieActor> Movies { get; set; } = new HashSet<MovieActor>();
    }
}
