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

        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
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

            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                bool isPasswordValid = PasswordHasher.VerifyPassword(model.Password, user.PasswordHash);
                if (!isPasswordValid)
                {
                    ModelState.AddModelError("Password", "Невірний пароль");
                    return View("~/Views/Account/Login.cshtml", model);
                }
            }
            else
            {
                ModelState.AddModelError("Password", "Цей акаунт створений через Google. Увійдіть через Google.");
                return View("~/Views/Account/Login.cshtml", model);
            }

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

            return RedirectToAction("Movies", "Home");
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

            return RedirectToAction("Subscription", "Home");
        }

        [HttpPost]
        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action("GoogleCallback", "Profile", null, Request.Scheme);

            return Challenge(new AuthenticationProperties
            {
                RedirectUri = redirectUrl
            }, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("google-logout")]
        public IActionResult GoogleLogout()
        {
            return SignOut(new AuthenticationProperties
            {
                RedirectUri = "/"
            }, CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public async Task<IActionResult> GoogleCallback()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("Movies", "Home");
        }
    }
}
