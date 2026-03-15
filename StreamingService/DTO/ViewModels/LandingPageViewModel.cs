namespace StreamingService.DTO.ViewModels;

public class LandingPageViewModel
{
    public List<PricingTier> PricingTiers { get; set; } = new List<PricingTier>();
    public List<StudioItem> Studios { get; set; } = new List<StudioItem>();
    public List<FeatureItem> Features { get; set; } = new List<FeatureItem>();
    public List<FaqItem> Questions { get; set; } = new List<FaqItem>();
    public List<TopMovieItem> TopMovies { get; set; }
}
