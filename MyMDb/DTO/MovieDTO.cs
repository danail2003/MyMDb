namespace MyMDb.DTO
{
    using MyMDb.Models;

    public class MovieDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public string Duration { get; set; }

        public string Budget { get; set; }

        public string Gross { get; set; }

        public double Rating { get; set; }

        public string Video { get; set; }

        public string Image { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<MovieActor> Actors { get; set; }
    }
}
