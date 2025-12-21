using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;
using StreamingService.Models;
using StreamingService.Services;
using System.Diagnostics;

namespace StreamingService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomePageService _service;

        public HomeController(ILogger<HomeController> logger, HomePageService service)
        {
            _logger = logger;
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
