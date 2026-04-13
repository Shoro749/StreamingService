namespace StreamingService.Helpers;

public static class SubscriptionHelper
{
    public static string GetColorClass(string? subscriptionLevel)
    {
        return subscriptionLevel switch
        {
            "Premium" => "text-[#9333EA]",
            "Standard" => "text-[#D0F260]",
            "Basic" => "text-white",
            _ => "text-white/50"
        };
    }

    public static string GetDisplayName(string? subscriptionLevel)
    {
        return subscriptionLevel switch
        {
            "Premium" => "Преміум",
            "Standard" => "Стандарт",
            "Basic" => "Базовий",
            _ => "Безкоштовно"
        };
    }
}