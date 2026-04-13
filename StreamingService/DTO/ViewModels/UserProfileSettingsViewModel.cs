namespace StreamingService.DTO.ViewModels;

public class UserProfileSettingsViewModel
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string? AvatarUrl { get; set; }
    public string? SubscriptionLevel { get; set; }
}