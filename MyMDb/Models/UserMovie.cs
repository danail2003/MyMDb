namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserMovie
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(Movie))]
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
