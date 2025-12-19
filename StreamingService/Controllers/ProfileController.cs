using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO;
using StreamingService.Services;

namespace StreamingService.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ProfileService _profileService;

        public ProfileController(IMapper mapper, ProfileService profileService)
        {
            _mapper = mapper;
            _profileService = profileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, errorMessage) = await _profileService.CreateUserProfileAsync(model);

            if (success)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, errorMessage);
            return View(model);
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = "/"
            }, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            return SignOut(new AuthenticationProperties
            {
                RedirectUri = "/"
            }, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
