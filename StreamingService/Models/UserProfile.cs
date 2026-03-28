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

        [Required, StringLength(256), Column("email")]
        public string Email { get; set; }

        [StringLength(512), Column("password_hash")]
        public string? PasswordHash { get; set; }

        [StringLength(128), Column("google_id")]
        public string? GoogleId { get; set; }

        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();
    }
}
