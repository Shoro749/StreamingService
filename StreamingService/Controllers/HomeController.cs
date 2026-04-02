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
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;
using System.Xml.Linq;

namespace StreamingService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MoviesService _moviesService;
        private readonly PricingService _pricingService;
        private readonly FavoritesService _favoritesService;

        public HomeController(ILogger<HomeController> logger, PricingService pricingService, MoviesService moviesService, FavoritesService favoritesService)
        {
            _logger = logger;
            _pricingService = pricingService;
            _moviesService = moviesService;
            _favoritesService = favoritesService;
        }

        [Authorize]
        public async Task<IActionResult> Movies()
        {
            var locale = CultureInfo.CurrentCulture.Name;
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var model = new MoviesPageViewModel
            {
                Genres = await _moviesService.GetAllGenresAsync(locale),
                SliderVideos = await _moviesService.GetSliderAsync(locale, userId),
                PopularVideos = await _moviesService.GetPopularAsync(locale, userId),
                TrendingVideos = await _moviesService.GetTrendingAsync(locale, userId),
                NewReleases = await _moviesService.GetNewReleasesAsync(locale, userId),
                WeeklyHits = await _moviesService.GetWeeklyHitsAsync(locale, userId)
            };

            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            var plans = _pricingService.GetPricingPlans();
            var studios = StudioItem.GetStudios();
            var features = FeatureItem.GetFeatures();
            var questions = FaqItem.GetQuestions();
            var topMovies = TopMovieSeeder.Seed();

            var model = new LandingPageViewModel
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

        //public IActionResult Movies()
        //{
        //    return View();
        //}

        [Authorize]
        //[RequireActiveSubscription]
        public async Task<IActionResult> Catalog(VideoType? category)
        {
            var locale = CultureInfo.CurrentCulture.Name.Split('-')[0];
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

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
                return View(new CatalogPageViewModel());
            }

            var model = new CatalogPageViewModel
            {
                Genres = await _moviesService.GetAllGenresAsync(locale),
                PopularVideos = await _moviesService.GetPopularAsync(locale, userId),
                NewReleases = await _moviesService.GetNewReleasesAsync(locale, userId),
                TrendingVideos = await _moviesService.GetTrendingAsync(locale, userId)
            };

            return View(model);
        }

        [Authorize]
        [Route("/favorites")]
        public async Task<IActionResult> Favorites(VideoType? category)
        {
            var locale = CultureInfo.CurrentCulture.Name;
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

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

            var favoriteVideos = await _favoritesService.GetUserFavoritesAsync(userId, UserVideoListType.Favorite, locale);
            favoriteVideos = FilterByCategory(favoriteVideos, category);

            var postponedVideos = await _favoritesService.GetUserFavoritesAsync(userId, UserVideoListType.WatchLater, locale);
            postponedVideos = FilterByCategory(postponedVideos, category);

            ViewBag.Genres = await _moviesService.GetAllGenresAsync(locale);
            ViewBag.PostponedVideos = postponedVideos;

            return View(favoriteVideos);
        }

        [Authorize]
        [Route("/upcoming")]
        public async Task<IActionResult> Upcoming(VideoType? category)
        {
            var locale = CultureInfo.CurrentCulture.Name;
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

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

            var groupedReleases = await _moviesService.GetUpcomingReleasesAsync(locale, userId);

            return View(groupedReleases);
        }

        [Authorize]
        [Route("/trending")]
        public async Task<IActionResult> Trending(VideoType? category)
        {
            var locale = CultureInfo.CurrentCulture.Name;
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

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

            var trendingVideos = await _moviesService.GetTrendingAsync(locale, userId);

            return View(trendingVideos);
        }

        [HttpPost]
        public async Task<IActionResult> FilterByGenres([FromBody] FilterByGenresRequest request)
        {
            var locale = CultureInfo.CurrentCulture.Name;
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var videos = await _moviesService.GetVideosByGenresAsync(request.GenreCodes, locale, userId);

            return Json(new { success = true, videos });
        }

        public class FilterByGenresRequest
        {
            public List<string> GenreCodes { get; set; } = new();
        }

        [HttpPost]
        public async Task<IActionResult> RenderVideoCard([FromBody] VideoCardViewModel video)
        {
            return ViewComponent("VideoCard", video);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> FilterFavoritesByGenres([FromBody] FilterByGenresRequest request)
        {
            var locale = CultureInfo.CurrentCulture.Name;
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var allFavorites = await _favoritesService.GetUserFavoritesAsync(userId, UserVideoListType.Favorite, locale);

            var filteredVideos = allFavorites
                .Where(v => v.Genres != null && v.Genres.Any(genre =>
                    request.GenreCodes.Any(code =>
                        genre.ToLower().Contains(code.ToLower())
                    )
                ))
                .ToList();

            return Json(new { success = true, videos = filteredVideos });
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search(string? query, int? genreId, string? sortBy, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(query) && !genreId.HasValue)
            {
                return View(new SearchResultsViewModel
                {
                    Query = query,
                    Videos = new List<VideoCardViewModel>(),
                    TotalResults = 0
                });
            }

            var locale = CultureInfo.CurrentCulture.Name;
            var userId = User?.Identity?.IsAuthenticated ?? false
                ? int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0")
                : (int?)null;

            var results = await _moviesService.SearchVideosAsync(query, genreId, sortBy, page, 20, locale, userId);

            ViewBag.Genres = await _moviesService.GetAllGenresAsync(locale);

            return View(results);
        }

        [HttpGet]
        [Route("api/search/suggestions")]
        public async Task<IActionResult> GetSearchSuggestions(string query)
        {
            if (string.IsNullOrWhiteSpace(query) || query.Length < 2)
            {
                return Json(new List<string>());
            }

            var locale = CultureInfo.CurrentCulture.Name.Split('-')[0];
            var suggestions = await _moviesService.GetSearchSuggestionsAsync(query, locale, 10);

            return Json(suggestions);
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

        private void SetPageHeaders(VideoType? category, string pageTitle)
        {
            if (category == null)
            {
                ViewData["Title"] = pageTitle;
                ViewData["MenuTitle"] = "Усі";
            }
            else
            {
                ViewData["Title"] = $"{category.Value.GetDisplayName()} - { pageTitle}";
                ViewData["MenuTitle"] = category.Value.GetShortName();
                ViewData["Category"] = category;
            }
        }

        private List<VideoCardViewModel> FilterByCategory(List<VideoCardViewModel> videos, VideoType? category)
        {
            
            if (category != null)
            {
                videos = videos
                    .Where(video => video.VideoType == category)
                    .ToList();
            }

            return videos;
        }
    }
}
