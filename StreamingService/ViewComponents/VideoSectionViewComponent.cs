using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;

namespace StreamingService.ViewComponents
{
    public class VideoSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string title, string sectionId, string linkUrl)
        {
            var videos = new List<VideoCardViewModel>();

            for (int i = 1; i <= 8; i++) 
            {
                videos.Add(new VideoCardViewModel
                {
                    Id = i,
                    Title = $"Назва відео {i}",
                    ImageUrl = "https://image.tmdb.org/t/p/w500/1E5baAaEse26fej7uHcjOgEE2t2.jpg",
                    Rating = 7.8,
                    Year = "2022",
                    Duration = "1г 45хв"
                });
            }

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
}
