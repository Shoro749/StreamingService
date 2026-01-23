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

        public async Task<bool> CreateUserProfileAsync(UserProfileViewModel model)
        {
            var existingEmail = await _profileRepository.GetByEmailAsync(model.Email);
            if (existingEmail != null)
            {
                return false;
            }

            var newProfile = new UserProfile
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = PasswordHasher.HashPassword(model.Password),
                Birthday = model.Birthday,
                AvatarUrl = model.AvatarUrl,
                GoogleId = model.GoogleId
            };

            return await _profileRepository.AddDataAsync(newProfile);
        }

        public async Task<bool> LoginUserAsync(LoginViewModel model)
        {
            var user = await _profileRepository.GetByEmailAsync(model.Email);

            if (user == null || string.IsNullOrEmpty(user.PasswordHash))
            {
                return false;
            }

            bool isPasswordValid = PasswordHasher.VerifyPassword(model.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                return false;
            }

            return true;
        }
    }
}
