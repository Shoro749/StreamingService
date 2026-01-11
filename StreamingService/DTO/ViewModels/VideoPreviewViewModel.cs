namespace StreamingService.DTO.ViewModel
{
    public class VideoPreviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public int Duration { get; set; } //in minutes
        public DateOnly ReleaseDate { get; set; }
        public bool IsFavorite { get; set; }
        public List<string> Genres { get; set; }
        public List<PersonVideoPreviewVideoModel> Actors { get; set; }
    }
}
