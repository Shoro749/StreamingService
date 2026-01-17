using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;
using StreamingService.Services;
using System.Numerics;

namespace StreamingService.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ProfileService _profileService;

        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserProfileViewModel model)
        {
            var result = await _profileService.CreateUserProfileAsync(model);
            if (result) return Ok(new { message = "Користувача успішно зареєстровано" });
            return BadRequest("Не вдалося зареєструвати користувача");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserProfileViewModel model)
        {
            //login
            return BadRequest("Не увійти");
        }

        [HttpGet("google-login")]
        public IActionResult GoogleLogin()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = "/"
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
    }
}
