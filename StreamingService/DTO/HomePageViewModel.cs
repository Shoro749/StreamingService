namespace StreamingService.DTO
{
    public class HomePageViewModel
    {
        public List<VideoCardViewModel> Slider { get; set; }
        public List<VideoCardViewModel> Popular { get; set; }
        public List<VideoCardViewModel> Trending { get; set; }
        public List<VideoCardViewModel> NewReleases { get; set; }
        public List<VideoCardViewModel> WeeklyHits { get; set; }
    }
}
