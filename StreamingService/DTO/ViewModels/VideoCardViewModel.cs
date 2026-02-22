using StreamingService.DTO.Enums;
namespace StreamingService.DTO.ViewModels
{
    public class VideoCardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string PosterUrl { get; set; } = "";// Вертикальний (для картки)
        public string BackdropUrl { get; set; } = "";    // Горизонтальний (для хіро/модалки)
        public string ThumbnailUrl { get; set; } = "";   // Маленький (для списків)
        public double Rating { get; set; }
        public string Year { get; set; } = "";
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; } = "";
        public string Duration { get; set; } = "";
        public string AgeRating { get; set; } = "";
        public string TrailerUrl { get; set; } = "";
        public string TrailerDuration { get; set; } = "";
        public List<string> Genres { get; set; } = new();
        public bool IsFavorite { get; set; }
        public bool IsSavedForLater { get; set; }
        public VideoType VideoType { get; set; }
        public List<ActorViewModel> Actors { get; set; } = new();
        public List<SceneViewModel> Scenes { get; set; } = new();
    }
}



