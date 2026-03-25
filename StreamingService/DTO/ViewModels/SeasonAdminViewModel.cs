namespace StreamingService.DTO.ViewModels
{
    public class SeasonAdminViewModel
    {
        public int Id { get; set; }
        public int SeasonNumber { get; set; }
        public List<EpisodeAdminViewModel> Episodes { get; set; } = new();
    }
}
