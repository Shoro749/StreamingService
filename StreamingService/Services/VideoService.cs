using StreamingService.DTO.ViewModels;
using StreamingService.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace StreamingService.Services
{
    public class VideoService
    {
        private readonly VideoRepository _videoRepository;
        private readonly IConfiguration _configuration;

        public VideoService(VideoRepository videoRepository, IConfiguration configuration)
        {
            _videoRepository = videoRepository;
            _configuration = configuration;
        }

        public async Task<VideoWatchViewModel?> GetVideoForWatchAsync(
            int videoId,
            int seasonNumber,
            int episodeNumber,
            int userId,
            string locale)
        {
            var video = await _videoRepository.GetVideoWithDetailsAsync(videoId);
            if (video == null) return null;

            var season = video.Seasons.FirstOrDefault(s => s.NumberOfSeason == seasonNumber);
            if (season == null) return null;

            var episode = season.Episodes.FirstOrDefault(e => e.EpisodeNumber == episodeNumber);
            if (episode == null) return null;

            var progress = await _videoRepository.GetWatchProgressAsync(userId, episode.Id);

            var watchedEpisodeIds = await _videoRepository.GetWatchedEpisodeIdsAsync(userId, videoId);

            return new VideoWatchViewModel
            {
                VideoId = videoId,
                Title = video.Translations
                    .Where(t => t.LocaleCode == locale)
                    .Select(t => t.Title)
                    .FirstOrDefault() ?? video.Translations.FirstOrDefault()?.Title ?? "Без назви",

                Description = video.Translations
                    .Where(t => t.LocaleCode == locale)
                    .Select(t => t.Description)
                    .FirstOrDefault() ?? "",

                PosterUrl = video.Images
                    .Where(i => i.Type == "poster")
                    .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                    .FirstOrDefault() ?? "",

                CurrentSeason = seasonNumber,
                CurrentEpisode = episodeNumber,
                CurrentEpisodeId = episode.Id,

                Duration = episode.Duration,
                PausedWatchTime = progress?.PausedWatchTime ?? 0,

                Seasons = video.Seasons
                    .OrderBy(s => s.NumberOfSeason)
                    .Select(s => new SeasonViewModel
                    {
                        SeasonNumber = s.NumberOfSeason,
                        Episodes = s.Episodes
                            .OrderBy(e => e.EpisodeNumber)
                            .Select(e => new EpisodeViewModel
                            {
                                EpisodeId = e.Id,
                                EpisodeNumber = e.EpisodeNumber,
                                Duration = e.Duration,
                                Title = $"Епізод {e.EpisodeNumber}",
                                IsWatched = watchedEpisodeIds.Contains(e.Id)
                            })
                            .ToList()
                    })
                    .ToList(),

                Genres = video.GenreVideos
                    .Select(gv => gv.Genre.GenreTranslations
                        .Where(gt => gt.LocaleCode == locale)
                        .Select(gt => gt.Name)
                        .FirstOrDefault() ?? gv.Genre.Code)
                    .ToList()
            };
        }

        public async Task<bool> UpdateWatchProgressAsync(int userId, int episodeId, int currentTime, int duration)
        {
            return await _videoRepository.SaveWatchProgressAsync(userId, episodeId, currentTime);
        }

        public string GenerateSecureStreamUrl(int episodeId, int userId)
        {
            var expirationTime = DateTime.UtcNow.AddHours(1);
            var tokenData = $"{episodeId}|{userId}|{expirationTime:O}";

            var secretKey = _configuration["StreamingSecretKey"] ?? "your-secret-key-change-in-production";
            var token = GenerateToken(tokenData, secretKey);

            return $"/Video/Stream/{token}";
        }

        public StreamTokenData? ValidateStreamToken(string token)
        {
            try
            {
                var secretKey = _configuration["StreamingSecretKey"] ?? "your-secret-key-change-in-production";
                var tokenData = ValidateToken(token, secretKey);

                if (string.IsNullOrEmpty(tokenData)) return null;

                var parts = tokenData.Split('|');
                if (parts.Length != 3) return null;

                var episodeId = int.Parse(parts[0]);
                var userId = int.Parse(parts[1]);
                var expirationTime = DateTime.Parse(parts[2], null, System.Globalization.DateTimeStyles.RoundtripKind);

                if (DateTime.UtcNow > expirationTime) return null;

                return new StreamTokenData
                {
                    EpisodeId = episodeId,
                    UserId = userId,
                    ExpirationTime = expirationTime
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<string?> GetVideoFilePathAsync(int episodeId)
        {
            var episode = await _videoRepository.GetEpisodeByIdAsync(episodeId);
            if (episode == null) return null;

            // зробити ынтеграція з Blob Storage або локальне сховище
            var basePath = _configuration["VideoStoragePath"] ?? "wwwroot/videos";
            var videoPath = Path.Combine(
                basePath,
                $"video_{episode.VideoSeason.VideoId}_s{episode.VideoSeason.NumberOfSeason}_e{episode.EpisodeNumber}.mp4"
            );

            return videoPath;
        }

        private string GenerateToken(string data, string secretKey)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
            var dataBytes = Encoding.UTF8.GetBytes(data);
            var hash = hmac.ComputeHash(dataBytes);
            var combined = dataBytes.Concat(hash).ToArray();
            return Convert.ToBase64String(combined).Replace("+", "-").Replace("/", "_").Replace("=", "");
        }

        private string? ValidateToken(string token, string secretKey)
        {
            try
            {
                token = token.Replace("-", "+").Replace("_", "/");
                var padding = (4 - token.Length % 4) % 4;
                token += new string('=', padding);

                var combined = Convert.FromBase64String(token);
                var dataLength = combined.Length - 32;
                var dataBytes = combined.Take(dataLength).ToArray();
                var hash = combined.Skip(dataLength).ToArray();

                using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
                var expectedHash = hmac.ComputeHash(dataBytes);

                if (!hash.SequenceEqual(expectedHash)) return null;

                return Encoding.UTF8.GetString(dataBytes);
            }
            catch
            {
                return null;
            }
        }

        public class StreamTokenData
        {
            public int EpisodeId { get; set; }
            public int UserId { get; set; }
            public DateTime ExpirationTime { get; set; }
        }
    }
}
