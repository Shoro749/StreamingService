namespace StreamingService.DTO.Requests
{
    public class SaveProgressRequest
    {
        public int EpisodeId { get; set; }
        public int CurrentTime { get; set; }
        public int Duration { get; set; }
        public bool IsFullyWatched { get; set; }
    }
}
