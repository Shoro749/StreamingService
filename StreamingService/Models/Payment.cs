using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("payments")]
    public class Payment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }


        [Required, Column("amount", TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [Required, StringLength(3), Column("currency")]
        public string Currency { get; set; }

        [Required, StringLength(64), Column("provider")]
        public string Provider { get; set; }

        [Required, StringLength(64), Column("method")]
        public string Method { get; set; }

        [Required, StringLength(128), Column("transaction_id")]
        public string TransactionId { get; set; }

        [Required, StringLength(32), Column("status")]
        public string Status { get; set; }

        [Required, Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();

    }
}
