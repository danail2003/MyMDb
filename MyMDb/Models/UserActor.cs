using System.ComponentModel.DataAnnotations.Schema;

namespace MyMDb.Models
{
    public class UserActor
    {
        [ForeignKey(nameof(User))]
        public Guid ActorUserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(Actor))]
        public Guid ActorId { get; set; }

        public Actor Actor { get; set; }
    }
}
