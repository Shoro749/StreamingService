using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoSeasonSeeder
    {
        public static async Task<List<VideoSeason>?> SeedAsync(AppDbContext context, List<Video>? videos)
        {
            if (videos == null)
                return null;

            if (context.VideoSeasons.Any())
                return null;

            var videoSeasons = new List<VideoSeason>
            {
                new VideoSeason
                {
                    NumberOfSeason = null,
                    Video = videos[0]
                },
                new VideoSeason
                {
                    NumberOfSeason = null,
                    Video = videos[1]
                },
                new VideoSeason
                {
                    NumberOfSeason = null,
                    Video = videos[2]
                },
                new VideoSeason
                {
                    NumberOfSeason = 1,
                    Video = videos[3]
                },
                new VideoSeason
                {
                    NumberOfSeason = 2,
                    Video = videos[3]
                }
            };


            await context.VideoSeasons.AddRangeAsync(videoSeasons);
            await context.SaveChangesAsync();

            return videoSeasons;
        }
    }
}