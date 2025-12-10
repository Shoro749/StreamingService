using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoImageSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (context.VideoImages.Any())
                return;

            //var images = new[] { };

            //await context.VideoImages.AddRangeAsync(images);
        }
    }
}