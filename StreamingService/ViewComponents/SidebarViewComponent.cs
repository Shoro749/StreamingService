using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;

namespace StreamingService.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            var currentPath = HttpContext.Request.Path.ToString().ToLower();

            var items = new List<SidebarItemViewModel>
            {
                new SidebarItemViewModel
                {
                    PageName = "Головна",
                    PageUrl = "/Home/Catalog",
                    InactiveIcon = "/images/ui/sidebar/home_off.png",
                    ActiveIcon = "/images/ui/sidebar/home.png",
                    IsActive = currentPath == "/" || currentPath.StartsWith("/home")
                },

                new SidebarItemViewModel
                {
                    PageName = "Улюблене",
                    PageUrl = "/favorites",
                    InactiveIcon = "/images/ui/sidebar/favorites_off.png",
                    ActiveIcon = "/images/ui/sidebar/favorites.png",
                    IsActive = currentPath.StartsWith("/favorites")
                },

                new SidebarItemViewModel
                {
                    PageName = "Незабаром",
                    PageUrl = "/upcoming",
                    InactiveIcon = "/images/ui/sidebar/upcoming_releases_off.png",
                    ActiveIcon = "/images/ui/sidebar/upcoming_releases.png",
                    IsActive = currentPath.StartsWith("/upcoming")
                },

                new SidebarItemViewModel
                {
                    PageName = "У тренді",
                    PageUrl = "/trending",
                    InactiveIcon = "/images/ui/sidebar/trends_off.png",
                    ActiveIcon = "/images/ui/sidebar/trends.png",
                    IsActive = currentPath.StartsWith("/trending"),
                    HasSeparator = true
                },

                new SidebarItemViewModel
                {
                    PageName = "Налаштування",
                    PageUrl = $"/settings/profile?returnUrl={HttpContext.Request.Path}",
                    InactiveIcon = "/images/ui/sidebar/settings_off.png",
                    ActiveIcon = "/images/ui/sidebar/settings.png",
                    IsActive = currentPath.StartsWith("/settings")
                },

                new SidebarItemViewModel
                {
                    PageName = "Підтримка",
                    PageUrl = "/support",
                    InactiveIcon = "/images/ui/sidebar/support_off.png",
                    ActiveIcon = "/images/ui/sidebar/support.png",
                    IsActive = currentPath.StartsWith("/support"),
                    HasSeparator = true
                }

            };
            // Дані для "продовжити перегляд"
            var videoData = new ContinueWatchingViewModel
            {
                Id = "1",
                Title = "Легенда Г'ю Гласса",
                Duration = "1г 24хв",
                ViewProgress = "55%",
                PosterUrl = "/images/landing/Landing_revenant.png"
            };
            // Збирання даних в модель
            var viewModel = new SidebarViewModel
            {
                MenuItems = items,
                ContinueWatching = videoData
            }; 
            
            return View(viewModel);
        }

    }
}
