namespace StreamingService.DTO.ViewModels
{
    public class AgreementViewModel
    {
        public string SubscriptionPlan { get; set; } = "PLAN";
        public decimal SubscriptionPrice { get; set; }
        public string BackgroundText { get; set; } = "";
    }
}
