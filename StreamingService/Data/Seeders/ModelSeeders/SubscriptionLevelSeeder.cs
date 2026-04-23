using StreamingService.Models;
using System.Collections.Generic;

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
                new SubscriptionLevel { Code = "Безкоштовний" },
                new SubscriptionLevel { Code = "Стандартний" },
                new SubscriptionLevel { Code = "Преміум" }
            };

            await context.SubscriptionLevels.AddRangeAsync(subscriptionLevels);
            await context.SaveChangesAsync();

            return subscriptionLevels;
        }
    }
}