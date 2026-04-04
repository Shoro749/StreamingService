using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class SubscriptionPlanSeeder
    {
        public static async Task<List<SubscriptionPlan>?> SeedAsync(AppDbContext context, List<SubscriptionLevel>? subscriptionLevels)
        {
            if (subscriptionLevels == null)
                return null;

            if (context.SubscriptionPlans.Any())
                return null;

            var subscriptionPlans = new List<SubscriptionPlan>
            {
                new SubscriptionPlan
                {

                    Price = 9.99m,
                    PeriodDays = 30,
                    TrialDays = 7,
                    Features = "Access to basic content",
                    IsEnabled = true,
                    SubscriptionLevel = subscriptionLevels[0]
                },
                new SubscriptionPlan
                {

                    Price = 19.99m,
                    PeriodDays = 30,
                    TrialDays = 7,
                    Features = "Access to standard content",
                    IsEnabled = true,
                    SubscriptionLevel = subscriptionLevels[1]
                },
                new SubscriptionPlan
                {

                    Price = 29.99m,
                    PeriodDays = 30,
                    TrialDays = 0,
                    Features = "All content + premium perks",
                    IsEnabled = true,
                    SubscriptionLevel = subscriptionLevels[2]
                }
            };


            await context.SubscriptionPlans.AddRangeAsync(subscriptionPlans);
            await context.SaveChangesAsync();

            return subscriptionPlans;
        }
    }
}