using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;
using StreamingService.Extensions;
using StreamingService.Models;
using StreamingService.Services;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;

namespace StreamingService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MoviesService _moviesService;
        private readonly PricingService _pricingService;

        public HomeController(ILogger<HomeController> logger, PricingService pricingService)
        {
            _logger = logger;
            _pricingService = pricingService;
        }

        [Authorize]
        //[RequireActiveSubscription]
        public async Task<IActionResult> Movies()
        {
            var locale = CultureInfo.CurrentCulture.Name.Split('-')[0];

            var model = new MoviesPageViewModel
            {
                SliderVideos = await _moviesService.GetSliderAsync(locale),
                PopularVideos = await _moviesService.GetPopularAsync(locale),
                TrendingVideos = await _moviesService.GetTrendingAsync(locale),
                NewReleases = await _moviesService.GetNewReleasesAsync(locale),
                WeeklyHits = await _moviesService.GetWeeklyHitsAsync(locale)
            };

            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            var locale = CultureInfo.CurrentCulture.Name.Split('-')[0];

            var model = new MoviesPageViewModel
            {
                SliderVideos = await _moviesService.GetSliderAsync(locale),
                PopularVideos = await _moviesService.GetPopularAsync(locale),
                TrendingVideos = await _moviesService.GetTrendingAsync(locale),
                NewReleases = await _moviesService.GetNewReleasesAsync(locale),
                WeeklyHits = await _moviesService.GetWeeklyHitsAsync(locale)
            };

            return View(model);

            //var plans = _pricingService.GetPricingPlans();
            //var studios = StudioItem.GetStudios();
            //var features = FeatureItem.GetFeatures();
            //var questions = FaqItem.GetQuestions();
            //var topMovies = TopMovieSeeder.Seed();
            //var model = new HomePageViewModel
            //{
            //    PricingTiers = plans,
            //    Studios = studios,
            //    Features = features,
            //    Questions = questions,
            //    TopMovies = topMovies,
            //};
            //return View(model);
        }
        
        public IActionResult Auth()
        {
            return View();
        }

        //public IActionResult Movies()
        //{
        //    return View();
        //}

        [Authorize]
        //[RequireActiveSubscription]
        public async Task<IActionResult> Catalog(VideoType? category)
        {
            var locale = CultureInfo.CurrentCulture.Name.Split('-')[0];

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

            if (_moviesService == null)
            {
                _logger.LogError("MoviesService is null!");
                return View(new CatalogPageViewModel()); // Повертаємо порожню модель
            }

            var model = new CatalogPageViewModel
            {
                PopularVideos = await _moviesService.GetPopularAsync(locale),
                NewReleases = await _moviesService.GetNewReleasesAsync(locale),
                TrendingVideos = await _moviesService.GetTrendingAsync(locale)
            };

            return View(model);
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

        [Route("/trending")]
        public IActionResult Trending(VideoType? category)
        {
            if (category == null)
            {
                ViewData["Title"] = "У тренді";
                ViewData["MenuTitle"] = "Усі";
            }
            else
            {
                ViewData["Title"] = $"{category.Value.GetDisplayName()} - У тренді";
                ViewData["MenuTitle"] = category.Value.GetShortName();
                ViewData["Category"] = category;

            }

            var trendingVideos = MockVideoService.GetAllVideos().Take(10).ToList();
            
            if (category != null)
            {
                trendingVideos = trendingVideos
                    .Where (video => video.VideoType == category)
                    .ToList();
            }

            return View(trendingVideos);
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
