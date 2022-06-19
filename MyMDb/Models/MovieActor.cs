using System.ComponentModel.DataAnnotations.Schema;

namespace MyMDb.Models
{
    public class MovieActor
    {
        [ForeignKey(nameof(Movie))]
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; }

        [ForeignKey(nameof(Actor))]
        public Guid ActorId { get; set; }

        public Actor Actor { get; set; }
    }
}
