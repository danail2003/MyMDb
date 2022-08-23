﻿namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
