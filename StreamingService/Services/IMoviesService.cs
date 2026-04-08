using StreamingService.DTO.ViewModels;

namespace StreamingService.Services;

public interface IMoviesService
{
    Task<List<HeroItemViewModel>> GetHeroSlidersAsync(string locale, int? userId = null);
    Task<List<VideoCardViewModel>> GetSliderAsync(string locale, int? userId = null);
    Task<List<VideoCardViewModel>> GetPopularAsync(string locale, int? userId = null);
    Task<List<VideoCardViewModel>> GetTrendingAsync(string locale, int? userId = null);
    Task<List<VideoCardViewModel>> GetNewReleasesAsync(string locale, int? userId = null);
    Task<List<VideoCardViewModel>> GetWeeklyHitsAsync(string locale, int? userId = null);
    Task<List<VideoCardViewModel>> GetByGenreAsync(string genre, string locale, int? userId = null);
    Task<Dictionary<string, List<VideoCardViewModel>>> GetUpcomingReleasesAsync(string locale);
    Task<List<GenreViewModel>> GetAllGenresAsync(string locale);
    Task<List<VideoCardViewModel>> GetVideosByGenresAsync(List<string> genreCodes, string locale, int? userId = null);
    Task<SearchResultsViewModel> SearchVideosAsync(string? query, int? genreId, string? sortBy, int page, int pageSize, string locale, int? userId);
    Task<List<string>> GetSearchSuggestionsAsync(string query, string locale, int limit);
}
