namespace StreamingService.DTO.ViewModels
{
    public class VideoAdminViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string AgeRating { get; set; } = "";
        public double Rating { get; set; }
        public int SeasonsCount { get; set; }
        public int EpisodesCount { get; set; }
        public string PosterUrl { get; set; } = "";
        public List<string> Genres { get; set; } = new();
    }
}
