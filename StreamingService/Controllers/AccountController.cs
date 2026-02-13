using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;
using StreamingService.Resources;
using StreamingService.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StreamingService.Controllers
{
    public class AccountController : Controller
    {
        private readonly PricingService _pricingService;
        private readonly ProfileService _profileService;
        private readonly SubscriptionService _subscriptionService;

        public AccountController(PricingService pricingService, ProfileService profileService, SubscriptionService subscriptionService)
        {
            _pricingService = pricingService;
            _profileService = profileService;
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginViewModel
            {
                BackgroundText = AuthTexts.SignInBackground
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Register(string? email, string? plan)
        {
            var model = new AuthPageViewModel
            {
                Email = email,
                SubscriptionPlan = plan,
                BackgroundText = AuthTexts.SignupBackground
            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Subscription()
        {
            //var pendingUserId = HttpContext.Session.GetInt32("PendingUserId");

            //if (!pendingUserId.HasValue)
            //{
            //    return RedirectToAction("Register", "Account");
            //}

            //var plans = _subscriptionService.GetAllPlansAsync();

            //var model = new SubscriptionViewModel
            //{
            //    UserId = pendingUserId.Value,
            //    Plans = plans,
            //    BackgroundText = "LUMEO" // Або ваш текст
            //};
            //return View(model);
            var model = new SubscriptionViewModel
            {
                BackgroundText = AuthTexts.SubscriptionBackground,
                Plans = _pricingService.GetPricingPlans()
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Agreement(string plan)
        {
            var model = new AgreementViewModel
            {
                BackgroundText = AuthTexts.SubscriberAgreementBackground,
                SubscriptionPlan = plan
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult SubscriptionConfirmation(string plan)
        {
            var model = new AgreementViewModel
            {
                BackgroundText = AuthTexts.SubscriptionConfirmationBackground,
                SubscriptionPlan = plan
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Success(string plan)
        {
            var model = new AgreementViewModel
            {
                BackgroundText = AuthTexts.SuccessScreenBackground,
                SubscriptionPlan = plan
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Register(AuthPageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.BackgroundText = AuthTexts.SignupBackground;
                return View(model);
            }

            // ТУТ МАЄ БУТИ КОД СТВОРЕННЯ КОРИСТУВАЧА В БАЗІ ДАНИХ (Identity)

            if (!string.IsNullOrEmpty(model.SubscriptionPlan))
            {
                // СЦЕНАРІЙ 1: План вже обраний (наприклад, прийшов з email)
                return RedirectToAction("Agreement", new { plan = model.SubscriptionPlan });
            }
            else
            {
                // СЦЕНАРІЙ 2: Плану ще немає
                return RedirectToAction("Subscription");
            }
        }
    }
}
