using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;
using StreamingService.Models;
using StreamingService.Resources;
using StreamingService.Services;
using System.Numerics;
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
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
            {
                return RedirectToAction("Register", "Account");
            }

            var plans = await _subscriptionService.GetAllPlansAsync();

            var model = new SubscriptionViewModel
            {
                UserId = userId,
                Plans = plans.Select(p => new SubscriptionPlanDto
                {
                    Id = p.Id,
                    Name = p.SubscriptionLevel?.Code ?? "Невідомо",
                    Price = p.Price,
                    PeriodDays = p.PeriodDays,
                    Description = $"Підписка на {p.PeriodDays} днів",
                    Features = p.Features
                }).ToList(),
                BackgroundText = "LUMEO"
            };

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Agreement(int planId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
            {
                return RedirectToAction("Register", "Account");
            }

            var plan = await _subscriptionService.GetPlanByIdAsync(planId);

            if (plan == null)
            {
                TempData["Error"] = "План не знайдено";
                return RedirectToAction("Index");
            }

            HttpContext.Session.SetInt32("SelectedPlanId", planId);

            var model = new AgreementViewModel
            {
                SubscriptionPlan = plan.SubscriptionLevel?.Code ?? "PLAN",
                BackgroundText = "LUMEO"
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SubscriptionConfirmation()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var selectedPlanId = HttpContext.Session.GetInt32("SelectedPlanId");

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId) || !selectedPlanId.HasValue)
            {
                return RedirectToAction("Index");
            }

            var plan = await _subscriptionService.GetPlanByIdAsync(selectedPlanId.Value);

            if (plan == null)
            {
                TempData["Error"] = "План не знайдено";
                return RedirectToAction("Index");
            }

            var model = new AgreementViewModel
            {
                SubscriptionPlan = plan.SubscriptionLevel?.Code ?? "PLAN",
                SubscriptionPrice = plan.Price,
                BackgroundText = "LUMEO"
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
        public async Task<IActionResult> Register(AuthPageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.BackgroundText = AuthTexts.SignInBackground;
                return View("~/Views/Account/Register.cshtml", model);
            }

            var user = await _profileService.GetByEmailAsync(model.Email);

            if (user != null)
            {
                ModelState.AddModelError("Email", "Користувач з такою поштою уже існує");
                model.BackgroundText = AuthTexts.SignInBackground;
                return View("~/Views/Account/Register.cshtml", model);
            }

            var newUser = new UserProfile
            {
                Username = model.Name + " " + model.Surname,
                Email = model.Email,
                PasswordHash = PasswordHasher.HashPassword(model.Password),
            };

            var isCreated = await _profileService.CreateUserProfileAsync(newUser);

            if (!isCreated)
            {
                ModelState.AddModelError("", "Помилка при створенні користувача");
                model.BackgroundText = AuthTexts.SignInBackground;
                return View("~/Views/Account/Register.cshtml", model);
            }

            var createdUser = await _profileService.GetByEmailAsync(model.Email);

            HttpContext.Session.SetInt32("PendingUserId", createdUser.Id);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, createdUser.Id.ToString()),
                new Claim(ClaimTypes.Name, createdUser.Username),
                new Claim(ClaimTypes.Email, createdUser.Email),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                new AuthenticationProperties
                {
                    IsPersistent = false,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(12)
                }
            );

            return RedirectToAction("Subscription", "Account");
        }
    }
}
