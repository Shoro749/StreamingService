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

        public Task<List<VideoCardViewModel>> GetUserFavoritesAsync(int userProfileId, string locale = "uk")
        {
            return _repository.GetFavoritesByProfileIdAsync(userProfileId, locale);
        }

        public Task<bool> AddToFavoritesAsync(int userProfileId, int videoId)
        {
            return _repository.AddToFavoritesAsync(userProfileId, videoId);
        }

        public Task<bool> RemoveFromFavoritesAsync(int userProfileId, int videoId)
        {
            return _repository.RemoveFromFavoritesAsync(userProfileId, videoId);
        }
    }
}
