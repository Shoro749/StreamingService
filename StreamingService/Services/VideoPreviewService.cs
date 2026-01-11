using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class VideoPreviewService
    {
        private readonly VideoRepository _videoRepository;
        public VideoPreviewService(VideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<VideoPreviewViewModel> GetVideoPreviewByIdAsync(string locale, int id)
        {
            return await _videoRepository.GetVideoPreviewByIdAsync(locale, id);
        }
    }
}
