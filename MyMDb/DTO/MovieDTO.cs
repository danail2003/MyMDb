﻿using MyMDb.Models;

namespace MyMDb.DTO
{
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

        public string VideoUrl { get; set; }

        public Guid ImageId { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<MovieActor> Actors { get; set; }
    }
}