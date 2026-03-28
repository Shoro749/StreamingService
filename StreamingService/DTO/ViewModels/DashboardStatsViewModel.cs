namespace StreamingService.DTO.ViewModels
{
    public class DashboardStatsViewModel
    {
        public int TotalVideos { get; set; }
        public int TotalUsers { get; set; }
        public int ActiveSubscriptions { get; set; }
        public int Last30DaysViews { get; set; }
        public List<VideoSummaryViewModel> RecentVideos { get; set; } = new();
    }
}
