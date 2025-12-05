using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Context;
using StreamingService.DTO;
using StreamingService.Models;
using StreamingService.Services;
using System.Diagnostics;

namespace StreamingService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        private readonly HomePageService _service;

        public HomeController(ILogger<HomeController> logger, DataContext context, HomePageService service)
        {
            _logger = logger;
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> Index([FromQuery] string locale = "uk")
        {
            var model = new HomePageViewModel
            {
                Slider = await _service.GetSliderAsync(locale),
                Popular = await _service.GetPopularAsync(locale),
                Trending = await _service.GetTrendingAsync(locale),
                NewReleases = await _service.GetNewReleasesAsync(locale),
                WeeklyHits = await _service.GetWeeklyHitsAsync(locale)
            };

            return View(model);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetHomeRecommendations([FromQuery] string locale = "uk")
        //{
        //    var slider = await _service.GetSliderAsync(locale);
        //    var popular = await _service.GetPopularAsync(locale);
        //    var trending = await _service.GetTrendingAsync(locale);
        //    var recent = await _service.GetNewReleasesAsync(locale);
        //    var weekly = await _service.GetWeeklyHitsAsync(locale);

        //    return Ok(new
        //    {
        //        Slider = slider,
        //        Popular = popular,
        //        Trending = trending,
        //        NewReleases = recent,
        //        WeeklyHits = weekly
        //    });
        //}

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
