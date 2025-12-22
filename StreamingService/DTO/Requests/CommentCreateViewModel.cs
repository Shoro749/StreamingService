namespace StreamingService.DTO.Requests
{
    public class CommentCreateViewModel
    {
        public int UserProfileId { get; set; }
        public int VideoId { get; set; }
        public string Text { get; set; } = string.Empty;
        public int? ParentId { get; set; }
    }
}
