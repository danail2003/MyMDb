﻿namespace MyMDb.DTO
{
    using MyMDb.Models;

    public class MovieDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public int Duration { get; set; }

        public int Budget { get; set; }

        public int Gross { get; set; }

        public double Rating { get; set; }

        public string Video { get; set; }

        public string Image { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<MovieActor> Actors { get; set; }
    }
}
