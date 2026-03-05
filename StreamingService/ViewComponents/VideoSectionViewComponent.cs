using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;
using StreamingService.Services;
using System.Globalization;

namespace StreamingService.ViewComponents;

public class VideoSectionViewComponent : ViewComponent
{
    private readonly MoviesService _moviesService;

    public VideoSectionViewComponent(MoviesService moviesService)
    {
        _moviesService = moviesService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string title, string sectionId, string linkUrl)
    {
        var locale = CultureInfo.CurrentCulture.Name.Split('-')[0];

        List<VideoCardViewModel> videos = sectionId switch
        {
            "featured" => await _moviesService.GetSliderAsync(locale),
            "action" => await _moviesService.GetPopularAsync(locale),
            "popular" => await _moviesService.GetPopularAsync(locale),
            "newReleases" => await _moviesService.GetNewReleasesAsync(locale),
            "trending" => await _moviesService.GetTrendingAsync(locale),
            "weeklyHits" => await _moviesService.GetWeeklyHitsAsync(locale),
            _ => await _moviesService.GetPopularAsync(locale)
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

