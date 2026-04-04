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

            var rand = new Random();

            var videos = new List<Video>
            {
                new Video
                {
                    RatingCount = rand.Next(0, 101),
                    RatingSum = rand.Next(0, 1000),
                    SubscriptionLevel = subscriptionLevels[0],
                    AgeRating = "12+",
                    TrailerDuration = 55,
                    VideoType = "Movie",
                    Trailerurl = "https://www.youtube.com/watch?v=zx2o_2GHZ88",
                },
                new Video
                {
                    RatingCount = rand.Next(0, 101),
                    RatingSum = rand.Next(0, 1000),
                    SubscriptionLevel = subscriptionLevels[1],
                    AgeRating = "12+",
                    VideoType = "Movie",
                    TrailerDuration = 141,
                    Trailerurl = "https://www.youtube.com/watch?v=iu0QchrekQY",
                },
                new Video
                {
                    RatingCount = rand.Next(0, 101),
                    RatingSum = rand.Next(0, 1000),
                    SubscriptionLevel = subscriptionLevels[0],
                    AgeRating = "8+",
                    VideoType = "AnimatedMovie",
                    TrailerDuration = 175,
                    Trailerurl = "https://www.youtube.com/watch?v=Cnxct7nWbYM",
                },
                new Video
                {
                    RatingCount = rand.Next(0, 101),
                    RatingSum = rand.Next(0, 1000),
                    SubscriptionLevel = subscriptionLevels[1],
                    AgeRating = "18+",
                    VideoType = "Series",
                    TrailerDuration = 174,
                    Trailerurl = "https://www.youtube.com/watch?v=VFkjBy2b50Q",
                },
                new Video
                {
                    RatingCount = rand.Next(0, 101),
                    RatingSum = rand.Next(0, 1000),
                    SubscriptionLevel = subscriptionLevels[1],
                    AgeRating = "12+",
                    VideoType = "Movie",
                    TrailerDuration = 151,
                    Trailerurl = "https://www.youtube.com/watch?v=2LqzF5WauAw",
                },
                new Video
                {
                    RatingCount = rand.Next(0, 101),
                    RatingSum = rand.Next(0, 1000),
                    SubscriptionLevel = subscriptionLevels[0],
                    AgeRating = "18+",
                    VideoType = "Movie",
                    TrailerDuration = 118,
                    Trailerurl = "https://www.youtube.com/watch?v=1r_kvwIMqvs",
                },
                new Video
                {
                    RatingCount = rand.Next(0, 101),
                    RatingSum = rand.Next(0, 1000),
                    SubscriptionLevel = subscriptionLevels[1],
                    AgeRating = "18+",
                    VideoType = "Moives",
                    TrailerDuration = 150,
                    Trailerurl = "https://www.youtube.com/watch?v=OStkX1HsAM4"
                }
            };


            await context.Videos.AddRangeAsync(videos);
            await context.SaveChangesAsync();

            return videos;
        }
    }
}