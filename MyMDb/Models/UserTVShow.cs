namespace MyMDb.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserTVShow
    {
        [ForeignKey(nameof(User))]
        public Guid TVShowUserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(TVShow))]
        public Guid TVShowId { get; set; }

        public TVShow TVShow { get; set; }
    }
}
