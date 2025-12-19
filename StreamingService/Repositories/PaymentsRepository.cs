using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class PaymentsRepository
    {
        private readonly AppDbContext _context;

        public PaymentsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SubscriptionPlan?> GetPlanAsync(int planId)
        {
            return await _context.SubscriptionPlans.FindAsync(planId);
        }

        public async Task<bool> CreateSubscriptionWithPayment(UserSubscription sub, Payment pay)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Payments.AddAsync(pay);
                await _context.SaveChangesAsync();

                sub.PaymentId = pay.Id;
                await _context.UsersSubscriptions.AddAsync(sub);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
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
                .OrderByDescending(s => s.SubscriptionEnd)
                .FirstOrDefaultAsync(s => s.UserProfileId == profileId && s.Status == "Active");
        }

        public async Task<bool> UpdateSubscriptionStatusAsync(int subscriptionId, string status, bool autoRenew)
        {
            try
            {
                var sub = await _context.UsersSubscriptions.FindAsync(subscriptionId);
                if (sub != null)
                {
                    sub.Status = status;
                    sub.AutoRenew = autoRenew;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
