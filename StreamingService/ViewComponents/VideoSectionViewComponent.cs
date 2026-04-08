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

    // підключення заголовків для різних сторінок, в залежності від типу відео (фільми, серіали, мультфільми).
    private static readonly Dictionary<(string, VideoType?), string> SectionTitles = new()
    {
        { ("action", VideoType.AnimatedSeries), "Герої поруч із тобою."},
        { ("action", VideoType.AnimatedMovie), "Фантазія на повну."},
        { ("action", VideoType.Series), "Один епізод — і ти в історії."},
        { ("action", VideoType.Movie), "Вибух емоцій у кожному кадрі"},
        { ("action", null), "Вибух емоцій у кожному кадрі"},

        { ("popular", VideoType.AnimatedSeries), "Лови пригоди!" },
        { ("popular", VideoType.AnimatedMovie), "Миттєво в казці." },
        { ("popular", VideoType.Series), "Залежність на всю ніч." },
        { ("popular", VideoType.Movie), "Те, що всі обговорюють" },
        { ("popular", null), "Те, що всі обговорюють" },

        { ("newReleases", VideoType.AnimatedSeries), "Барви твоєї уяви." },
        { ("newReleases", VideoType.AnimatedMovie), "Маленькі пригоди — велике задоволення." },
        { ("newReleases", VideoType.Series), "Драма, шок, емоції." },
        { ("newReleases", VideoType.Movie), "Не пропусти цього тижня!" },
        { ("newReleases", null), "Не пропусти цього тижня!" }
    };
    public VideoSectionViewComponent(IMoviesService moviesService)
    {
        _moviesService = moviesService;
    }
    // TODO для бекенду: Цей конструктор поки закоментований поки відсутні дані бази.
    //private readonly MoviesService _moviesService;

    //public VideoSectionViewComponent(MoviesService moviesService)
    //{
    //    _moviesService = moviesService;
    //}

    // Тут Додано VideoType? category = null у параметри для фільтрації за типом відео
    public async Task<IViewComponentResult> InvokeAsync(string title, string sectionId, string linkUrl, string? genre = null, VideoType? category = null)
    {
        //var locale = CultureInfo.CurrentCulture.Name.Split('-')[0];
        var locale = "uk";

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
        // ФІЛЬТРУЄМО СПИСОК (залишаємо тільки потрібну категорію)       
        if (category != null && videos != null)
        {
            videos = videos.Where(v => v.VideoType == category).ToList();
        }
        //ПРИБИРАЄМО ПУСТІ СЕКЦІЇ
        if (videos == null || !videos.Any())
        {
            return Content(string.Empty);
        }
        // ВИЗНАЧАЄМО ЗАГОЛОВОК СЕКЦІЇ ВІДПОВІДНО ДО ТИПУ ВІДЕО
        string currentTitle = title;
        if (SectionTitles.TryGetValue((sectionId, category), out var foundTitle))
        {
            currentTitle = foundTitle;
        }

        var model = new VideoSectionViewModel
        {
            Title = currentTitle,
            SectionId = sectionId,
            LinkUrl = linkUrl,
            Videos = videos ?? new List<VideoCardViewModel>()
        };

        return View(model);
    }
}

