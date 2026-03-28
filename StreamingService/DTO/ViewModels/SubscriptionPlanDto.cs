namespace StreamingService.DTO.ViewModels
{
    public class SubscriptionPlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int PeriodDays { get; set; }
        public string? Description { get; set; }
        public string? Features { get; set; }
    }
}
