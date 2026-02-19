namespace StreamingService.DTO.ViewModels
{
    public class SubscriptionViewModel
    {
        public int UserId { get; set; }
        public string BackgroundText { get; set; } = "";
        public List<SubscriptionPlanDto> Plans { get; set; } = new List<SubscriptionPlanDto>();
        //public List<PricingTier> Plans { get; set; } = new List<PricingTier>();
    }
}
