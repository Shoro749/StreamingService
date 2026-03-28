namespace StreamingService.DTO.ViewModels
{
    public class UserProfileHeaderViewModel
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string AvatarUrl { get; set; } = "";
        public string SubscriptionLevel { get; set; } = "Free";
        public bool HasActiveSubscription { get; set; }

        public string DisplayName => !string.IsNullOrEmpty(Username) ? Username : Email.Split('@')[0];

        public string SubscriptionDisplayName => SubscriptionLevel switch
        {
            "Premium" => "Преміум",
            "Standard" => "Стандарт",
            "Basic" => "Базовий",
            _ => "Безкоштовно"
        };
    }
}
