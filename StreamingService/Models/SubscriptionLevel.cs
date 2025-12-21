using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("subscription_levels")]
    public class SubscriptionLevel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        [Required, StringLength(256), Column("code")]
        public string? Code { get; set; }
    }
}
