using StreamingService.Models;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class VideoStatsService
    {
        private readonly VideoStatsRepository _repository;
        public VideoStatsService(VideoStatsRepository repository) => _repository = repository;

        public async Task<int> GetDailyViewsAsync(int episodeId)
        {
            return await _repository.GetEpisodeDailyViewsAsync(episodeId, DateTime.UtcNow);
        }

        public Task AddTimedLogAsync(int userId, int episodeId)
        {
            var log = new VideoEpisodeViewTimedLog
            {
                UserProfileId = userId,
                VideoEpisodeId = episodeId,
                CreateAt = DateTime.UtcNow
            };

            return _repository.AddViewLogAsync(log);
        }

        public async Task<List<VideoEpisodeDailyStats>> GetTopEpisodesAsync(int limit)
        {
            return await _repository.GetTopEpisodesAsync(limit);
        }
    }
}
