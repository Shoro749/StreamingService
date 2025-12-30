using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("user_profile")]
    public class UserProfile
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        [Required, StringLength(64), Column("username")]
        public string Username { get; set; }

        [Column("birthday")]
        public DateTime? Birthday { get; set; }

        [StringLength(2048), Column("avatar_url")]
        public string? AvatarUrl { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<UserCommentLike> UserCommentLikes { get; set; } = new List<UserCommentLike>();

        public ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();

        public ICollection<UserVideoRating> UserVideoRatings { get; set;} = new List<UserVideoRating>();

        public ICollection<UserVideoFavorite> UserVideoFavorites { get; set;} = new List<UserVideoFavorite>();

        public ICollection<UserEpisodesHistory> UserEpisodesHistory { get; set;} = new List<UserEpisodesHistory>();

        public ICollection<VideoEpisodeViewTimedLog> VideoEpisodeViewTimedLogs { get; set; } = new List<VideoEpisodeViewTimedLog>();
    }
}
