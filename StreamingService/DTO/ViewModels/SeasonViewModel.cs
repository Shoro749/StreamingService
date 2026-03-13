namespace StreamingService.DTO.ViewModels
{
    public class SeasonViewModel
    {
        public int? SeasonNumber { get; set; }
        public List<EpisodeViewModel> Episodes { get; set; } = new();
    }
}
