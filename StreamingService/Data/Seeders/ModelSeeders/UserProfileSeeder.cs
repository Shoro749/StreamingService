using Microsoft.AspNetCore.Identity;
using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class UserProfileSeeder
    {
        public static async Task<List<UserProfile>?> SeedAsync(AppDbContext context) 
        { 
            if (context.UserProfiles.Any())
                return null;

            var userProfiles = new List<UserProfile>
             {
                new UserProfile { Username = "alice", Birthday = new DateTime(2005 ,10, 29)},
                new UserProfile { Username = "bob", Birthday = new DateTime(2011 ,6, 4)},
                new UserProfile { Username = "carol", Birthday = new DateTime(1998 ,2, 14)},
                new UserProfile { Username = "dave", Birthday = new DateTime(2002 ,11, 30)},
                new UserProfile { Username = "eve",  Birthday = new DateTime(1993 ,5, 1)}
            };

            await context.UserProfiles.AddRangeAsync(userProfiles);
            await context.SaveChangesAsync();

            return userProfiles;
        }
    }
}