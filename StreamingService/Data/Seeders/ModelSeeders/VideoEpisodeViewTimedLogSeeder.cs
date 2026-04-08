using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoEpisodeViewTimedLogSeeder
    {
        public static async Task<List<VideoEpisodeViewTimedLog>?> SeedAsync(AppDbContext context, List<UserProfile>? users, List<VideoEpisode>? videoEpisodes)
        {
            if (users == null || videoEpisodes == null)
                return null;

            if (context.VideoEpisodeViewTimedLogs.Any())
                return null;

            var rand = new Random();
            var logs = new List<VideoEpisodeViewTimedLog>();

            var episodeCount = Math.Min(videoEpisodes.Count, 10);

            var maxUsersPerEpisode = Math.Min(users.Count, 5);

            for (int ei = 0; ei < episodeCount; ei++)
            {
                var episode = videoEpisodes[ei];

                var usersForEpisodeCount = rand.Next(1, maxUsersPerEpisode + 1);

                var usersForEpisode = users
                    .OrderBy(_ => rand.Next())
                    .Take(usersForEpisodeCount)
                    .ToList();

                foreach (var user in usersForEpisode)
                {
                    var logsPerUser = rand.Next(1, 4);

                    var baseDate = DateTime.UtcNow.Date.AddDays(-rand.Next(0, 28))
                        .AddHours(rand.Next(0, 24))
                        .AddMinutes(rand.Next(0, 60))
                        .AddSeconds(rand.Next(0, 60));

                    for (int li = 0; li < logsPerUser; li++)
                    {
                        var offsetMinutes = li * rand.Next(1, 21);
                        var createAt = baseDate.AddMinutes(offsetMinutes);

                        var log = new VideoEpisodeViewTimedLog
                        {
                            CreateAt = createAt,
                            UserProfileId = user.Id,
                            VideoEpisode = episode
                        };

                        logs.Add(log);
                        context.VideoEpisodeViewTimedLogs.Add(log);
                    }
                }
            }

            if (logs.Any())
                await context.SaveChangesAsync();

            return logs;
        }
    }
}