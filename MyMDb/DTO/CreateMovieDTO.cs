namespace MyMDb.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class CreateMovieDTO
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Range(1888, 2023)]
        public int Year { get; set; }

        [Required]
        public string Duration { get; set; }

        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        public string Image { get; set; }

        [Required, MinLength(2)]
        public string Genres { get; set; }

        [Required, MinLength(5)]
        public string Actors { get; set; }
    }
}
