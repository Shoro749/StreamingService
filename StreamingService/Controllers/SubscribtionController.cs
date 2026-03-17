using Microsoft.AspNetCore.Mvc;
using StreamingService.Models;
using StreamingService.Services;

namespace StreamingService.Controllers
{
    public class SubscribtionController : Controller
    {
        private readonly SubscriptionService _subscriptionService;

        public SubscribtionController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe(int profileId, int planId, string provider = "Stripe")
        {
            var result = await _subscriptionService.ProcessSubscriptionAsync(profileId, planId, provider);
            if (result) return Ok(new { message = "Підписку успішно оформлено" });
            return BadRequest("Не вдалося оформити підписку");
        }

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
