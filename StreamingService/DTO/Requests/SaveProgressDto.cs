namespace StreamingService.DTO.Requests
{
    public class SaveProgressDto
    {
        public int UserId { get; set; }
        public int EpisodeId { get; set; }
        public int PausedTime { get; set; }
    }
}
