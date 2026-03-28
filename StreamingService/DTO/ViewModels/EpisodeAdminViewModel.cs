namespace StreamingService.DTO.ViewModels
{
    public class EpisodeAdminViewModel
    {
        public int Id { get; set; }
        public int EpisodeNumber { get; set; }
        public int Duration { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
