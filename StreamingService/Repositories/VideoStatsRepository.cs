using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class VideoStatsRepository
    {
        private readonly AppDbContext _context;
        public VideoStatsRepository(AppDbContext context) => _context = context;

        public async Task<UserEpisodesHistory?> GetHistoryAsync(int profileId, int episodeId)
        {
            return await _context.UserEpisodesHistories
                .FirstOrDefaultAsync(h => h.UserProfileId == profileId && h.VideoEpisodeId == episodeId);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

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
