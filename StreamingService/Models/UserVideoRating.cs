using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("user_video_rating")]
    public class UserVideoRating
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        //[Required, Column("video_id")]
        //public int VideoId { get; set; }
        //public Video Video { get; set; }

        [Required, Column("user_profile_id")]
        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }

        [Required, Column("rating")]
        public int Rating { get; set; }
    }
}
