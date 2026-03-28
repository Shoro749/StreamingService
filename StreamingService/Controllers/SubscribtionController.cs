using Microsoft.AspNetCore.Mvc;
using StreamingService.Models;
using StreamingService.Services;
using System.Security.Claims;

namespace StreamingService.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly SubscriptionService _subscriptionService;
        //private readonly ProfileService _profileService;

        public SubscriptionController(SubscriptionService subscriptionService /*, ProfileService profileService*/)
        {
            _subscriptionService = subscriptionService;
            //_profileService = profileService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(string paymentMethod)
        {
            var pendingUserId = HttpContext.Session.GetInt32("PendingUserId");
            var selectedPlanId = HttpContext.Session.GetInt32("SelectedPlanId");

            if (!pendingUserId.HasValue || !selectedPlanId.HasValue)
            {
                return RedirectToAction("Index");
            }

            var result = await _subscriptionService.ProcessSubscriptionAsync(
                pendingUserId.Value,
                selectedPlanId.Value,
                paymentMethod ?? "Card");

            if (!result)
            {
                TempData["Error"] = "Не вдалося оформити підписку. Спробуйте ще раз.";
                return RedirectToAction("SubscriptionConfirmation");
            }

            return RedirectToAction("Success", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> MyPlan()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var plan = await _subscriptionService.GetCurrentPlanInfoAsync(userId);

            if (plan == null)
            {
                TempData["Info"] = "У вас немає активної підписки";
                return RedirectToAction("Index");
            }

            return View(plan);
        }

        [HttpPost]
        public async Task<IActionResult> CancelAutoRenewal()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = await _subscriptionService.CancelAutoRenewalAsync(userId);

            if (result)
            {
                TempData["Success"] = "Автопродовження вимкнено. Підписка діє до кінця оплаченого періоду.";
            }
            else
            {
                TempData["Error"] = "Не вдалося скасувати автопродовження";
            }

            return RedirectToAction("MyPlan");
        }

        [HttpPost]
        public async Task<IActionResult> Cancel()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = await _subscriptionService.CancelSubscriptionAsync(userId);

            if (result)
            {
                TempData["Success"] = "Підписку скасовано";
            }
            else
            {
                TempData["Error"] = "Не вдалося скасувати підписку";
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> History()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var history = await _subscriptionService.GetSubscriptionHistoryAsync(userId);

            return View(history);
        }
    }
}