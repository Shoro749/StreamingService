using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class UserSubscriptionRepository
    {
        private readonly AppDbContext _context;
        public UserSubscriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserSubscription>> GetActiveDataByUserIdAsync(int userId)
        {
            return await _context.UsersSubscriptions
                .Where(us => us.UserProfileId == userId && us.SubscriptionEnd >= DateTime.Now).
                ToListAsync();
        }
    }
}
