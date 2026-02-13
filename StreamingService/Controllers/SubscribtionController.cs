using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Models;
using StreamingService.Services;
using System.Security.Claims;

namespace StreamingService.Controllers
{
    public class SubscribtionController : Controller
    {
        private readonly SubscriptionService _subscriptionService;
        private readonly ProfileService _profileService;

        public SubscribtionController(SubscriptionService subscriptionService, ProfileService profileService)
        {
            _subscriptionService = subscriptionService;
            _profileService = profileService;
        }

        //[HttpPost]
        //public async Task<bool> ProcessSubscriptionAsync(int profileId, int planId, string provider = "Stripe")
        //{
        //    var plan = await _subscriptionService.GetCurrentPlanInfoAsync(planId);
        //    if (plan == null || !plan.IsEnabled)
        //        return false;

        //    // 1. Створюємо Payment зі статусом "Pending"
        //    var payment = new Payment
        //    {
        //        Amount = plan.Price,
        //        Currency = "UAH",
        //        Provider = provider,
        //        Method = "Card",
        //        Status = "Pending", // Чекаємо на оплату
        //        CreatedAt = DateTime.UtcNow
        //    };

        //    var paymentResult = await _paymentGateway.CreatePaymentAsync(payment);

        //    if (!paymentResult.Success)
        //        return false;

        //    // 3. Оновлюємо статус оплати
        //    payment.Status = "Completed";
        //    payment.TransactionId = paymentResult.TransactionId;

        //    // 4. Створюємо підписку
        //    var subscription = new UserSubscription
        //    {
        //        UserProfileId = profileId,
        //        SubscriptionPlanId = planId,
        //        Status = "Active",
        //        AutoRenew = true,
        //        SubscriptionStart = DateTime.UtcNow,
        //        SubscriptionEnd = DateTime.UtcNow.AddDays(plan.PeriodDays)
        //    };

        //    return await _repository.CreateSubscriptionWithPayment(subscription, payment);
        //}

        [HttpGet("my-plan")]
        public async Task<IActionResult> GetMyPlan(int profileId)
        {
            var plan = await _subscriptionService.GetCurrentPlanInfoAsync(profileId);
            if (plan == null) return NotFound("Активної підписки не знайдено");
            return Ok(plan);
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> Cancel(int profileId)
        {
            var success = await _subscriptionService.CancelSubscriptionAsync(profileId);
            if (!success) return BadRequest("Не вдалося скасувати підписку");
            return Ok(new { message = "Автопродовження вимкнено. Підписка діє до кінця оплаченого періоду." });
        }
    }
}
