using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("subscription_plans")]
    public class SubscriptionPlan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        [Required, Column("price", TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required, Column("period_days")]
        public int PeriodDays { get; set; }

        [Required, Column("trial_days")]
        public int TrialDays { get; set; }

        [StringLength(4096), Column("features")]
        public string? Features { get; set; }

        [Required, Column("is_enabled")]
        public bool IsEnabled { get; set; }

        [Required, Column("subscription_level_id")]
        public int SubscriptionLevelId { get; set; }
        public SubscriptionLevel? SubscriptionLevel { get; set; }

        public ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();
    }
}
