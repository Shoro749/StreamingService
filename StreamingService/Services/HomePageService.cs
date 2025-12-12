using Microsoft.EntityFrameworkCore;
using StreamingService.Context;
using StreamingService.DTO;

namespace StreamingService.Services
{
    public class HomePageService
    {
        private readonly DataContext _context;

        public HomePageService()
        {
            _context = new DataContext();
        }

        private IQueryable<VideoCardViewModel> ProjectVideos(string locale)
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

        // 10 відео з найбільшим рейтингом
        public async Task<List<VideoCardViewModel>> GetSliderAsync(string locale)
        {
            var videoIds = await _context.Videos
                .OrderByDescending(v => v.RatingCount)
                .Take(10)
                .Select(v => v.Id)
                .ToListAsync();

            return await ProjectVideos(locale)
                .Where(v => videoIds.Contains(v.Id))
                .ToListAsync();
        }

        // 20 відео з найбільшою сумою рейтингів
        public async Task<List<VideoCardViewModel>> GetPopularAsync(string locale)
        {
            var videoIds = await _context.Videos
                .OrderByDescending(v => v.RatingSum)
                .Take(20)
                .Select(v => v.Id)
                .ToListAsync();

            return await ProjectVideos(locale)
                .Where(v => videoIds.Contains(v.Id))
                .ToListAsync();
        }

        // трендові відео за останні 7 днів
        public async Task<List<VideoCardViewModel>> GetTrendingAsync(string locale)
        {
            var sevenDaysAgo = DateTime.UtcNow.Date.AddDays(-7);

            var videoIds = await _context.VideoEpisodeDailyStats
                .Where(s => s.Date >= sevenDaysAgo)
                .GroupBy(s => s.VideoEpisode.VideoSeason.VideoId)
                .OrderByDescending(g => g.Sum(x => x.TotalUserViews))
                .Take(20)
                .Select(g => g.Key)
                .ToListAsync();

            return await ProjectVideos(locale)
                .Where(v => videoIds.Contains(v.Id))
                .ToListAsync();
        }

        // нові релізи з таблиці VideoEpisodes
        public async Task<List<VideoCardViewModel>> GetNewReleasesAsync(string locale)
        {
            var videoIds = await _context.VideoEpisodes
                .OrderByDescending(e => e.ReleaseDate)
                .Take(50)
                .Select(e => e.VideoSeason.VideoId)
                .Distinct()
                .Take(20)
                .ToListAsync();

            return await ProjectVideos(locale)
                .Where(v => videoIds.Contains(v.Id))
                .ToListAsync();
        }

        // хіти тижня на основі історії переглядів користувачів
        public async Task<List<VideoCardViewModel>> GetWeeklyHitsAsync(string locale)
        {
            var sevenDaysAgo = DateTime.UtcNow.AddDays(-7);

            var videoIds = await _context.UserEpisodesHistories
                .Where(h => h.LastWatchedAt >= sevenDaysAgo)
                .GroupBy(h => h.VideoEpisode.VideoSeason.VideoId)
                .OrderByDescending(g => g.Count())
                .Take(20)
                .Select(g => g.Key)
                .ToListAsync();

            return await ProjectVideos(locale)
                .Where(v => videoIds.Contains(v.Id))
                .ToListAsync();
        }
    }
}
