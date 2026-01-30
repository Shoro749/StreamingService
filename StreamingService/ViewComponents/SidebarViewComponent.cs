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
                    PageUrl = "/Home/Dashboard",
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
                    PageUrl = "/settings",
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

            return View(items);
        }

    }
}
