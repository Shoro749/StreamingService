namespace StreamingService.DTO.ViewModels
{
    public class EpisodeViewModel
    {
        public int EpisodeId { get; set; }
        public int? EpisodeNumber { get; set; }
        public string Title { get; set; } = "";
        public int Duration { get; set; }
        public bool IsWatched { get; set; }
    }
}
