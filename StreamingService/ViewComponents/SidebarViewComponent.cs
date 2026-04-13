using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;
using StreamingService.Services;

namespace StreamingService.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly HistoryService _historyService;

        public SidebarViewComponent(HistoryService historyService)
        {
            _historyService = historyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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

            // Дані для "продовжити перегляд" з Бази Даних
            ContinueWatchingViewModel? videoData = null;

            if (int.TryParse(UserClaimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                var latestHistory = await _historyService.GetContinueWatchingAsync(userId);
                
                if (latestHistory != null && latestHistory.VideoEpisode?.VideoSeason?.Video != null)
                {
                    var ev = latestHistory.VideoEpisode;
                    var video = ev.VideoSeason.Video;
                    
                    var title = video.Translations.FirstOrDefault(t => t.LocaleCode == "uk")?.Title 
                                ?? video.Translations.FirstOrDefault()?.Title ?? "Без назви";

                    // Шукаємо постер чи бекдроп
                    var backdrop = video.Images.Where(i => i.Type == "backdrop")
                        .Select(i => /*"/" + i.BlobContainer + "/" +*/ i.BlobPath)
                        .FirstOrDefault() ?? "/images/placeholder-banner.jpg";

                    // Розраховуємо % прогресу
                    int progressPercent = ev.Duration > 0 
                        ? (int)Math.Round((double)latestHistory.PausedWatchTime / ev.Duration * 100) 
                        : 0;

                    // Форматуємо тривалість
                    var timeSpan = TimeSpan.FromSeconds(ev.Duration);
                    string durationStr = timeSpan.Hours > 0 
                        ? $"{timeSpan.Hours}г {timeSpan.Minutes}хв" 
                        : $"{timeSpan.Minutes}хв";

                    videoData = new ContinueWatchingViewModel
                    {
                        Id = video.Id.ToString(),
                        EpisodeId = ev.Id.ToString(),
                        Title = title,
                        Duration = durationStr,
                        ViewProgress = progressPercent + "%",
                        PosterUrl = backdrop
                    };
                }
            }

            var viewModel = new SidebarViewModel
            {
                MenuItems = items,
                ContinueWatching = videoData
            }; 
            
            return View(viewModel);
        }
    }
}
