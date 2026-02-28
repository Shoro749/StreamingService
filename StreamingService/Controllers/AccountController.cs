using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;
using StreamingService.Resources;
using StreamingService.Services;
using System.Numerics;

namespace StreamingService.Controllers
{
    public class AccountController : Controller
    {
        private readonly PricingService _pricingService;
        public AccountController(PricingService pricingService)
        {
            _pricingService = pricingService;
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
        public IActionResult Subscription()
        {
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
