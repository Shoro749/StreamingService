using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoEpisodeSeeder
    {
        public static async Task<List<VideoEpisode>?> SeedAsync(AppDbContext context, List<VideoSeason>? videoSeasons)
        {
            if (videoSeasons == null)
                return null;

            if (context.VideoEpisode.Any())
                return null;

            var videoEpisodes = new List<VideoEpisode>
            {
                new VideoEpisode
                {
                    Duration = 7200,
                    ReleaseDate = new DateOnly(2011, 4, 21),
                    EpisodeNumber = null,
                    EpisodeType = "Film",
                    VideoSeason = videoSeasons[0]
                },
                new VideoEpisode
                {
                    Duration = 169 * 60,
                    ReleaseDate = new DateOnly(2003, 7, 9),
                    EpisodeNumber = null,
                    EpisodeType = "Film",
                    VideoSeason = videoSeasons[1]
                },
                new VideoEpisode
                {
                    Duration = 108 * 60,
                    ReleaseDate = new DateOnly(2015, 10, 1),
                    EpisodeNumber = null,
                    EpisodeType = "Film",
                    VideoSeason = videoSeasons[2]
                },
                new VideoEpisode
                {
                    Duration = 47 * 60,
                    ReleaseDate = new DateOnly(2008, 1, 20),
                    EpisodeNumber = 1,
                    EpisodeType = "Series",
                    VideoSeason = videoSeasons[3]
                },
                new VideoEpisode
                {
                    Duration = 48 * 60,
                    ReleaseDate = new DateOnly(2008, 1, 27),
                    EpisodeNumber = 2,
                    EpisodeType = "Series",
                    VideoSeason = videoSeasons[3]
                },
                new VideoEpisode
                {
                    Duration = 47 * 60,
                    ReleaseDate = new DateOnly(2009, 3, 8),
                    EpisodeNumber = 1,
                    EpisodeType = "Series",
                    VideoSeason = videoSeasons[4]
                },
                new VideoEpisode
                {
                    Duration = 48 * 60,
                    ReleaseDate = new DateOnly(2009, 3, 15),
                    EpisodeNumber = 2,
                    EpisodeType = "Series",
                    VideoSeason = videoSeasons[4]
                }
            };


            await context.VideoEpisode.AddRangeAsync(videoEpisodes);
            await context.SaveChangesAsync();

            return videoEpisodes;
        }
    }
}