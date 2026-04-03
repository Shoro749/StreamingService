using StreamingService.DTO.ViewModels;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public static class SubscriptionLevel
    {
        public const int Basic = 1;
        public const int Standard = 2;
        public const int Premium = 3;
    }

    public class VideoService
    {
        private readonly VideoRepository _repo;

        public VideoService(VideoRepository repo)
        {
            _repo = repo;
        }

        public async Task<VideoViewModel?> GetPlaybackAsync(int userProfileId, int videoId, int? episodeId = null)
        {
            var subscription = await _repo.GetActiveSubscriptionWithLevelAsync(userProfileId);

            if (subscription == null) return null;

            int levelId = subscription.SubscriptionPlan.SubscriptionLevel.Id;

            var episode = episodeId.HasValue
                ? await _repo.GetEpisodeByIdAsync(episodeId.Value)
                : await _repo.GetFirstEpisodeAsync(videoId);

            if (episode == null)
                return null;
            var file = await _repo.GetVideoFileByEpisodeIdAsync(episode.Id);

            var episodeTitle = episode.VideoEpisodeTranslations
                .FirstOrDefault(t => t.LocaleCode == "uk")?.Title
                ?? episode.VideoEpisodeTranslations.FirstOrDefault()?.Title
                ?? $"Episode {episode.EpisodeNumber}";

            if (file == null)
            {
                // Контент вимагає вищого рівня підписки
                return null;
            }

            string streamUrl = BuildStreamUrl(file.BlobContainer, file.BlobPath);

            var progress = await _repo.GetViewProgressAsync(userProfileId, episode.Id);
            bool wasWatched = progress?.IsFullyWatched ?? false;

            // Навігація між серіями (тільки для серіалів)
            var video = await _repo.GetVideoByIdAsync(videoId);

            bool isMovie = !(video?.VideoType?.IndexOf("series", StringComparison.OrdinalIgnoreCase) >= 0);

            (int? prevId, int? nextId) = isMovie ? (null, null) : await GetAdjacentEpisodesAsync(episode, videoId);

            var title = video.Translations
                .FirstOrDefault(t => t.LocaleCode == "uk")?.Title
                ?? video.Translations.FirstOrDefault()?.Title
                ?? "";

            //string streamUrl = $"/videos/video_{videoId}_s{episode.VideoSeason.NumberOfSeason}_e{episode.EpisodeNumber}.mp4";

            string qualityLabel = levelId switch
            {
                SubscriptionLevel.Basic => "SD",
                SubscriptionLevel.Standard => "HD",
                SubscriptionLevel.Premium => "4K",
                _ => ""
            };

            return new VideoViewModel
            {
                VideoId = videoId,
                EpisodeId = episode.Id,
                EpisodeTitle = episodeTitle,
                VideoFileId = file.Id,
                VideoTitle = title,
                StreamUrl = streamUrl,
                WasWatched = wasWatched,
                IsMovie = isMovie,
                PrevEpisodeId = prevId,
                NextEpisodeId = nextId,
                SeasonNumber = episode.VideoSeason?.NumberOfSeason ?? 1,
                EpisodeNumber = episode.EpisodeNumber,
                QualityLabel = qualityLabel
            };
        }

        public async Task SaveProgressAsync(int userProfileId, int episodeId, bool isFullyWatched)
        {
            await _repo.SaveViewProgressAsync(userProfileId, episodeId, isFullyWatched);
        }

        private static string BuildStreamUrl(string? container, string? path)
        {
            if (string.IsNullOrEmpty(container) || string.IsNullOrEmpty(path))
                return "";

            if (container == "external")
                return path;

            return $"/{container}/{path}";
        }

        // Повертає Id попереднього і наступного епізоду в межах серіалу.
        private async Task<(int? prev, int? next)> GetAdjacentEpisodesAsync(StreamingService.Models.VideoEpisode current, int videoId)
        {
            var allEpisodes = await _repo.GetAllEpisodesOrderedAsync(videoId);

            var list = allEpisodes.ToList();
            int idx = list.FindIndex(e => e.Id == current.Id);

            int? prev = idx > 0 ? list[idx - 1].Id : null;
            int? next = idx < list.Count - 1 ? list[idx + 1].Id : null;

            return (prev, next);
        }
    }
}
