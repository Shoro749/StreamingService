using StreamingService.DTO.ViewModels;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class VideoDetailsService
    {
        private readonly VideoDetailsRepository _repository;

        public VideoDetailsService(VideoDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<VideoCardViewModel?> GetVideoDetailsAsync(int videoId, string locale, int? userId = null)
        {
            return await _repository.GetVideoDetailsByIdAsync(videoId, locale, userId);
        }

        public async Task<List<VideoCardViewModel>> GetRecommendedVideosAsync(int videoId, string locale, int count = 10)
        {
            return await _repository.GetRecommendedVideosAsync(videoId, locale, count);
        }
    }
}
