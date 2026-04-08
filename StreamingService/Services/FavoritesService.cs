using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _repository;

        public FavoritesService(FavoritesRepository repository)
        {
            _repository = repository;
        }

        public Task<List<VideoCardViewModel>> GetUserFavoritesAsync(int userProfileId, UserVideoListType listType, string locale = "uk")
        {
            return _repository.GetFavoritesByProfileIdAsync(userProfileId, locale, listType);
        }

        public Task<bool> AddToFavoritesAsync(int userProfileId, int videoId, UserVideoListType listType)
        {
            return _repository.AddToFavoritesAsync(userProfileId, videoId, listType);
        }

        public Task<bool> RemoveFromFavoritesAsync(int userProfileId, int videoId, UserVideoListType listType)
        {
            return _repository.RemoveFromFavoritesAsync(userProfileId, videoId, listType);
        }

        public async Task<bool> ExistsAsync(int userId, int videoId, UserVideoListType type)
        {
            return await _repository.ExistsAsync(userId, videoId, type);
        }
    }
}
