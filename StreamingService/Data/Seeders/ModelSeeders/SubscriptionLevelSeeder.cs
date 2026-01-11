using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class SubscriptionLevelSeeder
    {
        public static async Task<List<SubscriptionLevel>?> SeedAsync(AppDbContext context)
        {
            if (context.SubscriptionLevels.Any())
                return null;

            var subscriptionLevels = new List<SubscriptionLevel>
            {
                new SubscriptionLevel { Code = "Basic" },
                new SubscriptionLevel { Code = "Premium" },
                new SubscriptionLevel { Code = "VIP" }
            };

            await context.SubscriptionLevels.AddRangeAsync(subscriptionLevels);
            await context.SaveChangesAsync();

            return subscriptionLevels;
        }
    }
}