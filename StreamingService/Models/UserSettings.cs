using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("user_settings")]
    public class UserSettings
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public bool CollectViewingData { get; set; } = true;

        public bool SaveSearchHistory { get; set; } = true;

        public bool PersonalizedRecommendations { get; set; } = true;

        public bool UseCookies { get; set; } = true;

        public bool UsageAnalytics { get; set; } = true;
    }
}
