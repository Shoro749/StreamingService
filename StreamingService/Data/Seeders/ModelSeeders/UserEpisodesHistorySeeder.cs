using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class UserEpisodesHistorySeeder
    {
        public static async Task<List<UserEpisodesHistory>?> SeedAsync(AppDbContext context, List<UserProfile>? users, List<VideoEpisode>? videoEpisodes)
        {
            if (users == null || videoEpisodes == null)
                return null;

            if (context.UserEpisodesHistories.Any())
                return null;

            var userEpisodesHistory = new List<UserEpisodesHistory>
            {
                new UserEpisodesHistory
                {
                    UserProfile = users[0],
                    VideoEpisode = videoEpisodes[0],
                    PausedWatchTime = 3600,
                    LastWatchedAt = DateTime.UtcNow.AddDays(-5),
                    IsFullyWatched = true
                },
                new UserEpisodesHistory
                {
                    UserProfile = users[1],
                    VideoEpisode = videoEpisodes[0],
                    PausedWatchTime = 1800,
                    LastWatchedAt = DateTime.UtcNow.AddDays(-4),
                    IsFullyWatched = false
                },

                new UserEpisodesHistory
                {
                    UserProfile = users[0],
                    VideoEpisode = videoEpisodes[4],
                    PausedWatchTime = 1200,
                    LastWatchedAt = DateTime.UtcNow.AddDays(-3),
                    IsFullyWatched = false
                },
                new UserEpisodesHistory
                {
                    UserProfile = users[2],
                    VideoEpisode = videoEpisodes[5],
                    PausedWatchTime = 2400,
                    LastWatchedAt = DateTime.UtcNow.AddDays(-2),
                    IsFullyWatched = true
                },

                new UserEpisodesHistory
                {
                    UserProfile = users[4],
                    VideoEpisode = videoEpisodes[6],
                    PausedWatchTime = 600,
                    LastWatchedAt = DateTime.UtcNow.AddDays(-1),
                    IsFullyWatched = false
                }
            };


            await context.UserEpisodesHistories.AddRangeAsync(userEpisodesHistory);
            await context.SaveChangesAsync();

            return userEpisodesHistory;
        }
    }
}

