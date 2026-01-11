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

        //[Required, Column("user_id")]
        //public int UserId { get; set; }
        //public User User { get; set; }
    }
}
