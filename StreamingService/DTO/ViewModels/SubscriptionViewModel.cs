namespace StreamingService.DTO.ViewModels
{
    public class SubscriptionViewModel
    {
        public string BackgroundText { get; set; } = "";
        public List<PricingTier> Plans { get; set; } = new List<PricingTier>();
    }
}
