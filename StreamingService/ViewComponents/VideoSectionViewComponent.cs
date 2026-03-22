using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;
using StreamingService.Services;

namespace StreamingService.ViewComponents;

public class VideoSectionViewComponent : ViewComponent
{
    private static readonly Dictionary<(string, VideoType?), string> SectionTitles = new()
    {
        { ("action", VideoType.AnimatedSeries), "Герої поруч із тобою"},
        { ("action", VideoType.AnimatedMovie), "Фантазія на повну"},
        { ("action", VideoType.Series), "Один епізод — і ти в історії"},
        { ("action", VideoType.Movie), "Вибух емоцій у кожному кадрі"},
        { ("action", null), "Вибух емоцій у кожному кадрі"},

        { ("popular", VideoType.AnimatedSeries), "Лови пригоди!" },
        { ("popular", VideoType.AnimatedMovie), "Миттєво в казці" },
        { ("popular", VideoType.Series), "Залежність на всю ніч" },
        { ("popular", VideoType.Movie), "Те, що всі обговорюють" },
        { ("popular", null), "Те, що всі обговорюють" },

        { ("newReleases", VideoType.AnimatedSeries), "Барви твоєї уяви" },
        { ("newReleases", VideoType.AnimatedMovie), "Маленькі пригоди — велике задоволення" },
        { ("newReleases", VideoType.Series), "Драма, шок, емоції" },
        { ("newReleases", VideoType.Movie), "Не пропусти цього тижня!" },
        { ("newReleases", null), "Не пропусти цього тижня!" }
    };
    public IViewComponentResult Invoke(VideoType? category, string sectionId, string linkUrl, List<VideoCardViewModel> videos)
    {
        string currentTitle = "";
       
        if (SectionTitles.TryGetValue((sectionId, category), out var foundTitle))
        {
            currentTitle = foundTitle;
        }
        
        var model = new VideoSectionViewModel
        {
            Title = currentTitle,
            SectionId = sectionId,
            LinkUrl = linkUrl,
            Videos = videos
        };

        return View(model);
    }
}

