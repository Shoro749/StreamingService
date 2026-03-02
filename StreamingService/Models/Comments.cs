using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("comments")]
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        [Required, StringLength(4000), Column("text")]
        public string Text { get; set; }

        [Required, Column("create_at")]
        public DateTime CreateAt { get; set; }

        [Required, Column("update_at")]
        public DateTime UpdateAt { get; set; }

        [Required, Column("user_profile_id")]
        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }

        [Required, Column("video_id")]
        public int VideoId { get; set; }
        public Video Video { get; set; }

        [Column("parent_id")]
        public int? ParentId { get; set; }
        public Comment Parent { get; set; }

        public ICollection<Comment> Children { get; set; } = new List<Comment>();
    }
}
