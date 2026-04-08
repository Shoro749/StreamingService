namespace StreamingService.DTO.ViewModels
{
    public class PricingTier
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Price { get; set; } = "";
        public string ButtonText { get; set; } = "";
        public List<string> Features { get; set; } = new List<string>();
    }
}
