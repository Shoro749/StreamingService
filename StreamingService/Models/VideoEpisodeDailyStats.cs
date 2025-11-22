using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("video_episode_daily_stats")]
    public class VideoEpisodeDailyStats
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        [Required, Column("total_user_views")]
        public int TotalUserViews { get; set; }

        [Required, Column("date")]
        public DateTime Date { get; set; }

        [Required, Column("video_episodes_id")]
        public int VideoEpisodeId { get; set; }
        public VideoEpisode VideoEpisode { get; set; }

    }
}
