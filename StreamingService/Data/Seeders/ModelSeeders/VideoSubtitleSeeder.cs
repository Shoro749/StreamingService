using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoSubtitleSeeder
    {
        public static async Task<List<VideoSubtitle>?> SeedAsync(AppDbContext context, List<VideoEpisode>? videoEpisodes)
        {
            if (videoEpisodes == null)
                return null;

            if (context.VideoSubtitles.Any())
                return null;

            var subtitles = new List<VideoSubtitle>
            {
                new VideoSubtitle { Title = "English", LocaleCode = "en", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[0] },
                new VideoSubtitle { Title = "Українські", LocaleCode = "uk", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[0] },

                new VideoSubtitle { Title = "English", LocaleCode = "en", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[1] },
                new VideoSubtitle { Title = "Українські", LocaleCode = "uk", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[1] },

                new VideoSubtitle { Title = "English", LocaleCode = "en", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[2] },
                new VideoSubtitle { Title = "Українські", LocaleCode = "uk", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[2] },

                new VideoSubtitle { Title = "English", LocaleCode = "en", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[3] },
                new VideoSubtitle { Title = "Українські", LocaleCode = "uk", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[3] },

                new VideoSubtitle { Title = "English", LocaleCode = "en", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[4] },
                new VideoSubtitle { Title = "Українські", LocaleCode = "uk", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[4] },

                new VideoSubtitle { Title = "English", LocaleCode = "en", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[5] },
                new VideoSubtitle { Title = "Українські", LocaleCode = "uk", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[5] },

                new VideoSubtitle { Title = "English", LocaleCode = "en", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[6] },
                new VideoSubtitle { Title = "Українські", LocaleCode = "uk", BlobContainer = "empty", BlobPath = "empty", VideoEpisodes = videoEpisodes[6] }
            };


            await context.VideoSubtitles.AddRangeAsync(subtitles);
            await context.SaveChangesAsync();

            return subtitles;
        }
    }
}