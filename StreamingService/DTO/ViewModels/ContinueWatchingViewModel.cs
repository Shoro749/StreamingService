namespace StreamingService.DTO.ViewModels;

public class ContinueWatchingViewModel
{
    public string Id { get; set; }
    public string EpisodeId { get; set; } = "";
    public string Title { get; set; } = "";
    public string Duration { get; set; } = "";
    public string ViewProgress { get; set; } = "";
    public string PosterUrl { get; set; } = "";

}
