namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserActor
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(Actor))]
        public Guid ActorId { get; set; }

        public Actor Actor { get; set; }
    }
}
