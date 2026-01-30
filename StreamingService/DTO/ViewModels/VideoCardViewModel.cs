using StreamingService.DTO.Enums;
namespace StreamingService.DTO.ViewModels
{
    public class VideoCardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public double Rating { get; set; }
        public string Year { get; set; } = "";
        public string Duration { get; set; } = "";
        public List<string> Genres { get; set; } = new();
        public bool IsFavorite { get; set; }
        public VideoType VideoType { get; set; }
    }
}
