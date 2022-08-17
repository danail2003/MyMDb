namespace MyMDb.DTO
{
    using MyMDb.Models;
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
        public int Year { get; set; }

        public int Duration { get; set; }

        public int Budget { get; set; }

        public int Gross { get; set; }

        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        public string Video { get; set; }

        [Required]
        public string Image { get; set; }

        //public ICollection<Genre> Genres { get; set; }

        //public ICollection<MovieActor> Actors { get; set; }
    }
}
