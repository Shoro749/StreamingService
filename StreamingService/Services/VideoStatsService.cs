using StreamingService.Models;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class VideoStatsService
    {
        private readonly VideoStatsRepository _repository;
        public VideoStatsService(VideoStatsRepository repository) => _repository = repository;

        public async Task<bool> UpdateWatchProgressAsync(int profileId, int episodeId, int currentTime, int totalDuration)
        {
            var history = await _repository.GetHistoryAsync(profileId, episodeId);

            if (history == null)
            {
                history = new UserEpisodesHistory
                {
                    UserProfileId = profileId,
                    VideoEpisodeId = episodeId
                };
            }

            history.PausedWatchTime = currentTime;
            history.LastWatchedAt = DateTime.UtcNow;

            history.IsFullyWatched = (totalDuration - currentTime) < 120;

            await _repository.AddViewLogAsync(new VideoEpisodeViewTimedLog
            {
                UserProfileId = profileId,
                VideoEpisodeId = episodeId,
                CreateAt = DateTime.UtcNow
            });

            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
