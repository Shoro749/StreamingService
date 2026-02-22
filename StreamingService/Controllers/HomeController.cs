using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;
using StreamingService.Extensions;
using StreamingService.Models;
using StreamingService.Services;
using System.Diagnostics;
using System.Xml.Linq;

namespace StreamingService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PricingService _pricingService;
        

        public HomeController(ILogger<HomeController> logger, PricingService pricingService)
        {
            _logger = logger;
            _pricingService = pricingService;
        }
        
        public IActionResult Index()
        {
            var plans = _pricingService.GetPricingPlans();
            var studios = StudioItem.GetStudios();
            var features = FeatureItem.GetFeatures();
            var questions = FaqItem.GetQuestions();
            var topMovies = TopMovieSeeder.Seed();
            var model = new HomePageViewModel
            {
                PricingTiers = plans,
                Studios = studios,
                Features = features,
                Questions = questions,
                TopMovies = topMovies,
            };
            return View(model);
        }
        
        public IActionResult Auth()
        {
            return View();
        }
        
        public IActionResult Movies()
        {
            return View();
        }

        public IActionResult Catalog(VideoType? category)
        {
            if (category == null)
            {
                ViewData["Title"] = "Каталог";
                ViewData["MenuTitle"] = "Усі";
            }
            else
            {
                ViewData["Title"] = $"{category.Value.GetDisplayName()} - Каталог";
                ViewData["MenuTitle"] = category.Value.GetShortName();
                ViewData["Category"] = category;
            }
            return View();
        }

        [Route("/favorites")]
        public IActionResult Favorites(VideoType? category)
        {
            if (category == null)
            {
                ViewData["Title"] = "Улюблене";
                ViewData["MenuTitle"] = "Усі";
            }
            else
            {
                ViewData["Title"] = $"{category.Value.GetDisplayName()} - Улюблене";
                ViewData["MenuTitle"] = category.Value.GetShortName();
                ViewData["Category"] = category;
            }

            var favoriteVideos = MockVideoService.GetAllVideos()
                .Where(video => video.IsFavorite)
                .ToList();

            var postponedVideos = MockUpcomingService.GetUpcomingReleases()
                .Where(video => video.IsSavedForLater)
                .ToList();

            if (category != null)
            {
                favoriteVideos = favoriteVideos
                    .Where(video => video.VideoType == category)
                    .ToList();

                postponedVideos = postponedVideos
                    .Where (video => video.VideoType == category)
                    .ToList();
            }
            ViewBag.PostponedVideos = postponedVideos;

            return View(favoriteVideos);
        }

        [Route("/upcoming")]
        public IActionResult Upcoming(VideoType? category)
        {
            if (category == null)
            {
                ViewData["Title"] = "Незабаром";
                ViewData["MenuTitle"] = "Усі";
            }
            else
            {
                ViewData["Title"] = $"{category.Value.GetDisplayName()} - Незабаром";
                ViewData["MenuTitle"] = category.Value.GetShortName();
                ViewData["Category"] = category;
            }

            var upcomingVideos = MockUpcomingService.GetUpcomingReleases();

            if (category != null)
            {
                upcomingVideos = upcomingVideos
                    .Where(video => video.VideoType == category)
                    .ToList();
            }

            var culture = new System.Globalization.CultureInfo("uk-UA");

            var groupedReleases = upcomingVideos
                .Where(v => v.ReleaseDate.HasValue)
                .OrderBy(v => v.ReleaseDate.Value.Date)
                .GroupBy(v => v.ReleaseDate.Value.Date)
                .ToDictionary(
                g => g.Key.ToString("dd MMM, yyyy", culture)
                .Replace(".", "")
                .ToLower(),
                g => g.ToList()
                );

            return View(groupedReleases);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
