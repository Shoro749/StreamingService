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
                },

                new VideoTranslation
                {
                    Video = videos[4],
                    LocaleCode = "en",
                    IsOriginal = true,
                    Title = "Interstellar",
                    Description = "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans."
                },
                new VideoTranslation
                {
                    Video = videos[4],
                    LocaleCode = "uk",
                    IsOriginal = false,
                    Title = "Інтерстеллар",
                    Description = "Коли посуха приводить людство до продовольчої кризи, колектив дослідників і вчених вирушає крізь червоточину в подорож, щоб знайти планету з відповідними для людства умовами."
                },

                new VideoTranslation
                {
                    Video = videos[5],
                    LocaleCode = "en",
                    IsOriginal = true,
                    Title = "Predator: Wildlands",
                    Description = "Set in the future on a distant planet, a young Predator, exiled from his clan, finds an unlikely ally in Tia and embarks on a treacherous journey in search of his ultimate adversary."
                },
                new VideoTranslation
                {
                    Video = videos[5],
                    LocaleCode = "uk",
                    IsOriginal = false,
                    Title = "Хижак: Дикі землі",
                    Description = "Дія розгортається в майбутньому на віддаленій планеті, де молодий Хижак, вигнаний зі свого клану, знаходить малоймовірного союзника в особі Тії та вирушає в підступну подорож на пошуки свого остаточного супротивника."
                },

                new VideoTranslation
                {
                    Video = videos[6],
                    LocaleCode = "en",
                    IsOriginal = true,
                    Title = "Pointed Caps: Immortal",
                    Description = "The epic sequel to the cult series, Tommy Shelby returns in the midst of World War II for his final and most dangerous mission."
                },
                new VideoTranslation
                {
                    Video = videos[6],
                    LocaleCode = "uk",
                    IsOriginal = false,
                    Title = "Гострі картузи: Безсмертний",
                    Description = "Епічне кінопродовження культового серіалу. Томмі Шелбі знову повертається у розпалі Другої світової війни для своєї останньої та найнебезпечнішої місії."
                }
            };


            await context.VideoTranslations.AddRangeAsync(videoTranslations);
            await context.SaveChangesAsync();

            return videoTranslations;
        }
    }
}