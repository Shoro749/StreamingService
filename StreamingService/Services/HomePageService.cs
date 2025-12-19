using StreamingService.DTO.ViewModels;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class HomePageService
    {
        private readonly HomeRepository _repository;

        public HomePageService(HomeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<VideoCardViewModel>> GetSliderAsync(string locale)
        {
            return _repository.GetSliderVideosAsync(locale);
        }

        public Task<List<VideoCardViewModel>> GetPopularAsync(string locale)
        {
            return _repository.GetPopularVideosAsync(locale);
        }

        public Task<List<VideoCardViewModel>> GetTrendingAsync(string locale)
        {
            return _repository.GetTrendingVideosAsync(locale);
        }

        public Task<List<VideoCardViewModel>> GetNewReleasesAsync(string locale)
        {
            return _repository.GetNewReleasesVideosAsync(locale);
        }

        public Task<List<VideoCardViewModel>> GetWeeklyHitsAsync(string locale)
        {
            return _repository.GetWeeklyHitsVideosAsync(locale);
        }
    }
}
