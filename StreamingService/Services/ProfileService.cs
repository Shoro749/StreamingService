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

        public async Task<bool> CreateUserProfileAsync(UserProfileViewModel model)
        {
            var existingProfile = await _profileRepository.GetByUsernameAsync(model.Username);

            if (existingProfile != null)
            {
                return false;
            }

            var newProfile = new UserProfile
            {
                Username = model.Username,
                Birthday = model.Birthday,
                AvatarUrl = model.AvatarUrl,
            };

            var success = await _profileRepository.AddDataAsync(newProfile);

            if (success)
            {
                return true;
            }

            return false;
        }
    }
}
