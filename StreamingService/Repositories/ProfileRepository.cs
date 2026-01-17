using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class ProfileRepository : EFRepository<UserProfile>
    {
        private readonly AppDbContext _context;
        public ProfileRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserProfile?> GetByGoogleIdAsync(string googleId)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(u  => u.GoogleId == googleId);
        }

        public async Task<UserProfile?> GetByEmailAsync(string email)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserProfile?> GetByUsernameAsync(string username)
        {
            string normalizedUsername = username.ToLower();

            return await _context.UserProfiles
                .FirstOrDefaultAsync(p => p.Username.ToLower() == normalizedUsername);
        }
    }
}
