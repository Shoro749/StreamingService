using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Extensions;
using StreamingService.Services;
using System.Globalization;
using System.Security.Claims;

namespace StreamingService.Controllers;

public class MoviesController : Controller
{
    //private readonly MoviesService _service;
    private readonly VideoDetailsService _videoDetailsService;
    private readonly FavoritesService _favoritesService;
    public MoviesController(VideoDetailsService videoDetailsService, FavoritesService favoritesService /*MoviesService service*/)
    {
        //_service = service;
        _videoDetailsService = videoDetailsService;
        _favoritesService = favoritesService;
    }

    //[HttpGet("home")]
    //public async Task<IActionResult> Index([FromQuery] string locale = "uk")
    //{
    //    var model = new HomePageViewModel
    //    {
    //        Slider = await _service.GetSliderAsync(locale),
    //        Popular = await _service.GetPopularAsync(locale),
    //        Trending = await _service.GetTrendingAsync(locale),
    //        NewReleases = await _service.GetNewReleasesAsync(locale),
    //        WeeklyHits = await _service.GetWeeklyHitsAsync(locale)
    //    };

    //    return View(model);
    //}

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var locale = CultureInfo.CurrentCulture.Name;
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

        var movie = await _videoDetailsService.GetVideoDetailsAsync(id, locale, userId);

        if (movie == null)
        {
            return NotFound();
        }

        ViewData["MenuTitle"] = movie.VideoType.GetShortName();
        ViewData["Category"] = movie.VideoType;

        // Рекомендовані відео
        var recommendedVideos = await _videoDetailsService.GetRecommendedVideosAsync(id, locale, 10);
        ViewBag.RecommendedVideos = recommendedVideos;

        return View(movie);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Play(int id)
    {
        var locale = CultureInfo.CurrentCulture.Name;
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

        var video = await _videoDetailsService.GetVideoDetailsAsync(id, locale, userId);

        if (video == null)
        {
            return NotFound();
        }

        return View(video);
    }

    //public IActionResult Details(int id)
    //{
    //    var movie = MockVideoService.GetAllVideos()
    //        .Concat(MockUpcomingService.GetUpcomingReleases())
    //        .FirstOrDefault(v => v.Id == id);

    //    if (movie == null)
    //    {
    //        return NotFound();
    //    }

    //    ViewData["MenuTitle"] = movie.VideoType.GetShortName();
    //    ViewData["Category"] = movie.VideoType;

    //    var recommendedVideos = MockVideoService.GetAllVideos()
    //        .Where(video => video.Id != id)
    //        .Take(10)
    //        .ToList();

    //    ViewBag.RecommendedVideos = recommendedVideos;

    //    return View(movie);
    //}

    //public IActionResult Play(int id)
    //{
    //    var video = MockVideoService.GetAllVideos()
    //        .FirstOrDefault(v => v.Id == id);

    //    if (video == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(video);
    //}
}
