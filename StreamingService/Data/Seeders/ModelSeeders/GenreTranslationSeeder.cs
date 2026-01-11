using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class GenreTranslationSeeder
    {
        public static async Task<List<GenreTranslation>?> SeedAsync(AppDbContext context, List<Genre>? genres)
        {
            if (genres == null)
                return null;

            if (context.GenresTranslations.Any())
                return null;

            var genresTranslations = new List<GenreTranslation>
            {
                new GenreTranslation { GenreId = genres[0].Id, LocaleCode = "en", IsOriginal = true, Name = "Drama", Genre = genres[0] },
                new GenreTranslation { GenreId = genres[0].Id, LocaleCode = "uk", IsOriginal = false, Name = "Драма", Genre = genres[0] },

                new GenreTranslation { GenreId = genres[1].Id, LocaleCode = "en", IsOriginal = true, Name = "Adventure", Genre = genres[1] },
                new GenreTranslation { GenreId = genres[1].Id, LocaleCode = "uk", IsOriginal = false, Name = "Пригоди", Genre = genres[1] },

                new GenreTranslation { GenreId = genres[2].Id, LocaleCode = "en", IsOriginal = true, Name = "Fantasy", Genre = genres[2] },
                new GenreTranslation { GenreId = genres[2].Id, LocaleCode = "uk", IsOriginal = false, Name = "Фентезі", Genre = genres[2] },

                new GenreTranslation { GenreId = genres[3].Id, LocaleCode = "en", IsOriginal = true, Name = "Crime", Genre = genres[3]},
                new GenreTranslation { GenreId = genres[3].Id, LocaleCode = "uk", IsOriginal = false, Name = "Кримінал", Genre = genres[3]},

                new GenreTranslation { GenreId = genres[4].Id, LocaleCode = "en", IsOriginal = true, Name = "Comedy", Genre = genres[4]},
                new GenreTranslation { GenreId = genres[4].Id, LocaleCode = "uk", IsOriginal = false, Name = "Комедія", Genre = genres[4]}
            };


            await context.GenresTranslations.AddRangeAsync(genresTranslations);
            await context.SaveChangesAsync();

            return genresTranslations;
        }
    }
}