using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("video_episode_view_timed_log")]
    public class VideoEpisodeViewTimedLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        [Required, Column("create_at")]
        public DateTime CreateAt { get; set; }

        [Required, Column("user_profile_id")]
        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }

        //[Required, Column("video_episodes _id ")]
        //public int VideoEpisodeId { get; set; }
        //public VideoEpisode? VideoEpisode { get; set; }
    }
}
