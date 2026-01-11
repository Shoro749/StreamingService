namespace StreamingService.DTO.ViewModels
{
    public class EpisodeViewModel
    {
        public int Id { get; set; }
        public int? Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
    }
}
