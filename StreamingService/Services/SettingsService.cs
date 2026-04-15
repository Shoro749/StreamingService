using StreamingService.Models;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class SettingsService
    {
        private readonly SettingsRepository _settingsRepository;

        public SettingsService(SettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public async Task<UserSettings?> GetUserSettingsAsync(int userId)
        {
            return await _settingsRepository.GetUserSettingsAsync(userId);
        }

        public async Task UpdateUserSettingsAsync(UserSettings settings)
        {
            await _settingsRepository.UpdateUserSettingsAsync(settings);
        }

        public async Task CreateUserSettingsAsync(UserSettings settings)
        {
            await _settingsRepository.AddDataAsync(settings);
        }
    }
}
