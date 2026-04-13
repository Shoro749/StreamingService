using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class HistoryRepository
    {
        private readonly AppDbContext _context;

        public HistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserEpisodesHistory?> GetLatestAsync(int userId)
        {
            return await _context.UserEpisodesHistories
                .Include(x => x.VideoEpisode)
                    .ThenInclude(e => e.VideoSeason)
                        .ThenInclude(s => s.Video)
                            .ThenInclude(v => v.Translations)
                .Include(x => x.VideoEpisode)
                    .ThenInclude(e => e.VideoSeason)
                        .ThenInclude(s => s.Video)
                            .ThenInclude(v => v.Images)
                .Where(x => x.UserProfileId == userId)
                .OrderByDescending(x => x.LastWatchedAt)
                .FirstOrDefaultAsync();
        }

        public async Task UpdatePausedTimeAsync(int userId, int episodeId, int pausedTime)
        {
            var entry = await _context.UserEpisodesHistories
                .FirstOrDefaultAsync(x =>
                    x.UserProfileId == userId &&
                    x.VideoEpisodeId == episodeId);

            if (entry == null)
            {
                entry = new UserEpisodesHistory()
                {
                    UserProfileId = userId,
                    VideoEpisodeId = episodeId,
                    PausedWatchTime = pausedTime,
                    LastWatchedAt = DateTime.UtcNow
                };
                _context.UserEpisodesHistories.Add(entry);
            }
            else
            {
                entry.PausedWatchTime = pausedTime;
                entry.LastWatchedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }
    }
}
