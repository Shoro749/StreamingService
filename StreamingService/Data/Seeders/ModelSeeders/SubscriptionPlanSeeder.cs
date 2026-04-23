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

                    Price = 0,
                    PeriodDays = 30,
                    TrialDays = 7,
                    Features = "Обмежений каталог фільмів і серіалів;Якість відтворення до 720p;1 профіль користувача;Реклама під час перегляду;Без завантажень;Базові рекомендації;Лише онлайн-перегляд;Оновлення контенту щотижня",
                    IsEnabled = true,
                    SubscriptionLevel = subscriptionLevels[0]
                },
                new SubscriptionPlan
                {

                    Price = 249,
                    PeriodDays = 30,
                    TrialDays = 7,
                    Features = "Повний каталог фільмів і серіалів;Якість відтворення Full HD (1080p);До 2 профілів користувачів;Без реклами;Можливість завантаження офлайн;Розширені рекомендації;Перегляд на кількох пристроях;Оновлення контенту двічі на тиждень",
                    IsEnabled = true,
                    SubscriptionLevel = subscriptionLevels[1]
                },
                new SubscriptionPlan
                {

                    Price = 449,
                    PeriodDays = 30,
                    TrialDays = 0,
                    Features = "Повний каталог + ексклюзиви;Якість 4K UHD + HDR;До 4 профілів користувачів;Без реклами;Dolby Atmos звук;Персональні рекомендації;Ранній доступ до новинок;Постійні оновлення контенту",
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