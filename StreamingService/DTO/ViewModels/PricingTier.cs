namespace StreamingService.DTO.ViewModels
{
    public class PricingTier
    {
        public string Title { get; set; } = "";
        public string Price { get; set; } = "";
        public string ButtonText { get; set; } = "";
        public List<string> Features { get; set; } = new List<string>();
    }
}
