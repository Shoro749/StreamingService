using StreamingService.DTO.ViewModel;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class VideoService
    {
        private readonly VideoRepository _videoRepository;
        public VideoService(VideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<VideoPreviewViewModel> GetVideoPreviewByIdAsync(string locale, int id)
        {
            return await GetVideoPreviewByIdAsync(locale, id);
        }

    }
}
