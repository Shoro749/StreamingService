using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;
using StreamingService.Services;

namespace StreamingService.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesService _service;
        public MoviesController(MoviesService service)
        {
            _service = service;
        }

        [HttpGet("home")]
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
    }
}
