using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoEpisodeViewTimedLogSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (context.VideoEpisodeViewTimedLogs.Any())
                return;

            //var logs = new[] {};

            //await context.VideoEpisodeViewTimedLogs.AddRangeAsync(logs);
        }
    }
}