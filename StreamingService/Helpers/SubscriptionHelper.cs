namespace StreamingService.Helpers;

public static class SubscriptionHelper
{
    public static string GetColorClass(string? subscriptionLevel)
    {
        return subscriptionLevel switch
        {
            "Преміум" => "text-[#9333EA]",
            "Стандартний" => "text-[#D0F260]",
            "Безкоштовний" => "text-white",
            _ => "text-white/50"
        };
    }

    //public static string GetDisplayName(string? subscriptionLevel)
    //{
    //    return subscriptionLevel switch
    //    {
    //        "Premium" => "Преміум",
    //        "Standard" => "Стандарт",
    //        "Basic" => "Базовий",
    //        _ => "Безкоштовно"
    //    };
    //}
}