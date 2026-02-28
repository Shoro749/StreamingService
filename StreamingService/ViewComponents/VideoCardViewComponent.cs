using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;

namespace StreamingService.ViewComponents
{
    public class VideoCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(VideoCardViewModel model)
        {
            return View(model);
        }
    }
}