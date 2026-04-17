using StreamingService.DTO.ViewModels;
using StreamingService.Models;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class HistoryService
    {
        private readonly HistoryRepository _repository;
        private readonly MoviesRepository _moviesRepository;

        public HistoryService(HistoryRepository repository, MoviesRepository moviesRepository)
        {
            _repository = repository;
            _moviesRepository = moviesRepository;
        }

        public Task<UserEpisodesHistory?> GetContinueWatchingAsync(int userId)
        {
            return _repository.GetLatestAsync(userId);
        }

        public Task SaveWatchingProgressAsync(int userId, int episodeId, int currentTime)
        {
            return _repository.UpdatePausedTimeAsync(userId, episodeId, currentTime);
        }

        public async Task<List<HistoryItemViewModel>> GetUserHistoryAsync(int userId, string locale)
        {
            var histories = await _repository.GetAllHistoryAsync(userId);
            
            if (!histories.Any()) return new List<HistoryItemViewModel>();

            var videoIds = histories.Select(h => h.VideoEpisode.VideoSeason.VideoId).Distinct().ToList();

            var query = _moviesRepository.GetVideoProjections(locale, null, userId).Where(v => videoIds.Contains(v.Id));

            var videos = await _moviesRepository.GetVideosWithUserDataAsync(query, userId, locale);

            var result = histories.Select(h => 
            {
                var vid = videos.FirstOrDefault(v => v.Id == h.VideoEpisode.VideoSeason.VideoId);
                
                int percent = 0;
                if (h.IsFullyWatched) 
                {
                    percent = 100;
                }
                else if (h.VideoEpisode.Duration > 0)
                {
                    percent = (int)Math.Round((double)h.PausedWatchTime / h.VideoEpisode.Duration * 100);
                    if (percent > 100) percent = 100;
                }

                var dateStr = h.LastWatchedAt.ToLocalTime().ToString("dd MMMM, HH:mm", new System.Globalization.CultureInfo("uk-UA"));

                return new HistoryItemViewModel
                {
                    Video = vid,
                    ViewedDate = dateStr,
                    DeviceName = "Поточний пристрій",
                    ViewProgress = $"{percent}%"
                };
            })
            .Where(h => h.Video != null)
            .ToList();

            return result;
        }

        public async Task<bool> RemoveFromHistoryAsync(int userId, int videoId)
        {
            return await _repository.RemoveHistoryItemAsync(userId, videoId);
        }
    }
}
