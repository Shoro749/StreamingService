using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;
using StreamingService.Services;
using System.Globalization;
using System.Security.Claims;

namespace StreamingService.ViewComponents;

public class VideoSectionViewComponent : ViewComponent
{
    // підключення Mock-сервісу для тестування UI (робота з каталогом, улюбленым, сторінкой "Незабаром").
    private readonly IMoviesService _moviesService;

    public VideoSectionViewComponent(IMoviesService moviesService)
    {
        _moviesService = moviesService;
    }

    //private readonly MoviesService _moviesService;

    //public VideoSectionViewComponent(MoviesService moviesService)
    //{
    //    _moviesService = moviesService;
    //}

    public async Task<IViewComponentResult> InvokeAsync(string title, string sectionId, string linkUrl, string? genre = null)
    {
        var locale = CultureInfo.CurrentCulture.Name.Split('-')[0];

        int? userId = null;
        if (UserClaimsPrincipal?.Identity?.IsAuthenticated ?? false)
        {
            var userIdClaim = UserClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userIdClaim))
            {
                userId = int.Parse(userIdClaim);
            }
        }

        List<VideoCardViewModel> videos = sectionId switch
        {
            "featured" => await _moviesService.GetSliderAsync(locale, userId),
            "action" => await _moviesService.GetPopularAsync(locale, userId),
            "popular" => await _moviesService.GetPopularAsync(locale, userId),
            "newReleases" => await _moviesService.GetNewReleasesAsync(locale, userId),
            "trending" => await _moviesService.GetTrendingAsync(locale, userId),
            "weeklyHits" => await _moviesService.GetWeeklyHitsAsync(locale, userId),
            _ => await _moviesService.GetPopularAsync(locale, userId)
        };

        var model = new VideoSectionViewModel
        {
            Title = title,
            SectionId = sectionId,
            LinkUrl = linkUrl,
            Videos = videos ?? new List<VideoCardViewModel>()
        };

        return View(model);
    }

    //public async Task<IViewComponentResult> InvokeAsync(string title, string sectionId, string linkUrl, string? genre = null)
    //{
    //    var locale = CultureInfo.CurrentCulture.Name.Split('-')[0];

    //    List<VideoCardViewModel> videos;

    //    if (!string.IsNullOrEmpty(genre))
    //    {
    //        videos = await _moviesService.GetByGenreAsync(genre, locale);
    //    }
    //    else
    //    {
    //        videos = sectionId switch
    //        {
    //            "featured" => await _moviesService.GetSliderAsync(locale),
    //            "popular" => await _moviesService.GetPopularAsync(locale),
    //            "newReleases" => await _moviesService.GetNewReleasesAsync(locale),
    //            "trending" => await _moviesService.GetTrendingAsync(locale),
    //            "weeklyHits" => await _moviesService.GetWeeklyHitsAsync(locale),
    //            _ => await _moviesService.GetPopularAsync(locale)
    //        };
    //    }

    //    var model = new VideoSectionViewModel
    //    {
    //        Title = title,
    //        SectionId = sectionId,
    //        LinkUrl = linkUrl,
    //        Videos = videos ?? new List<VideoCardViewModel>()
    //    };

    //    return View(model);
    //}
}

