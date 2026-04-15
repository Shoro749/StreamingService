using StreamingService.DTO.ViewModels;
using StreamingService.Models;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class ProfileService
    {
        private readonly ProfileRepository _profileRepository;

        public ProfileService(ProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<UserProfile?> GetByGoogleIdAsync(string googleId)
        {
            return await _profileRepository.GetByGoogleIdAsync(googleId);
        }

        public async Task<UserProfile?> GetByEmailAsync(string email)
        {
            return await _profileRepository.GetByEmailAsync(email);
        }

        public async Task<bool> HandleGoogleAuthAsync(string googleId, string email, string name, string picture)
        {
            try
            {
                if (string.IsNullOrEmpty(googleId) || string.IsNullOrEmpty(email))
                {
                    return false;
                }

                var user = await _profileRepository.GetByGoogleIdAsync(googleId);

                if (user == null)
                {
                    user = await _profileRepository.GetByEmailAsync(email);
                }

                if (user == null)
                {
                    var newProfile = new UserProfile
                    {
                        GoogleId = googleId,
                        Email = email,
                        Username = name ?? "Google User",
                        AvatarUrl = picture,
                        Settings = new UserSettings()
                    };

                    var result = await _profileRepository.AddDataAsync(newProfile);
                    return result;
                }

                if (string.IsNullOrEmpty(user.GoogleId))
                {
                    user.GoogleId = googleId;
                }

                user.AvatarUrl = picture;
                user.Username = name ?? user.Username;

                var updateResult = await _profileRepository.UpdateDataAsync(user);
                return updateResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleGoogleAuthAsync Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> CreateUserProfileAsync(UserProfile model)
        {
            var existingEmail = await _profileRepository.GetByEmailAsync(model.Email);
            if (existingEmail != null)
            {
                return false;
            }

            model.Settings = new UserSettings();

            return await _profileRepository.AddDataAsync(model);
        }

        public async Task<UserProfile?> GetByIdAsync(int userId)
        {
            return await _profileRepository.GetDataAsync(userId);
        }

        public async Task<UserProfileHeaderViewModel?> GetUserHeaderInfoAsync(int userId)
        {
            return await _profileRepository.GetUserHeaderInfoAsync(userId);
        }
        
        //метод для отримання даних профілю та інформації про підписку для сторінки налаштувань профілю
        public async Task<UserProfileSettingsViewModel?> GetProfileSettingsAsync(int userId)
        {
            return await _profileRepository.GetUserSettingsInfoAsync(userId);
        }
    }
}
