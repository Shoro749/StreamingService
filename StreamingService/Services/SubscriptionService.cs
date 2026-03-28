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

        public async Task<List<SubscriptionPlan>> GetAllPlansAsync()
        {
            return await _repository.GetAllActivePlansAsync();
        }

        public async Task<SubscriptionPlan?> GetPlanByIdAsync(int planId)
        {
            return await _repository.GetPlanAsync(planId);
        }

        public async Task<bool> ProcessSubscriptionAsync(int profileId, int planId, string paymentMethod)
        {
            var plan = await _repository.GetPlanAsync(planId);
            if (plan == null || !plan.IsEnabled)
                return false;

            var payment = new Payment
            {
                Amount = plan.Price,
                Currency = "UAH",
                Provider = GetProviderFromMethod(paymentMethod),
                Method = paymentMethod,
                TransactionId = GenerateTransactionId(),
                Status = "Completed",
                CreatedAt = DateTime.UtcNow
            };

            var paymentId = await _repository.CreatePaymentAsync(payment);
            if (!paymentId.HasValue)
                return false;

            var subscription = new UserSubscription
            {
                UserProfileId = profileId,
                SubscriptionPlanId = planId,
                PaymentId = paymentId.Value,
                Status = "Active",
                AutoRenew = true,
                SubscriptionStart = DateTime.UtcNow,
                SubscriptionEnd = DateTime.UtcNow.AddDays(plan.PeriodDays)
            };

            return await _repository.CreateSubscriptionAsync(subscription);
        }

        public async Task<object?> GetCurrentPlanInfoAsync(int profileId)
        {
            var sub = await _repository.GetActiveSubscriptionAsync(profileId);
            if (sub == null) return null;

            var currentCode = sub.SubscriptionPlan.SubscriptionLevel.Code;

            return new
            {
                PlanId = sub.SubscriptionPlanId,
                PlanName = sub.SubscriptionPlan?.SubscriptionLevel?.Code,
                PlanPrice = sub.SubscriptionPlan?.Price,
                StartDate = sub.SubscriptionStart,
                EndDate = sub.SubscriptionEnd,
                Status = sub.Status,
                IsAutoRenew = sub.AutoRenew,
                DaysLeft = (sub.SubscriptionEnd - DateTime.UtcNow).Days,
                PaymentAmount = sub.Payment?.Amount,
                PaymentMethod = sub.Payment?.Method
            };
        }

        public async Task<bool> CancelAutoRenewalAsync(int profileId)
        {
            var sub = await _repository.GetActiveSubscriptionAsync(profileId);
            if (sub == null) return false;

            return await _repository.UpdateSubscriptionStatusAsync(sub.Id, sub.Status, false);
        }

        private string GetProviderFromMethod(string method)
        {
            return method switch
            {
                "PayPal" => "PayPal",
                "GooglePay" => "Google",
                "ApplePay" => "Apple",
                _ => "Stripe"
            };
        }

        private string GenerateTransactionId()
        {
            return $"TXN_{DateTime.UtcNow:yyyyMMddHHmmss}_{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";
        }

        public async Task<bool> CancelSubscriptionAsync(int profileId)
        {
            var sub = await _repository.GetActiveSubscriptionAsync(profileId);
            if (sub == null) return false;

            return await _repository.UpdateSubscriptionStatusAsync(sub.Id, "Cancelled", false);
        }

        public async Task<bool> HasAccessToVideoAsync(int userId, int videoId)
        {
            var hasSubscription = await HasActiveSubscriptionAsync(userId);
            if (!hasSubscription) return false;

            // додати перевірку рівня підписки

            return true;
        }

        public async Task<bool> HasAccessToEpisodeAsync(int userId, int episodeId)
        {
            var episode = await _repository.GetEpisodeByIdAsync(episodeId);
            if (episode == null) return false;

            return await HasAccessToVideoAsync(userId, episode.VideoSeason.VideoId);
        }

        public async Task<List<object>> GetSubscriptionHistoryAsync(int profileId)
        {
            var subscriptions = await _repository.GetUserSubscriptionsAsync(profileId);

            return subscriptions.Select(s => new
            {
                PlanName = s.SubscriptionPlan?.SubscriptionLevel?.Code ?? "Невідомо",
                StartDate = s.SubscriptionStart,
                EndDate = s.SubscriptionEnd,
                Status = s.Status,
                Amount = s.Payment?.Amount ?? 0,
                PaymentDate = s.Payment?.CreatedAt,
                PaymentMethod = s.Payment?.Method ?? "Невідомо"
            }).Cast<object>().ToList();
        }

        public async Task<bool> HasActiveSubscriptionAsync(int profileId)
        {
            return await _repository.HasActiveSubscriptionAsync(profileId);
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