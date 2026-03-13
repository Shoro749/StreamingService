namespace StreamingService.DTO.ViewModels
{
    public class VideoWatchViewModel
    {
        public int VideoId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string PosterUrl { get; set; } = "";
        
        public int CurrentSeason { get; set; }
        public int CurrentEpisode { get; set; }
        public int CurrentEpisodeId { get; set; }
        
        public int Duration { get; set; } // В секундах
        public int PausedWatchTime { get; set; } // В секундах
        
        public List<SeasonViewModel> Seasons { get; set; } = new();
        public List<string> Genres { get; set; } = new();
    }
}
