using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class UserVideoFavoriteSeeder
    {
        public static async Task<List<UserVideoList>?> SeedAsync(AppDbContext context, List<UserProfile>? users, List<Video>? videos)
        {
            if (users == null || videos == null)
                return null;

            if (context.UserVideoLists.Any())
                return null;

            var userVideoFavorites = new List<UserVideoList>
            {
                new UserVideoList { UserProfile = users[0], Video = videos[0] },
                new UserVideoList { UserProfile = users[1], Video = videos[1] },
                new UserVideoList { UserProfile = users[2], Video = videos[2] },
                new UserVideoList { UserProfile = users[3], Video = videos[0] },
                new UserVideoList { UserProfile = users[4], Video = videos[3] }
            };


            await context.UserVideoLists.AddRangeAsync(userVideoFavorites);
            await context.SaveChangesAsync();

            return userVideoFavorites;
        }
    }
}