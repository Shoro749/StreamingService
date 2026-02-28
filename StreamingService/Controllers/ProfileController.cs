using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;
using StreamingService.Models;
using StreamingService.Resources;
using StreamingService.Services;
using System.Numerics;
using System.Security.Claims;

namespace StreamingService.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ProfileService _profileService;
        private readonly SubscriptionService _subscriptionService;

        public ProfileController(ProfileService profileService, SubscriptionService subscriptionService)
        {
            _profileService = profileService;
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.BackgroundText = AuthTexts.SignInBackground;
                return View("~/Views/Account/Login.cshtml", model);
            }

            var user = await _profileService.GetByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "Користувача з такою поштою не знайдено");
                model.BackgroundText = AuthTexts.SignInBackground;
                return View("~/Views/Account/Login.cshtml", model);
            }

            if (string.IsNullOrEmpty(user.PasswordHash))
            {
                ModelState.AddModelError("Password", "Цей акаунт створений через Google. Використайте кнопку 'Увійти через Google'.");
                model.BackgroundText = AuthTexts.SignInBackground;
                return View("~/Views/Account/Login.cshtml", model);
            }

            bool isPasswordValid = PasswordHasher.VerifyPassword(model.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                ModelState.AddModelError("Password", "Невірний пароль");
                model.BackgroundText = AuthTexts.SignInBackground;
                return View("~/Views/Account/Login.cshtml", model);
            }

            var hasSubscription = await _subscriptionService.HasActiveSubscriptionAsync(user.Id);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
            };

            if (!string.IsNullOrEmpty(user.AvatarUrl))
            {
                claims.Add(new Claim("AvatarUrl", user.AvatarUrl));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.IsPersistent,
                ExpiresUtc = model.IsPersistent
                    ? DateTimeOffset.UtcNow.AddDays(30)
                    : DateTimeOffset.UtcNow.AddHours(12)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                authProperties);

            if (!hasSubscription)
            {
                HttpContext.Session.SetInt32("PendingUserId", user.Id);
                TempData["Info"] = "Для продовження оберіть тарифний план";
                return RedirectToAction("Subscription", "Account");
            }

            return RedirectToAction("Movies", "Home");
        }

        [HttpPost]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleCallback", "Profile"),  // Зробити реєстрацію для нових акаунтів з гугл
                IsPersistent = false
            };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> GoogleCallback()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
            {
                TempData["Error"] = "Помилка входу через Google";
                return RedirectToAction("Login", "Account");
            }

            var userId = authenticateResult.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                TempData["Error"] = "Не вдалося отримати дані користувача";
                return RedirectToAction("Login", "Account");
            }

            var hasSubscription = await _subscriptionService.HasActiveSubscriptionAsync(int.Parse(userId));

            if (!hasSubscription)
            {
                HttpContext.Session.SetInt32("PendingUserId", int.Parse(userId));
                return RedirectToAction("Subscription", "Account");
            }

            return RedirectToAction("Movies", "Home");
        }
    }
}
