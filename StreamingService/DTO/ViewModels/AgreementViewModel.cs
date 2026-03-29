namespace StreamingService.DTO.ViewModels
{
    public class AgreementViewModel
    {
        public int PlanId { get; set; }
        public string SubscriptionPlan { get; set; } = "PLAN";
        public decimal SubscriptionPrice { get; set; }
        public string BackgroundText { get; set; } = "";
    }
}
