using StreamingService.Models;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class HistoryService
    {
        private readonly HistoryRepository _repository;

        public HistoryService(HistoryRepository repository)
        {
            _repository = repository;
        }

        public Task<UserEpisodesHistory?> GetContinueWatchingAsync(int userId)
        {
            return _repository.GetLatestAsync(userId);
        }

        public Task SaveWatchingProgressAsync(int userId, int episodeId, int currentTime)
        {
            return _repository.UpdatePausedTimeAsync(userId, episodeId, currentTime);
        }
    }
}
