using Microsoft.AspNetCore.Mvc;
using StreamingService.Services;

namespace StreamingService.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly PaymentService _paymentService;

        public PaymentsController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(int profileId, int planId, string provider = "Stripe")
        {
            var result = await _paymentService.ProcessSubscriptionAsync(profileId, planId, provider);
            if (result) return Ok(new { message = "Підписку успішно оформлено" });
            return BadRequest("Не вдалося оформити підписку");
        }

        [HttpGet]
        public async Task<IActionResult> GetMyPlan(int profileId)
        {
            var plan = await _paymentService.GetCurrentPlanInfoAsync(profileId);
            if (plan == null) return NotFound("Активної підписки не знайдено");
            return Ok(plan);
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int profileId)
        {
            var success = await _paymentService.CancelSubscriptionAsync(profileId);
            if (!success) return BadRequest("Не вдалося скасувати підписку");
            return Ok(new { message = "Автопродовження вимкнено. Підписка діє до кінця оплаченого періоду." });
        }
    }
}
