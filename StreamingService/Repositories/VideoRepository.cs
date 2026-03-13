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

        public async Task<Video?> GetVideoWithDetailsAsync(int videoId)
        {
            return await _context.Videos
                .Include(v => v.Translations)
                .Include(v => v.Seasons)
                    .ThenInclude(s => s.Episodes)
                .Include(v => v.Images)
                .Include(v => v.GenreVideos)
                    .ThenInclude(gv => gv.Genre)
                        .ThenInclude(g => g.GenreTranslations)
                .FirstOrDefaultAsync(v => v.Id == videoId);
        }

        public async Task<VideoEpisode?> GetEpisodeAsync(int videoId, int seasonNumber, int episodeNumber)
        {
            return await _context.VideoEpisode
                .Include(e => e.VideoSeason)
                .Where(e => e.VideoSeason.VideoId == videoId
                    && e.VideoSeason.NumberOfSeason == seasonNumber
                    && e.EpisodeNumber == episodeNumber)
                .FirstOrDefaultAsync();
        }

        public async Task<VideoEpisode?> GetEpisodeByIdAsync(int episodeId)
        {
            return await _context.VideoEpisode
                .Include(e => e.VideoSeason)
                    .ThenInclude(s => s.Video)
                .FirstOrDefaultAsync(e => e.Id == episodeId);
        }

        public async Task<UserEpisodesHistory?> GetWatchProgressAsync(int userId, int episodeId)
        {
            return await _context.UserEpisodesHistories
                .FirstOrDefaultAsync(h => h.UserProfileId == userId && h.VideoEpisodeId == episodeId);
        }

        public async Task<bool> SaveWatchProgressAsync(int userId, int episodeId, int currentTime)
        {
            try
            {
                var history = await GetWatchProgressAsync(userId, episodeId);

                if (history == null)
                {
                    history = new UserEpisodesHistory
                    {
                        UserProfileId = userId,
                        VideoEpisodeId = episodeId,
                        PausedWatchTime = currentTime,
                        LastWatchedAt = DateTime.UtcNow
                    };
                    _context.UserEpisodesHistories.Add(history);
                }
                else
                {
                    history.PausedWatchTime = currentTime;
                    history.LastWatchedAt = DateTime.UtcNow;
                    _context.UserEpisodesHistories.Update(history);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> IsEpisodeWatchedAsync(int userId, int episodeId)
        {
            return await _context.UserEpisodesHistories
                .AnyAsync(h => h.UserProfileId == userId && h.VideoEpisodeId == episodeId);
        }

        public async Task<List<int>> GetWatchedEpisodeIdsAsync(int userId, int videoId)
        {
            return await _context.UserEpisodesHistories
                .Where(h => h.UserProfileId == userId
                    && h.VideoEpisode.VideoSeason.VideoId == videoId)
                .Select(h => h.VideoEpisodeId)
                .ToListAsync();
        }
    }
}
