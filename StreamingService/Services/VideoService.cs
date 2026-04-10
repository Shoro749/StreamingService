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

        public async Task<VideoViewModel?> GetPlaybackAsync(int userProfileId, int videoId, int? episodeId = null, bool isTrailer = false)
        {
            var subscription = await _repo.GetActiveSubscriptionWithLevelAsync(userProfileId);
            if (subscription == null) return null;

            var video = await _repo.GetVideoByIdAsync(videoId);
            if (video == null) return null;

            bool isMovie = !(video.VideoType?.IndexOf("series", StringComparison.OrdinalIgnoreCase) >= 0);
            
            var title = video.Translations
                .FirstOrDefault(t => t.LocaleCode == "uk")?.Title
                ?? video.Translations.FirstOrDefault()?.Title
                ?? "";

            if (isTrailer)
            {
                return new VideoViewModel
                {
                    VideoId = videoId,
                    VideoTitle = title,
                    IsMovie = isMovie,
                    IsTrailer = true,
                    TrailerUrl = ConvertToEmbedUrl(video.Trailerurl)
                };
            }

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

            //string streamUrl = BuildStreamUrl(file.BlobContainer, file.BlobPath);
            string streamUrl = file.BlobPath;

            var progress = await _repo.GetViewProgressAsync(userProfileId, episode.Id);
            bool wasWatched = progress?.IsFullyWatched ?? false;
            // Додаємо зчитування стартового часу (якщо не був повністю додивлений)
            double startFrom = (!wasWatched && progress != null) ? progress.PausedWatchTime : 0;
            
            (int? prevId, int? nextId) = isMovie ? (null, null) : await GetAdjacentEpisodesAsync(episode, videoId);

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
                StartFrom = startFrom,
                IsMovie = isMovie,
                PrevEpisodeId = prevId,
                NextEpisodeId = nextId,
                SeasonNumber = episode.VideoSeason?.NumberOfSeason ?? 1,
                EpisodeNumber = episode.EpisodeNumber,
                QualityLabel = qualityLabel,
                IsTrailer = false
            };
        }

        public async Task SaveProgressAsync(int userProfileId, int episodeId, bool isFullyWatched, int currentTime)
        {
            await _repo.SaveViewProgressAsync(userProfileId, episodeId, isFullyWatched, currentTime);
        }

        public async Task<Models.UserEpisodesHistory?> GetProgressAsync(int userProfileId, int episodeId)
        {
            return await _repo.GetViewProgressAsync(userProfileId, episodeId);
        }

        private static string BuildStreamUrl(string? container, string? path)
        {
            if (string.IsNullOrEmpty(container) || string.IsNullOrEmpty(path))
                return "";

            if (container == "external")
                return path;

            return $"/{container}/{path}";
        }

        // Допоміжний метод для YouTube посилань
        private static string? ConvertToEmbedUrl(string? url)
        {
            if (string.IsNullOrEmpty(url)) return null;

            if (url.Contains("youtube.com/watch?v="))
            {
                var videoId = url.Split("v=")[1].Split('&')[0];
                return $"https://www.youtube.com/embed/{videoId}?autoplay=1";
            }
            if (url.Contains("youtu.be/"))
            {
                var videoId = url.Split("youtu.be/")[1].Split('?')[0];
                return $"https://www.youtube.com/embed/{videoId}?autoplay=1";
            }
            
            return url;
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
