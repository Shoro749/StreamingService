namespace StreamingService.DTO.ViewModels
{
    public class VideosPageViewModel
    {
        public List<VideoAdminViewModel> Videos { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Search { get; set; }
        public int? GenreId { get; set; }
    }
}
