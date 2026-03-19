using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;
using StreamingService.Extensions;
using StreamingService.Models;
using StreamingService.Services;

namespace StreamingService.Controllers;

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

    public IActionResult Details(int id)
    {
        var movie = MockVideoService.GetAllVideos()
            .Concat(MockUpcomingService.GetUpcomingReleases())
            .FirstOrDefault(v => v.Id == id);

        if (movie == null)
        {
            return NotFound();
        }
        
        ViewData["MenuTitle"] = movie.VideoType.GetShortName();
        ViewData["Category"] = movie.VideoType;
        
        var recommendedVideos = MockVideoService.GetAllVideos()
            .Where(video => video.Id != id)
            .Take(10)
            .ToList();

        ViewBag.RecommendedVideos = recommendedVideos;

        return View(movie);
    }
}
