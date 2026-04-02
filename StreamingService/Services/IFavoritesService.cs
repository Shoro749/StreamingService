using StreamingService.DTO.ViewModels;

namespace StreamingService.Services;

public interface IFavoritesService
{
    Task<List<VideoCardViewModel>> GetUserFavoritesAsync(int userProfileId, string locale = "uk");
    Task<bool> AddToFavoritesAsync(int userProfileId, int videoId);
    Task<bool> RemoveFromFavoritesAsync(int userProfileId, int videoId);
    Task<List<VideoCardViewModel>> GetPostponedVideosAsync(int userId, string locale);
}
