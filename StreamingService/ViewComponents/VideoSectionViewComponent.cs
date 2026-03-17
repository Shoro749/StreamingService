using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;
using StreamingService.Services;

namespace StreamingService.ViewComponents;

public class VideoSectionViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(string title, string sectionId, string linkUrl, List<VideoCardViewModel> videos)
    {        
        var model = new VideoSectionViewModel
        {
            Title = title,
            SectionId = sectionId,
            LinkUrl = linkUrl,
            Videos = videos
        };

        return View(model);
    }
}

