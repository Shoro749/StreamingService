using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class UserVideoRatingSeeder
    {
        public static async Task<List<UserVideoRating>?> SeedAsync(AppDbContext context, List<UserProfile>? users, List<Video>? videos)
        {
            if (users == null || videos == null)
                return null;

            if (context.UserVideoRatings.Any())
                return null;

            var userVideoRatings = new List<UserVideoRating>
            {
                new UserVideoRating { UserProfile = users[0], Video = videos[0], Rating = 5 },
                new UserVideoRating { UserProfile = users[1], Video = videos[0], Rating = 4 },
                new UserVideoRating { UserProfile = users[2], Video = videos[1], Rating = 5 },
                new UserVideoRating { UserProfile = users[3], Video = videos[2], Rating = 3 },
                new UserVideoRating { UserProfile = users[4], Video = videos[3], Rating = 5 },

                new UserVideoRating { UserProfile = users[0], Video = videos[1], Rating = 4 },
                new UserVideoRating { UserProfile = users[1], Video = videos[1], Rating = 3 },
                new UserVideoRating { UserProfile = users[2], Video = videos[2], Rating = 4 },
                new UserVideoRating { UserProfile = users[3], Video = videos[3], Rating = 5 },
                new UserVideoRating { UserProfile = users[4], Video = videos[0], Rating = 3 },

                new UserVideoRating { UserProfile = users[0], Video = videos[2], Rating = 5 },
                new UserVideoRating { UserProfile = users[1], Video = videos[3], Rating = 4 },
                new UserVideoRating { UserProfile = users[2], Video = videos[0], Rating = 4 },
                new UserVideoRating { UserProfile = users[3], Video = videos[1], Rating = 5 },
                new UserVideoRating { UserProfile = users[4], Video = videos[2], Rating = 3 },

                new UserVideoRating { UserProfile = users[0], Video = videos[3], Rating = 5 },
                new UserVideoRating { UserProfile = users[1], Video = videos[2], Rating = 4 },
                new UserVideoRating { UserProfile = users[2], Video = videos[3], Rating = 5 },
                new UserVideoRating { UserProfile = users[3], Video = videos[0], Rating = 4 },
                new UserVideoRating { UserProfile = users[4], Video = videos[1], Rating = 3 }
            };


            await context.UserVideoRatings.AddRangeAsync(userVideoRatings);
            await context.SaveChangesAsync();

            return userVideoRatings;
        }
    }
}