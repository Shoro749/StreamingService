using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoEpisodeTranslationSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (context.VideoEpisodeTranslations.Any())
                return;

            //var translations = new [] {};

            //await context.VideoEpisodeTranslations.AddRangeAsync(translations);
        }
    }
}