using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class GenreSeeder
    {
        public static async Task<List<Genre>?> SeedAsync(AppDbContext context)
        {
            if (context.Genres.Any())
                return null;

            var genres = new List<Genre>
            {
                new Genre { Code = "drama" },
                new Genre { Code = "adventure" },
                new Genre { Code = "fantasy" },
                new Genre { Code = "crime" },
                new Genre { Code = "comedy" }
            };

            await context.Genres.AddRangeAsync(genres);
            await context.SaveChangesAsync();

            return genres;
        }
    }
}