namespace StreamingService.DTO.ViewModels
{
    public class HomePageViewModel
    {
        public List<VideoCardViewModel> Slider { get; set; }
        public List<VideoCardViewModel> Popular { get; set; }
        public List<VideoCardViewModel> Trending { get; set; }
        public List<VideoCardViewModel> NewReleases { get; set; }
        public List<VideoCardViewModel> WeeklyHits { get; set; }
        public List<PricingTier> PricingTiers { get; set; } = new List<PricingTier>();
        public List<StudioItem> Studios { get; set; } = new List<StudioItem>();
        public List<FeatureItem> Features { get; set; } = new List<FeatureItem>();
        public List<FaqItem> Questions { get; set; } = new List<FaqItem>();
        public List<TopMovieItem> TopMovies { get; set; }
    }
}
