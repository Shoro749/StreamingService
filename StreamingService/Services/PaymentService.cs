using StreamingService.Models;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class PaymentService
    {
        private readonly PaymentsRepository _repository;

        public PaymentService(PaymentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ProcessSubscriptionAsync(int profileId, int planId, string provider)
        {
            var plan = await _repository.GetPlanAsync(planId);
            if (plan == null || !plan.IsEnabled) return false;

            var payment = new Payment
            {
                Amount = plan.Price,
                Currency = "UAH",
                Provider = provider,
                Method = "Card",
                Status = "Completed",
                CreatedAt = DateTime.UtcNow
            };

            var subscription = new UserSubscription
            {
                UserProfileId = profileId,
                SubscriptionPlanId = planId,
                Status = "Active",
                AutoRenew = true,
                SubscriptionStart = DateTime.UtcNow,
                SubscriptionEnd = DateTime.UtcNow.AddDays(plan.PeriodDays)
            };

            return await _repository.CreateSubscriptionWithPayment(subscription, payment);
        }

        public async Task<object?> GetCurrentPlanInfoAsync(int profileId)
        {
            var sub = await _repository.GetActiveSubscriptionAsync(profileId);
            if (sub == null) return null;

            return new
            {
                PlanName = sub.SubscriptionPlan.SubscriptionLevel.Code,
                EndDate = sub.SubscriptionEnd,
                Status = sub.Status,
                IsAutoRenew = sub.AutoRenew
            };
        }

        public async Task<bool> CancelSubscriptionAsync(int profileId)
        {
            var sub = await _repository.GetActiveSubscriptionAsync(profileId);
            if (sub == null) return false;

            return await _repository.UpdateSubscriptionStatusAsync(sub.Id, "Active", false);
        }
    }
}
