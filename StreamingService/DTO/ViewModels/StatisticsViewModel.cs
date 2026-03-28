namespace StreamingService.DTO.ViewModels
{
    public class StatisticsViewModel
    {
        public int TotalViews { get; set; }
        public int TotalVideos { get; set; }
        public int TotalGenres { get; set; }
        public List<GenreStatsViewModel> TopGenres { get; set; } = new();
    }
}
