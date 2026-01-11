using StreamingService.DTO.ViewModels;

namespace StreamingService.Repositories
{
    public interface IPlayerRepository
    {
        Task<PlayerViewModel> GetPlayerDataAsync(int episodeId, string locale);
    }
}
