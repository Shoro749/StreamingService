using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("users_subscriptions")]
    public class UserSubscription
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        [Required, StringLength(32), Column("status")]
        public string Status { get; set; }

        [Required, Column("auto_renew")]
        public bool AutoRenew { get; set; }

        [Required, Column("subscription_start_date")]
        public DateTime SubscriptionStart { get; set; }

        [Required, Column("subscription_end_date")]
        public DateTime SubscriptionEnd { get; set; }

        [Required, Column("user_profile_id")]
        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }

        [Column("payment_id")]
        public int PaymentId { get; set; }
        public Payment? Payment { get; set; }

        [Required, Column("subscription_plan_id")]
        public int SubscriptionPlanId { get; set; }
        public SubscriptionPlan? SubscriptionPlan { get; set; }
    }
}
