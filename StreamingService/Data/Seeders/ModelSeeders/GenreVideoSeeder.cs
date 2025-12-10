using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class GenreVideoSeeder
    {
        public static async Task<List<GenreVideo>?> SeedAsync(AppDbContext context, List<Genre>? genres, List<Video>? videos)
        {
            if (genres == null || videos == null)
                return null;

            if (context.GenresVideos.Any())
                return null;

            var genreVideos = new List<GenreVideo>
            {
                new GenreVideo { Video = videos[0], Genre = genres[0] },
                new GenreVideo { Video = videos[0], Genre = genres[4] },

                new GenreVideo { Video = videos[1], Genre = genres[1] },
                new GenreVideo { Video = videos[1], Genre = genres[2] },

                new GenreVideo { Video = videos[2], Genre = genres[2] },
                new GenreVideo { Video = videos[2], Genre = genres[0] },

                new GenreVideo { Video = videos[3], Genre = genres[3] },
                new GenreVideo { Video = videos[3], Genre = genres[0] }
            };


            await context.GenresVideos.AddRangeAsync(genreVideos);
            await context.SaveChangesAsync();

            return genreVideos;
        }
    }
}