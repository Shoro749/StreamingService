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

        public Task<List<VideoCardViewModel>> GetSliderAsync(string locale, int? userId = null)
        {
            return _repository.GetSliderVideosAsync(locale, userId);
        }

        public Task<List<VideoCardViewModel>> GetPopularAsync(string locale, int? userId = null)
        {
            return _repository.GetPopularVideosAsync(locale, userId);
        }

        public Task<List<VideoCardViewModel>> GetTrendingAsync(string locale, int? userId = null)
        {
            return _repository.GetTrendingVideosAsync(locale, userId);
        }

        public Task<List<VideoCardViewModel>> GetNewReleasesAsync(string locale, int? userId = null)
        {
            return _repository.GetNewReleasesVideosAsync(locale, userId);
        }

        public Task<List<VideoCardViewModel>> GetWeeklyHitsAsync(string locale, int? userId = null)
        {
            return _repository.GetWeeklyHitsVideosAsync(locale, userId);
        }

        public Task<List<VideoCardViewModel>> GetByGenreAsync(string genre, string locale, int? userId = null)
        {
            return _repository.GetVideosByGenreAsync(genre, locale, 20);
        }

        public Task<Dictionary<string, List<VideoCardViewModel>>> GetUpcomingReleasesAsync(string locale)
        {
            return _repository.GetUpcomingReleasesAsync(locale);
        }

        public Task<List<GenreViewModel>> GetAllGenresAsync(string locale)
        {
            return _repository.GetAllGenresAsync(locale);
        }

        public Task<List<VideoCardViewModel>> GetVideosByGenresAsync(List<string> genreCodes, string locale, int? userId = null)
        {
            return _repository.GetVideosByGenresAsync(genreCodes, locale, userId);
        }
    }
}
