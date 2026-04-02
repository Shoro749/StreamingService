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

        public Task<List<HeroItemViewModel>> GetHeroSlidersAsync(string locale, int? userId = null)
        {
            return _repository.GetHeroSlidersAsync(locale, userId);
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

        public Task<Dictionary<string, List<VideoCardViewModel>>> GetUpcomingReleasesAsync(string locale, int? userId = null)
        {
            return _repository.GetUpcomingReleasesAsync(locale, userId);
        }

        public Task<List<GenreViewModel>> GetAllGenresAsync(string locale)
        {
            return _repository.GetAllGenresAsync(locale);
        }

        public Task<List<VideoCardViewModel>> GetVideosByGenresAsync(List<string> genreCodes, string locale, int? userId = null)
        {
            return _repository.GetVideosByGenresAsync(genreCodes, locale, userId);
        }

        public async Task<SearchResultsViewModel> SearchVideosAsync(string? query, int? genreId, string? sortBy, int page, int pageSize, string locale, int? userId)
        {
            return await _repository.SearchVideosAsync(query, genreId, sortBy, page, pageSize, locale, userId);
        }

        public async Task<List<string>> GetSearchSuggestionsAsync(string query, string locale, int limit)
        {
            return await _repository.GetSearchSuggestionsAsync(query, locale, limit);
        }
    }
}
