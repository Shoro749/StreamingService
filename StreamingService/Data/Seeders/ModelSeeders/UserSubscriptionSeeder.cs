using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class UserSubscriptionSeeder
    {
        public static async Task<List<UserSubscription>?> SeedAsync(AppDbContext context, List<UserProfile>? users, List<Payment>? payments, List<SubscriptionPlan>? subscriptionPlans)
        {
            if (users == null || payments == null || subscriptionPlans == null)
                return null;

            if (context.UsersSubscriptions.Any())
                return null;

            var userSubscriptions = new List<UserSubscription>
            {
                new UserSubscription
                {
                    Status = "Active",
                    AutoRenew = true,
                    SubscriptionStart = DateTime.UtcNow.AddDays(-10),
                    SubscriptionEnd = DateTime.UtcNow.AddDays(20),
                    UserProfile = users[0],
                    Payment = payments[0],
                    SubscriptionPlan = subscriptionPlans[0]
                },
                new UserSubscription
                {
                    Status = "Active",
                    AutoRenew = true,
                    SubscriptionStart = DateTime.UtcNow.AddDays(-5),
                    SubscriptionEnd = DateTime.UtcNow.AddDays(25),
                    UserProfile = users[1],
                    Payment = payments[1],
                    SubscriptionPlan = subscriptionPlans[1]
                },
                //new UserSubscription
                //{
                //    Status = "Trial",
                //    AutoRenew = false,
                //    SubscriptionStart = DateTime.UtcNow,
                //    SubscriptionEnd = DateTime.UtcNow.AddDays(7),
                //    UserProfile = users[2],
                //    SubscriptionPlan = subscriptionPlans[0]
                //},
                new UserSubscription
                {
                    Status = "Active",
                    AutoRenew = true,
                    SubscriptionStart = DateTime.UtcNow.AddDays(-2),
                    SubscriptionEnd = DateTime.UtcNow.AddDays(28),
                    UserProfile = users[3],
                    Payment = payments[2],
                    SubscriptionPlan = subscriptionPlans[2]
                },
                new UserSubscription
                {
                    Status = "Canceled",
                    AutoRenew = false,
                    SubscriptionStart = DateTime.UtcNow.AddDays(-20),
                    SubscriptionEnd = DateTime.UtcNow.AddDays(-1),
                    UserProfile = users[4],
                    Payment = payments[1],
                    SubscriptionPlan = subscriptionPlans[1]
                }
            };


            await context.UsersSubscriptions.AddRangeAsync(userSubscriptions);
            await context.SaveChangesAsync();

            return userSubscriptions;
        }
    }
}