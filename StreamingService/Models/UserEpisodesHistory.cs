using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("user_episodes_history")]
    public class UserEpisodesHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }


        [Required, Column("paused_watch_time")]
        public int PausedWatchTime { get; set; }

        [Required, Column("last_watched_at")]
        public DateTime LastWatchedAt { get; set; }

        [Required, Column("is_fully_watched")]
        public bool IsFullyWatched { get; set; }

        //[Required, Column("video_episodes_id")]
        //public int VideoEpisodeId { get; set; }
        //public VideoEpisode VideoEpisode { get; set; }

        [Required, Column("user_profile_id")]
        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}
