namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class TVShowActor
    {
        [ForeignKey(nameof(TVShow))]
        public Guid TVShowActorId { get; set; }

        public TVShow TVShow { get; set; }

        [ForeignKey(nameof(Actor))]
        public Guid ActorId { get; set; }

        public Actor Actor { get; set; }
    }
}
