using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class VideoStatsRepository
    {
        private readonly AppDbContext _context;
        public VideoStatsRepository(AppDbContext context) => _context = context;

        public async Task<int> GetEpisodeDailyViewsAsync(int episodeId, DateTime date)
        {
            return await _context.VideoEpisodeDailyStats
                .Where(x => x.VideoEpisodeId == episodeId && x.Date == date.Date)
                .Select(x => x.TotalUserViews)
                .FirstOrDefaultAsync();
        }

        public async Task AddViewLogAsync(VideoEpisodeViewTimedLog log)
        {
            await _context.VideoEpisodeViewTimedLogs.AddAsync(log);
        }

        public async Task<List<VideoEpisodeDailyStats>> GetTopEpisodesAsync(int limit)
        {
            return await _context.VideoEpisodeDailyStats
                .Include(s => s.VideoEpisode)
                .OrderByDescending(s => s.TotalUserViews)
                .Take(limit)
                .ToListAsync();
        }
    }
}
