using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Requests;
using StreamingService.Extensions;
using StreamingService.Services;
using System.Globalization;
using System.Security.Claims;

namespace StreamingService.Controllers;

public class MoviesController : Controller
{
    private readonly VideoService _videoService;
    private readonly VideoDetailsService _videoDetailsService;
    private readonly FavoritesService _favoritesService;
    public MoviesController(VideoDetailsService videoDetailsService, FavoritesService favoritesService, VideoService videoService)
    {
        _videoService = videoService;
        _videoDetailsService = videoDetailsService;
        _favoritesService = favoritesService;
        //_moviesService = moviesService;
        //_mockServise = mockService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        //var locale = CultureInfo.CurrentCulture.Name;
        var locale = "uk";
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
    public async Task<IActionResult> Play(int id, int? episodeId = null, bool isTrailer = false)
    {
        int userProfileId = GetCurrentUserProfileId();

        var vm = await _videoService.GetPlaybackAsync(userProfileId, id, episodeId, isTrailer);

        if (vm == null)
            return RedirectToAction("AccessDenied", new { videoId = id });

        return View(vm);
    }

    [HttpGet]
    public async Task<IActionResult> Info(int id)
    {
        //var locale = CultureInfo.CurrentCulture.Name;
        var locale = "uk";
        int userId = 0;
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0", out userId);
        }

        var model = await _videoDetailsService.GetVideoDetailsAsync(id, locale, userId);
        if (model == null)
            return NotFound();

        return Json(model);
    }

    [HttpGet]
    public async Task<IActionResult> InfoPartial(int id)
    {
        //var locale = CultureInfo.CurrentCulture.Name;
        var locale = "uk";
        int userId = 0;
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0", out userId);
        }

        var model = await _videoDetailsService.GetVideoDetailsAsync(id, locale, userId);
        if (model == null)
            return NotFound();

        return PartialView("~/Views/Shared/Partials/Modal/_VideoInfoModal.cshtml", model);
    }

    private int GetCurrentUserProfileId()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        Console.WriteLine("User id: " + userId);
        return userId;
    }

    [HttpGet]
    public IActionResult AccessDenied(int videoId)
    {
        ViewBag.VideoId = videoId;
        return View();
    }

    [HttpPost]
    [Route("api/history/save")]
    public async Task<IActionResult> SaveProgress([FromBody] SaveProgressRequest request)
    {
        if (request.EpisodeId <= 0)
            return BadRequest();

        int userProfileId = GetCurrentUserProfileId();

        bool isFullyWatched = request.Duration > 0 &&
                             (double)request.CurrentTime / request.Duration >= 0.9;

        await _videoService.SaveProgressAsync(userProfileId, request.EpisodeId, isFullyWatched, request.CurrentTime);
        return Ok();
    }
    
    [HttpGet]
    [Route("api/history/{episodeId}")]
    public async Task<IActionResult> GetProgress(int episodeId)
    {
        int userProfileId = GetCurrentUserProfileId();
        var progress = await _videoService.GetProgressAsync(userProfileId, episodeId);
        
        return Json(new { time = progress?.PausedWatchTime ?? 0 });
    }
}
