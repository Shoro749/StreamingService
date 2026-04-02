using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;
using StreamingService.Services;
using System.Globalization;
using System.Security.Claims;

namespace StreamingService.ViewComponents;

public class VideoSectionViewComponent : ViewComponent
{
    private readonly MoviesService _moviesService;

    public VideoSectionViewComponent(MoviesService moviesService)
    {
        _moviesService = moviesService;
    }

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

        VideoType? mediaType = null;
        if (ViewContext?.ViewData != null && ViewContext.ViewData.ContainsKey("Category"))
        {
            var cat = ViewContext.ViewData["Category"];
            if (cat is VideoType vt) mediaType = vt;
            else if (cat is string s && Enum.TryParse<VideoType>(s, true, out var parsed)) mediaType = parsed;
        }

        List<VideoCardViewModel> videos = sectionId switch
        {
            "featured" => await _moviesService.GetSliderAsync(locale, userId, mediaType),
            "action" => await _moviesService.GetPopularAsync(locale, userId, mediaType),
            "popular" => await _moviesService.GetPopularAsync(locale, userId, mediaType),
            "newReleases" => await _moviesService.GetNewReleasesAsync(locale, userId, mediaType),
            "trending" => await _moviesService.GetTrendingAsync(locale, userId, mediaType),
            "weeklyHits" => await _moviesService.GetWeeklyHitsAsync(locale, userId),
            _ => await _moviesService.GetPopularAsync(locale, userId, mediaType)
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
}

