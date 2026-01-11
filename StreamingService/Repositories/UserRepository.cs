using Microsoft.EntityFrameworkCore;
using StreamingService.Data;

namespace StreamingService.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> isFavoriteAsync(int id, int videoId)
        {
            return await _context.UserVideoFavorites
                .Where(uvf => uvf.UserProfileId == id && uvf.VideoId == videoId)
                .FirstOrDefaultAsync() != null;
        }
    }
}
