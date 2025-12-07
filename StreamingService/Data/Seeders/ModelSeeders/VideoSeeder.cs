using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoSeeder
    {
        public static async Task<List<Video>?> SeedAsync(AppDbContext context, List<SubscriptionLevel>? subscriptionLevels)
        {
            if (subscriptionLevels == null)
                return null;

            if (context.Videos.Any())
                return null;

            var videos = new List<Video>
            {
                new Video
                {
                    RatingCount = 0,
                    RatingSum = 0,
                    SubscriptionLevel = subscriptionLevels[0]
                },
                new Video
                {
                    RatingCount = 0,
                    RatingSum = 0,
                    SubscriptionLevel = subscriptionLevels[1]
                },
                new Video
                {
                    RatingCount = 0,
                    RatingSum = 0,
                    SubscriptionLevel = subscriptionLevels[0]
                },
                new Video
                {
                    RatingCount = 0,
                    RatingSum = 0,
                    SubscriptionLevel = subscriptionLevels[1]
                }
            };


            await context.Videos.AddRangeAsync(videos);
            await context.SaveChangesAsync();

            return videos;
        }
    }
}