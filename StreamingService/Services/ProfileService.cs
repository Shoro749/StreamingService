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

                return await _profileRepository.AddDataAsync(newProfile);
            }

            user.AvatarUrl = picture;
            user.Username = name;

            return await _profileRepository.UpdateDataAsync(user);
        }

        public async Task<bool> CreateUserProfileAsync(UserProfile model)
        {
            var existingEmail = await _profileRepository.GetByEmailAsync(model.Email);
            if (existingEmail != null)
            {
                return false;
            }

            return await _profileRepository.AddDataAsync(model);
        }

        public async Task<UserProfile?> GetByIdAsync(int userId)
        {
            return await _profileRepository.GetDataAsync(userId);
        }
    }
}
