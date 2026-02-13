namespace StreamingService.DTO.ViewModels
{
    public class SubscriptionViewModel
    {
        public int UserId { get; set; }
        public string BackgroundText { get; set; } = "";
        public List<PricingTier> Plans { get; set; } = new List<PricingTier>();
    }
}
