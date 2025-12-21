using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class UserVideoFavoriteSeeder
    {
        public static async Task<List<UserVideoFavorite>?> SeedAsync(AppDbContext context, List<UserProfile>? users, List<Video>? videos)
        {
            if (users == null || videos == null)
                return null;

            if (context.UserVideoFavorites.Any())
                return null;

            var userVideoFavorites = new List<UserVideoFavorite>
            {
                new UserVideoFavorite { UserProfile = users[0], Video = videos[0] },
                new UserVideoFavorite { UserProfile = users[1], Video = videos[1] },
                new UserVideoFavorite { UserProfile = users[2], Video = videos[2] },
                new UserVideoFavorite { UserProfile = users[3], Video = videos[0] },
                new UserVideoFavorite { UserProfile = users[4], Video = videos[3] }
            };


            await context.UserVideoFavorites.AddRangeAsync(userVideoFavorites);
            await context.SaveChangesAsync();

            return userVideoFavorites;
        }
    }
}