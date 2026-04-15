using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.DTO.ViewModels;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class SettingsRepository : EFRepository<UserSettings>
    {
        private readonly AppDbContext _context;
        public SettingsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserSettings?> GetUserSettingsAsync(int userId)
        {
            return await _context.Set<UserSettings>().FirstOrDefaultAsync(s => s.UserProfileId == userId);
        }

        public async Task UpdateUserSettingsAsync(UserSettings settings)
        {
            var existing = await _context.Set<UserSettings>().FirstOrDefaultAsync(s => s.UserProfileId == settings.UserProfileId);
            if (existing != null)
            {
                existing.CollectViewingData = settings.CollectViewingData;
                existing.SaveSearchHistory = settings.SaveSearchHistory;
                existing.PersonalizedRecommendations = settings.PersonalizedRecommendations;
                existing.UseCookies = settings.UseCookies;
                existing.UsageAnalytics = settings.UsageAnalytics;

                _context.Set<UserSettings>().Update(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
