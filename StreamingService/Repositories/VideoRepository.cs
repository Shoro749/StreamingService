using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class VideoRepository
    {
        private readonly AppDbContext _context;

        public VideoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VideoFile?> GetVideoFileByEpisodeIdAsync(int episodeId)
        {
            return await _context.VideoFiles
                .Where(f => f.VideoEpisodesId == episodeId)
                .FirstOrDefaultAsync();
        }

        public async Task<VideoEpisode?> GetFirstEpisodeAsync(int videoId)
        {
            return await _context.VideoSeasons
                .Where(s => s.VideoId == videoId)
                .OrderBy(s => s.NumberOfSeason)
                .SelectMany(s => s.Episodes)
                .OrderBy(e => e.EpisodeNumber)
                .FirstOrDefaultAsync();
        }

        public async Task<VideoEpisode?> GetEpisodeByIdAsync(int episodeId)
        {
            return await _context.VideoEpisode
                .Include(e => e.VideoSeason)
                .Include(e => e.VideoEpisodeTranslations)
                .FirstOrDefaultAsync(e => e.Id == episodeId);
        }

        public async Task<IEnumerable<VideoEpisode>> GetAllEpisodesOrderedAsync(int videoId)
        {
            return await _context.VideoSeasons
                .Where(s => s.VideoId == videoId)
                .OrderBy(s => s.NumberOfSeason)
                .SelectMany(s => s.Episodes)
                .OrderBy(e => e.EpisodeNumber)
                .ToListAsync();
        }

        public async Task<UserSubscription?> GetActiveSubscriptionWithLevelAsync(int userProfileId)
        {
            var now = DateTime.UtcNow;
            return await _context.UsersSubscriptions
                .Include(s => s.SubscriptionPlan)
                    .ThenInclude(p => p.SubscriptionLevel)
                .Where(s => s.UserProfileId == userProfileId
                            && s.Status == "Active"
                            && s.SubscriptionEnd > now)
                .OrderByDescending(s => s.SubscriptionEnd)
                .FirstOrDefaultAsync();
        }

        public async Task<Video?> GetVideoByIdAsync(int videoId)
        {
            return await _context.Videos
                .Include(v => v.SubscriptionLevel)
                .Include(v => v.Translations)
                .FirstOrDefaultAsync(v => v.Id == videoId);
        }

        public async Task SaveViewProgressAsync(int userProfileId, int episodeId, bool isFullyWatched)
        {
            var existing = await _context.UserEpisodesHistories
                .FirstOrDefaultAsync(h => h.UserProfileId == userProfileId
                                          && h.VideoEpisodeId == episodeId);
            if (existing == null)
            {
                _context.UserEpisodesHistories.Add(new UserEpisodesHistory
                {
                    UserProfileId = userProfileId,
                    VideoEpisodeId = episodeId,
                    LastWatchedAt = DateTime.UtcNow,
                    IsFullyWatched = isFullyWatched,
                });
            }
            else
            {
                existing.LastWatchedAt = DateTime.UtcNow;
                existing.IsFullyWatched = isFullyWatched;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<UserEpisodesHistory?> GetViewProgressAsync(int userProfileId, int episodeId)
        {
            return await _context.UserEpisodesHistories.FirstOrDefaultAsync(h => h.UserProfileId == userProfileId && h.VideoEpisodeId == episodeId);
        }
    }
}
