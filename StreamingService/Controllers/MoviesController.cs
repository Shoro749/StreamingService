using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Extensions;
using StreamingService.Services;
using System.Globalization;
using System.Security.Claims;

namespace StreamingService.Controllers;

public class MoviesController : Controller
{
    //private readonly MoviesService _moviesService;
   // private readonly FavoritesService _favoritesService;
    private readonly VideoDetailsService _videoDetailsService;
    private readonly IMoviesService _moviesService; // для тестування UI.
    private readonly IFavoritesService _favoritesService; // для тестування UI.
    private readonly MockVideoService _mockServise; // Mock-сервіс для тестування UI.


    // TODO для бекенду: Перевів контролер на інтерфейси (IMoviesService, IFavoritesService), 
    // щоб підключити MockVideoService для тестування верстки. 
    // Коли база буде готова, просто перемкніть реалізацію в Program.cs.
    public MoviesController(VideoDetailsService videoDetailsService, IFavoritesService favoritesService, IMoviesService moviesService, MockVideoService mockService)
    {
        _videoDetailsService = videoDetailsService;
        _favoritesService = favoritesService;
        _moviesService = moviesService;
        _mockServise = mockService;
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

    // TODO для бекенду: Ці методи поки закоментовані поки відсутні дані бази, але вони потрібні для тестування UI.
    //[Authorize]
    //[HttpGet]
    //public async Task<IActionResult> Details(int id)
    //{
    //    var locale = CultureInfo.CurrentCulture.Name;
    //    var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

    //    var movie = await _videoDetailsService.GetVideoDetailsAsync(id, locale, userId);

    //    if (movie == null)
    //    {
    //        return NotFound();
    //    }

    //    ViewData["MenuTitle"] = movie.VideoType.GetShortName();
    //    ViewData["Category"] = movie.VideoType;

    //    // Рекомендовані відео
    //    var recommendedVideos = await _videoDetailsService.GetRecommendedVideosAsync(id, locale, 10);
    //    ViewBag.RecommendedVideos = recommendedVideos;

    //    return View(movie);
    //}

    //[Authorize]
    //[HttpGet]
    //public async Task<IActionResult> Play(int id)
    //{
    //    var locale = CultureInfo.CurrentCulture.Name;
    //    var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

    //    var video = await _videoDetailsService.GetVideoDetailsAsync(id, locale, userId);

    //    if (video == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(video);
    //}

    // Методи Details та Play для тестування UI з Mock-сервісом.
    public IActionResult Details(int id)
    {
        var movie = _mockServise.GetAllVideos()
            .FirstOrDefault(v => v.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        ViewData["MenuTitle"] = movie.VideoType.GetShortName();
        ViewData["Category"] = movie.VideoType;

        var recommendedVideos = _mockServise.GetAllVideos()
            .Where(video => video.Id != id)
            .Take(10)
            .ToList();

        ViewBag.RecommendedVideos = recommendedVideos;

        return View(movie);
    }

    public IActionResult Play(int id, bool isTrailer = false)
    {
        var video = _mockServise.GetAllVideos()
            .FirstOrDefault(v => v.Id == id);

        if (video == null)
        {
            return NotFound();
        }

        ViewBag.isTrailer = isTrailer;
        if (isTrailer && !string.IsNullOrEmpty(video.TrailerUrl)) 
        {
            var embedUrl = video.TrailerUrl;
            if (embedUrl.Contains("watch?v="))
            {
                embedUrl = embedUrl.Replace("watch?v=", "embed/").Split('&')[0];
            }
            else if (embedUrl.Contains("youtu.be/"))
            {
                embedUrl = embedUrl.Replace("youtu.be/", "youtube.com/embed/").Split('?')[0];
            }
            ViewBag.TrailerEmbedUrl = $"{embedUrl}?autoplay=1&rel=0&modestbranding=1";
        }
        return View(video);
    }
}
