using StreamingService.DTO.ViewModels;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class MoviesService
    {
        private readonly MoviesRepository _repository;

        public MoviesService(MoviesRepository repository)
        {
            _repository = repository;
        }

        public Task<List<HeroItemViewModel>> GetHeroSlidersAsync(string locale)
        {
            return _repository.GetHeroSlidersAsync(locale);
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
