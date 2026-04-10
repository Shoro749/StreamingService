namespace StreamingService.DTO.ViewModels
{
    public class VideoViewModel
    {
        public int VideoId { get; set; }
        public int EpisodeId { get; set; }
        public int VideoFileId { get; set; }
        public string VideoTitle { get; set; } = "";
        public string EpisodeTitle { get; set; } = "";
        public string StreamUrl { get; set; } = "";  // BlobContainer + BlobPath
        public bool WasWatched { get; set; }
        public double StartFrom { get; set; }        // збережений прогрес у секундах
        public bool IsMovie { get; set; }

        // Для серіалів — навігація між серіями
        public int? PrevEpisodeId { get; set; }
        public int? NextEpisodeId { get; set; }
        public int SeasonNumber { get; set; }
        public int? EpisodeNumber { get; set; }

        public string QualityLabel { get; set; } = "";

        public bool IsTrailer { get; set; }
        public string? TrailerUrl { get; set; }
    }
}
