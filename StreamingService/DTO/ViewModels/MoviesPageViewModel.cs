namespace StreamingService.DTO.ViewModels
{
    public class MoviesPageViewModel
    {
        public List<GenreViewModel> Genres { get; set; } = new();
        public List<VideoCardViewModel> SliderVideos { get; set; } = new();
        public List<VideoCardViewModel> PopularVideos { get; set; } = new();
        public List<VideoCardViewModel> TrendingVideos { get; set; } = new();
        public List<VideoCardViewModel> NewReleases { get; set; } = new();
        public List<VideoCardViewModel> WeeklyHits { get; set; } = new();
    }
}
