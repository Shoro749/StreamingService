using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoEpisodeDailyStatsSeeder
    {
        public static async Task<List<VideoEpisodeDailyStats>?> SeedAsync(AppDbContext context, List<VideoEpisode> videoEpisodes)
        {
            if (context.VideoEpisodeDailyStats.Any())
                return null;

            if (videoEpisodes == null || videoEpisodes.Count == 0)
                return null;

            var stats = new List<VideoEpisodeDailyStats>();
            var rand = new Random();

            var maxIndex = Math.Min(6, videoEpisodes.Count - 1);

            for (int i = 0; i <= maxIndex; i++)
            {
                var episode = videoEpisodes[i];

                for (int weekOffset = 0; weekOffset < 4; weekOffset++)
                {
                    var date = DateTime.UtcNow.Date.AddDays(7 * weekOffset);

                    stats.Add(new VideoEpisodeDailyStats
                    {
                        VideoEpisode = episode,
                        Date = date,
                        TotalUserViews = rand.Next(50, 1000)
                    });
                }
            }

            await context.VideoEpisodeDailyStats.AddRangeAsync(stats);
            await context.SaveChangesAsync();

            return stats;
        }
    }
}