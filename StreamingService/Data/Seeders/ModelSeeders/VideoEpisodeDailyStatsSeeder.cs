using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoEpisodeDailyStatsSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (context.VideoEpisodeDailyStats.Any())
                return;

            //var stats = new[] { };

            //await context.VideoEpisodeDailyStats.AddRangeAsync(stats);
        }
    }
}