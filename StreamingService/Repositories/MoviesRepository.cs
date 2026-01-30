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

                    ImageUrl = v.Images
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
