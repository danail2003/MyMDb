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
        [MaxLength(20)]
        [MinLength(3)]
        public string Country { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        public bool IsReleased { get; set; }

        public string ReleaseDate { get; set; }

        [Range(1888, 2023)]
        public string Year { get; set; }

        public string Duration { get; set; }

        public string Budget { get; set; }

        public string Gross { get; set; }

        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        public string Video { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
