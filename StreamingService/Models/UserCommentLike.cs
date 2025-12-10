using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("user_comment_like")]
    public class UserCommentLike
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        [Required, Column("user_profile_id")]
        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }

        [Required, Column("comment_id")]
        public int CommentId { get; set; }
        public Comment? Comment { get; set; }

    }
}
