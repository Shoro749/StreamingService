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

        public async Task HandleGoogleAuthAsync(string googleId, string email, string name, string picture)
        {
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
                    Username = name,
                    AvatarUrl = picture,
                };

                await _profileRepository.AddDataAsync(newProfile);
                return;
            }

            user.AvatarUrl = picture;
            user.Username = name;

            await _profileRepository.UpdateDataAsync(user);
        }

        public async Task<bool> CreateUserProfileAsync(UserProfileViewModel model)
        {
            var existingProfile = await _profileRepository.GetByUsernameAsync(model.Username);

            if (existingProfile == null)
            {
                return false;
            }

            var newProfile = new UserProfile
            {
                Username = model.Username,
                Birthday = model.Birthday,
                AvatarUrl = model.AvatarUrl,
            };

            return await _profileRepository.AddDataAsync(newProfile);
        }
    }
}
