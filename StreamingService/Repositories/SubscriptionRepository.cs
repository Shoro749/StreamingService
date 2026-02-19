using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class SubscriptionRepository : EFRepository<SubscriptionPlan>
    {
        private readonly AppDbContext _context;

        public SubscriptionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SubscriptionPlan?> GetPlanAsync(int planId)
        {
            return await _context.SubscriptionPlans.Include(p => p.SubscriptionLevel).FirstOrDefaultAsync(p => p.Id == planId);
        }

        public async Task<List<SubscriptionPlan>> GetAllActivePlansAsync()
        {
            return await _context.SubscriptionPlans.Include(p => p.SubscriptionLevel).Where(p => p.IsEnabled).ToListAsync();
        }

        public async Task<bool> CreateSubscriptionAsync(UserSubscription subscription)
        {
            try
            {
                await _context.UsersSubscriptions.AddAsync(subscription);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<int?> CreatePaymentAsync(Payment payment)
        {
            try
            {
                await _context.Payments.AddAsync(payment);
                await _context.SaveChangesAsync();
                return payment.Id;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateSubscriptionPaymentAsync(int subscriptionId, int paymentId)
        {
            try
            {
                var subscription = await _context.UsersSubscriptions.FindAsync(subscriptionId);
                if (subscription == null) return false;

                subscription.PaymentId = paymentId;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UserSubscription?> GetActiveSubscriptionAsync(int profileId)
        {
            return await _context.UsersSubscriptions
                .Include(s => s.SubscriptionPlan)
                    .ThenInclude(p => p.SubscriptionLevel)
                .Include(s => s.Payment)
                .Where(s => s.UserProfileId == profileId && s.Status == "Active")
                .OrderByDescending(s => s.SubscriptionEnd)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UserSubscription>> GetUserSubscriptionsAsync(int profileId)
        {
            return await _context.UsersSubscriptions
                .Include(s => s.SubscriptionPlan)
                    .ThenInclude(p => p.SubscriptionLevel)
                .Include(s => s.Payment)
                .Where(s => s.UserProfileId == profileId)
                .OrderByDescending(s => s.SubscriptionStart)
                .ToListAsync();
        }

        public async Task<bool> UpdateSubscriptionStatusAsync(int subscriptionId, string status, bool autoRenew)
        {
            try
            {
                var subscription = await _context.UsersSubscriptions.FindAsync(subscriptionId);
                if (subscription == null) return false;

                subscription.Status = status;
                subscription.AutoRenew = autoRenew;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> HasActiveSubscriptionAsync(int profileId)
        {
            return await _context.UsersSubscriptions
                .AnyAsync(s => s.UserProfileId == profileId
                    && s.Status == "Active"
                    && s.SubscriptionEnd > DateTime.UtcNow);
        }
    }
}