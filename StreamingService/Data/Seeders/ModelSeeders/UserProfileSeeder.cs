using StreamingService.Services;
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
            new UserProfile
            {
                Username = "alice",
                Email = "alice@example.com",
                PasswordHash = PasswordHasher.HashPassword("password"),
                Birthday = new DateTime(2005, 10, 29)
            },
            new UserProfile
            {
                Username = "bob",
                Email = "bob@example.com",
                PasswordHash = PasswordHasher.HashPassword("password"),
                Birthday = new DateTime(2011, 6, 4)
            },
            new UserProfile
            {
                Username = "carol",
                Email = "carol@example.com",
                PasswordHash = PasswordHasher.HashPassword("password"),
                Birthday = new DateTime(1998, 2, 14)
            },
            new UserProfile
            {
                Username = "dave",
                Email = "dave@example.com",
                PasswordHash = PasswordHasher.HashPassword("password"),
                Birthday = new DateTime(2002, 11, 30)
            },
            new UserProfile
            {
                Username = "eve",
                Email = "eve@example.com",
                PasswordHash = PasswordHasher.HashPassword("password"),
                Birthday = new DateTime(1993, 5, 1)
            }
        };

            await context.UserProfiles.AddRangeAsync(userProfiles);
            await context.SaveChangesAsync();

            return userProfiles;
        }
    }
}