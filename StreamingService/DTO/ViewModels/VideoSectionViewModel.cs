namespace StreamingService.DTO.ViewModels
{
    public class VideoSectionViewModel
    {
        public string Title { get; set; } = "";
        public string SectionId { get; set; } = "";
        public string LinkUrl { get; set; } = "";
        public List<VideoCardViewModel> Videos { get; set; } = new();
    }
}
