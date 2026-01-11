using StreamingService.DTO.Resuests;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> ToggleFavoriteAsync(UserToggleFavoriteViewModel request)
        {
            return await _userRepository.isFavoriteAsync(request.UserId, request.VideoId);
        }
    }
}
