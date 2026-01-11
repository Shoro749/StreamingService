using Microsoft.IdentityModel.Tokens;
using StreamingService.Models;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class VideoAccessService
    {
        private readonly IRepository<Video> _videoRepository;
        private readonly IRepository<VideoEpisode> _videoEpisodeRepository;
        private readonly UserSubscriptionRepository _userSubscriptionRepository;
        public VideoAccessService(
            EFRepository<Video> videoRepository,
            EFRepository<VideoEpisode> videoEpisodeRepository,
            UserSubscriptionRepository userSubscriptionRepository)
        {
            _videoRepository = videoRepository;
            _videoEpisodeRepository = videoEpisodeRepository;
            _userSubscriptionRepository = userSubscriptionRepository;
        }
        public async Task<bool> IsCanWatchEpisodeAsync(int episodeId, int userId)
        {
            var videoId = _videoEpisodeRepository
                .GetDataAsync(episodeId)
                .Result.VideoSeason.Video.Id;

            //return await IsCanWathingByVideoIdAsync(videoId, userId);
            return true;
        }
        public async Task<bool> IsCanWatchVideoAsync(int videoId, int userId)
        {
            var userSubscription = await _userSubscriptionRepository.GetActiveDataByUserIdAsync(userId);

            if (userSubscription.IsNullOrEmpty()) return false;

            var video = await _videoRepository.GetDataAsync(videoId);

            if (video == null) return false;

            return userSubscription.Any(us => us.SubscriptionPlan.SubscriptionLevel.Code == video.SubscriptionLevel.Code);
        }
    }
}
