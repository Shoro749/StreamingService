using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.DTO.ViewModels;

namespace StreamingService.Repositories
{
    public class MoviesRepository
    {
        private readonly AppDbContext _context;
        public MoviesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<HeroItemViewModel>> GetHeroSlidersAsync(string locale)
        {
            return await _context.Videos
                .Where(v => v.Seasons.Any(s => s.Episodes.Any()))
                .OrderByDescending(v => v.RatingSum / (v.RatingCount == 0 ? 1 : v.RatingCount))
                .Take(5)
                .Select(v => new HeroItemViewModel
                {
                    Id = v.Id,

                    Title = v.Translations
                        .Where(t => t.LocaleCode == locale)
                        .Select(t => t.Title)
                        .FirstOrDefault() ?? "Без назви",

                    ImageUrl = v.Images
                        .Where(i => i.Type == "banner" || i.Type == "backdrop")
                        .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                        .FirstOrDefault() ?? "/images/placeholder-banner.jpg",

                    Duration = v.Seasons
                        .OrderBy(s => s.NumberOfSeason)
                        .SelectMany(s => s.Episodes)
                        .OrderBy(e => e.EpisodeNumber)
                        .Select(e => e.Duration > 0 ? $"{e.Duration} хвилин" : "")
                        .FirstOrDefault() ?? "",

                    Year = v.Seasons
                        .OrderBy(s => s.NumberOfSeason)
                        .SelectMany(s => s.Episodes)
                        .Where(e => e.ReleaseDate != default(DateOnly))
                        .OrderBy(e => e.ReleaseDate)
                        .Select(e => e.ReleaseDate.Year)
                        .FirstOrDefault(),

                    AgeRating = /*v.AgeRating ??*/ "0+",

                    Genres = v.GenreVideos
                        .Select(gv => gv.Genre.GenreTranslations
                        .Where(gt => gt.LocaleCode == locale)
                        .Select(gt => gt.Name)
                        .FirstOrDefault())
                        .Where(name => !string.IsNullOrEmpty(name))
                        .ToList(),

                    TrailerUrl = "#",
                    TrailerDuration = "2:30",
                    IsFavorite = false
                })
                .ToListAsync();
        }

        public IQueryable<VideoCardViewModel> GetVideoProjections(string locale)
        {
            return _context.Videos
                .Select(v => new VideoCardViewModel
                {
                    Id = v.Id,

                    Title = v.Translations
                        .Where(t => t.LocaleCode == locale)
                        .Select(t => t.Title)
                        .FirstOrDefault(),

                    PosterUrl = v.Images
                        .Where(i => i.Type == "poster")
                        .Select(i => i.BlobContainer + "/" + i.BlobPath)
                        .FirstOrDefault(),

                    Rating = v.RatingCount == 0
                        ? 0
                        : (double)v.RatingSum / v.RatingCount,

                    Genres = v.GenreVideos
                        .Select(g => g.Genre.GenreTranslations
                            .Where(t => t.LocaleCode == locale)
                            .Select(t => t.Name)
                            .FirstOrDefault())
                        .ToList()
                });
        }

        public async Task<List<VideoCardViewModel>> GetSliderVideosAsync(string locale)
        {
            return await GetVideoProjections(locale)
                .OrderByDescending(v => v.Rating)
                .Take(10)
                .ToListAsync();
        }

        public async Task<List<VideoCardViewModel>> GetPopularVideosAsync(string locale)
        {
            return await GetVideoProjections(locale)
                .OrderByDescending(v => v.Rating)
                .Take(20)
                .ToListAsync();
        }

        public async Task<List<VideoCardViewModel>> GetTrendingVideosAsync(string locale)
        {
            var sevenDaysAgo = DateTime.UtcNow.Date.AddDays(-7);

            var videoIds = await _context.VideoEpisodeDailyStats
                .Where(s => s.Date >= sevenDaysAgo)
                .GroupBy(s => s.VideoEpisode.VideoSeason.VideoId)
                .OrderByDescending(g => g.Sum(x => x.TotalUserViews))
                .Take(20)
                .Select(g => g.Key)
                .ToListAsync();

            return await GetVideoProjections(locale)
                .Where(v => videoIds.Contains(v.Id))
                .ToListAsync();
        }


        public async Task<List<VideoCardViewModel>> GetNewReleasesVideosAsync(string locale)
        {
            var videoIds = await _context.VideoEpisode
                .OrderByDescending(e => e.ReleaseDate)
                .Take(50)
                .Select(e => e.VideoSeason.VideoId)
                .Distinct()
                .Take(20)
                .ToListAsync();

            return await GetVideoProjections(locale)
                .Where(v => videoIds.Contains(v.Id))
                .ToListAsync();
        }

        public async Task<List<VideoCardViewModel>> GetWeeklyHitsVideosAsync(string locale)
        {
            var sevenDaysAgo = DateTime.UtcNow.AddDays(-7);

            var videoIds = await _context.UserEpisodesHistories
                .Where(h => h.LastWatchedAt >= sevenDaysAgo)
                .GroupBy(h => h.VideoEpisode.VideoSeason.VideoId)
                .OrderByDescending(g => g.Count())
                .Take(20)
                .Select(g => g.Key)
                .ToListAsync();

            return await GetVideoProjections(locale)
                .Where(v => videoIds.Contains(v.Id))
                .ToListAsync();
        }
    }
}
