using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoEpisodeTranslationSeeder
    {
        public static async Task<List<VideoEpisodeTranslation>?> SeedAsync(AppDbContext context, List<VideoEpisode>? videoEpisodes)
        {
            if (videoEpisodes == null)
                return null;

            if (context.VideoEpisodeTranslations.Any())
                return null;

            var translations = new List<VideoTranslation>
            {
               
            };
            throw new NotImplementedException("Seed data for VideoEpisodeTranslation is not implemented yet.");
            //await context.VideoEpisodeTranslations.AddRangeAsync(translations);
        }
    }
}