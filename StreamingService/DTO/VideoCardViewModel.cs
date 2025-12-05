namespace StreamingService.DTO
{
    public class VideoCardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public double Rating { get; set; }
        public List<string> Genres { get; set; }
    }
}
