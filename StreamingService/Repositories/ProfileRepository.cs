using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.DTO.ViewModels;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class ProfileRepository : EFRepository<UserProfile>
    {
        private readonly AppDbContext _context;
        public ProfileRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserProfile?> GetByGoogleIdAsync(string googleId)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(u  => u.GoogleId == googleId);
        }

        public async Task<UserProfile?> GetByEmailAsync(string email)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserProfile?> GetByUsernameAsync(string username)
        {
            string normalizedUsername = username.ToLower();

            return await _context.UserProfiles.FirstOrDefaultAsync(p => p.Username.ToLower() == normalizedUsername);
        }

        public async Task<UserProfileHeaderViewModel?> GetUserHeaderInfoAsync(int userId)
        {
            var user = await _context.UserProfiles
                .Where(u => u.Id == userId)
                .Select(u => new UserProfileHeaderViewModel
                {
                    Username = u.Username,
                    Email = u.Email,
                    AvatarUrl = u.AvatarUrl,
                    SubscriptionLevel = u.UserSubscriptions
                        .Where(s => s.Status == "Active" && s.SubscriptionEnd > DateTime.UtcNow)
                        .OrderByDescending(s => s.SubscriptionEnd)
                        .Select(s => s.SubscriptionPlan.SubscriptionLevel.Code)
                        .FirstOrDefault() ?? "Free",
                    HasActiveSubscription = u.UserSubscriptions
                        .Any(s => s.Status == "Active" && s.SubscriptionEnd > DateTime.UtcNow)
                })
                .FirstOrDefaultAsync();

            if (user != null)
            {
                if (string.IsNullOrWhiteSpace(user.AvatarUrl))
                {
                    user.AvatarUrl = GenerateDefaultAvatar(user.Username, user.Email);
                }
            }

            return user;
        }

        private static string GenerateDefaultAvatar(string username, string email)
        {
            var name = string.IsNullOrEmpty(username) ? email : username;
            return $"https://ui-avatars.com/api/?name={Uri.EscapeDataString(name)}&background=random&color=fff&size=128";
        }

        public async Task<UserProfileSettingsViewModel?> GetUserSettingsInfoAsync(int userId)
        {
            var user = await _context.UserProfiles
                .Where(u => u.Id == userId)
                .Select(u => new UserProfileSettingsViewModel
                {
                    Username = u.Username,
                    Email = u.Email,
                    AvatarUrl = u.AvatarUrl,
                    SubscriptionLevel = u.UserSubscriptions
                        .Where(s => s.Status == "Active" && s.SubscriptionEnd > DateTime.UtcNow)
                        .OrderByDescending(s => s.SubscriptionEnd)
                        .Select(s => s.SubscriptionPlan.SubscriptionLevel.Code)
                        .FirstOrDefault() ?? "Free"
                })
                .FirstOrDefaultAsync();

            if (user != null && string.IsNullOrWhiteSpace(user.AvatarUrl))
            {
                user.AvatarUrl = GenerateDefaultAvatar(user.Username, user.Email);
            }

            return user;
        }
    }
}
