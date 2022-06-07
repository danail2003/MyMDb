﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MyMDb.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(Movie))]
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
