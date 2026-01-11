using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoTranslationSeeder
    {
        public static async Task<List<VideoTranslation>?> SeedAsync(AppDbContext context, List<Video>? videos)
        {
            if (videos == null)
                return null;

            if (context.VideoTranslations.Any())
                return null;

            var videoTranslations = new List<VideoTranslation>
            {
                new VideoTranslation
                {
                    Video = videos[0],
                    LocaleCode = "en",
                    IsOriginal = true,
                    Title = "1+1",
                    Description = "A heartwarming story of friendship and overcoming challenges."
                },
                new VideoTranslation
                {
                    Video = videos[0],
                    LocaleCode = "uk",
                    IsOriginal = false,
                    Title = "1+1",
                    Description = "Зворушлива історія дружби та подолання труднощів."
                },

                new VideoTranslation
                {
                    Video = videos[1],
                    LocaleCode = "en",
                    IsOriginal = true,
                    Title = "Pirates of the Caribbean",
                    Description = "A swashbuckling adventure across the seven seas."
                },
                new VideoTranslation
                {
                    Video = videos[1],
                    LocaleCode = "uk",
                    IsOriginal = false,
                    Title = "Пірати Карибського моря",
                    Description = "Пригоди на семи морях з відважними піратами."
                },

                new VideoTranslation
                {
                    Video = videos[2],
                    LocaleCode = "en",
                    IsOriginal = true,
                    Title = "The Little Prince",
                    Description = "A magical tale about imagination and friendship."
                },
                new VideoTranslation
                {
                    Video = videos[2],
                    LocaleCode = "uk",
                    IsOriginal = false,
                    Title = "Маленький принц",
                    Description = "Чарівна історія про уяву та дружбу."
                },

                new VideoTranslation
                {
                    Video = videos[3],
                    LocaleCode = "en",
                    IsOriginal = true,
                    Title = "Breaking Bad",
                    Description = "A high school teacher turns to a life of crime."
                },
                new VideoTranslation
                {
                    Video = videos[3],
                    LocaleCode = "uk",
                    IsOriginal = false,
                    Title = "Во все тяжкие",
                    Description = "Учитель середньої школи стає на шлях злочинності."
                }
            };


            await context.VideoTranslations.AddRangeAsync(videoTranslations);
            await context.SaveChangesAsync();

            return videoTranslations;
        }
    }
}