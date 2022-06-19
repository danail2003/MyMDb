using System.ComponentModel.DataAnnotations.Schema;

namespace MyMDb.Models
{
    public class UserMovie
    {
        [ForeignKey(nameof(User))]
        public Guid MovieUserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(Movie))]
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
