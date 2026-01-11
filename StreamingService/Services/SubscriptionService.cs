using StreamingService.Models;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class SubscriptionService
    {
        private readonly SubscriptionRepository _repository;

        public SubscriptionService(SubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ProcessSubscriptionAsync(int profileId, int planId, string provider)
        {
            var newPlan = await _repository.GetPlanAsync(planId);
            if (newPlan == null || !newPlan.IsEnabled) return false;

            var currentSub = await _repository.GetActiveSubscriptionAsync(profileId);

            if (currentSub != null)
            {
                if (Enum.TryParse(currentSub.SubscriptionPlan.SubscriptionLevel.Code, out SubscriptionLevelCode currentLevel) &&
                    Enum.TryParse(newPlan.SubscriptionLevel.Code, out SubscriptionLevelCode newLevel))
                {
                    if (newLevel < currentLevel)
                    {
                        return false;
                    }
                }
            }

            var payment = new Payment
            {
                Amount = newPlan.Price,
                Currency = "UAH",
                Provider = provider,
                Method = "Card",
                Status = "Active",
                CreatedAt = DateTime.UtcNow
            };

            var subscription = new UserSubscription
            {
                UserProfileId = profileId,
                SubscriptionPlanId = planId,
                Status = "Active",
                AutoRenew = true,
                SubscriptionStart = DateTime.UtcNow,
                SubscriptionEnd = DateTime.UtcNow.AddDays(newPlan.PeriodDays)
            };

            return await _repository.CreateSubscriptionWithPayment(subscription, payment);
        }

        public async Task<object?> GetCurrentPlanInfoAsync(int profileId)
        {
            var sub = await _repository.GetActiveSubscriptionAsync(profileId);
            if (sub == null) return null;

            var currentCode = sub.SubscriptionPlan.SubscriptionLevel.Code;

            return new
            {
                PlanName = sub.SubscriptionPlan.SubscriptionLevel.Code,
                EndDate = sub.SubscriptionEnd,
                Status = sub.Status,
                IsAutoRenew = sub.AutoRenew,

                CanWatchHD = UserHasAccess(currentCode, SubscriptionLevelCode.Premium),
                CanWatchUltraHD = UserHasAccess(currentCode, SubscriptionLevelCode.VIP)
            };
        }

        public async Task<bool> CancelSubscriptionAsync(int profileId)
        {
            var sub = await _repository.GetActiveSubscriptionAsync(profileId);
            if (sub == null) return false;

            return await _repository.UpdateSubscriptionStatusAsync(sub.Id, "Active", false);
        }

        private bool UserHasAccess(string? userLevelCode, SubscriptionLevelCode requiredLevel)
        {
            if (string.IsNullOrEmpty(userLevelCode)) return false;

            if (Enum.TryParse(userLevelCode, out SubscriptionLevelCode userLevel))
            {
                return userLevel >= requiredLevel;
            }
            return false;
        }
    }
}
