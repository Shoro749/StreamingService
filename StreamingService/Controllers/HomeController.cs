using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;
using StreamingService.Extensions;
using StreamingService.Models;
using StreamingService.Resources;
using StreamingService.Services;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;

namespace StreamingService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MoviesService _moviesService;
        private readonly PricingService _pricingService;
        private readonly FavoritesService _favoritesService;
        SubscriptionService _subscriptionService;

        public HomeController(ILogger<HomeController> logger, PricingService pricingService, MoviesService moviesService, FavoritesService favoritesService, SubscriptionService subscriptionService)
        {
            _logger = logger;
            _pricingService = pricingService;
            _moviesService = moviesService;
            _favoritesService = favoritesService;
            _subscriptionService = subscriptionService;
        }

        [Authorize]
        public async Task<IActionResult> Movies()
        {
            //var locale = CultureInfo.CurrentCulture.Name;
            var locale = "uk";
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
            var plans = await _subscriptionService.GetAllPlansAsync();
            var studios = StudioItem.GetStudios();
            var features = FeatureItem.GetFeatures();
            var questions = FaqItem.GetQuestions();
            var topMovies = TopMovieSeeder.Seed();

            var model = new LandingPageViewModel
            {
                PricingTiers = plans.Select(p => new PricingTier
                {
                    Id = p.Id,

                    Title = p.SubscriptionLevel?.Code ?? "Невідомо",

                    Price = p.Price.ToString(),

                    ButtonText = (p.Id == 1) ? "Спробувати базовий" : (p.Id == 2) ? "Увімкнути магію кіно" : "Дивись без меж",

                    Features = string.IsNullOrEmpty(p.Features)
                        ? new List<string>()
                        : p.Features
                            .Split(new[] { ',', ';', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(f => f.Trim())
                            .ToList()
                }).ToList(),
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
            //var locale = CultureInfo.CurrentCulture.Name.Split('-')[0];
            var locale = "uk";
            var userId = User?.Identity?.IsAuthenticated ?? false
                ? int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0")
                : (int?)null;

            SetPageHeaders(category, "Каталог");

            if (_moviesService == null)
            {
                _logger.LogError("MoviesService is null!");
                return View(new CatalogPageViewModel());
            }

            var model = new CatalogPageViewModel
            {
                Genres = await _moviesService.GetAllGenresAsync(locale),
                PopularVideos = await _moviesService.GetPopularAsync(locale, userId, category),
                NewReleases = await _moviesService.GetNewReleasesAsync(locale, userId, category),
                TrendingVideos = await _moviesService.GetTrendingAsync(locale, userId, category)
            };

            return View(model);
        }

        [Authorize]
        [Route("/favorites")]
        public async Task<IActionResult> Favorites(VideoType? category)
        {
            //var locale = CultureInfo.CurrentCulture.Name;
            var locale = "uk";
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            SetPageHeaders(category, "Улюблене");

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
            //var locale = CultureInfo.CurrentCulture.Name;
            var locale = "uk";
            var userId = User?.Identity?.IsAuthenticated ?? false
                ? int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0")
                : (int?)null;

            SetPageHeaders(category, "Незабаром");

            //var groupedReleases = await _moviesService.GetUpcomingReleasesAsync(locale);
            ////для фільтрації по категорії
            //// --- початок ----
            //if (category != null && groupedReleases != null)
            //{
            //    var filteredGroupedReleases = new Dictionary<string, List<VideoCardViewModel>>();
            //    foreach (var group in groupedReleases)
            //    {
            //        var filteredVideos = FilterByCategory(group.Value, category);
            //        if (filteredVideos.Any())
            //        {
            //            filteredGroupedReleases.Add(group.Key, filteredVideos);
            //        }
            //    }
            //    groupedReleases = filteredGroupedReleases;
            //}

            var groupedReleases = await _moviesService.GetUpcomingReleasesAsync(locale, userId, category);

            return View(groupedReleases);
        }

        [Authorize]
        [Route("/trending")]
        public async Task<IActionResult> Trending(VideoType? category)
        {
            //var locale = CultureInfo.CurrentCulture.Name;
            var locale = "uk";
            var userId = User?.Identity?.IsAuthenticated ?? false
                ? int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0")
                : (int?)null;

            SetPageHeaders(category, "У тренді");

            var trendingVideos = await _moviesService.GetTrendingAsync(locale, userId, category);

            return View(trendingVideos);
        }

        [HttpPost]
        public async Task<IActionResult> FilterByGenres([FromBody] FilterByGenresRequest request)
        {
            //var locale = CultureInfo.CurrentCulture.Name;
            var locale = "uk";
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
            //var locale = CultureInfo.CurrentCulture.Name;
            var locale = "uk";
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var allFavorites = await _favoritesService.GetUserFavoritesAsync(userId, UserVideoListType.Favorite, locale);

            if (request.GenreCodes == null || !request.GenreCodes.Any())
            {
                return Json(new { success = true, videos = allFavorites });
            }

            var videosByGenres = await _moviesService.GetVideosByGenresAsync(request.GenreCodes, locale, userId);

            var favoriteIds = allFavorites.Select(v => v.Id).ToHashSet();
            var filteredVideos = videosByGenres
                .Where(v => favoriteIds.Contains(v.Id))
                .ToList();

            return Json(new { success = true, videos = filteredVideos });
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search(string? query, int? genreId, string? sortBy, VideoType? type = null, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(query) && !genreId.HasValue && !type.HasValue)
            {
                var emptyModel = new CatalogPageViewModel
                {
                    Genres = await _moviesService.GetAllGenresAsync(CultureInfo.CurrentCulture.Name)
                };

                ViewData["IsSearch"] = true;
                ViewData["SearchQuery"] = query ?? "";
                ViewData["Title"] = "Пошук";
                ViewData["MenuTitle"] = "Результати";

                return View("Catalog", emptyModel);
            }

            //var locale = CultureInfo.CurrentCulture.Name;
            var locale = "uk";
            var userId = User?.Identity?.IsAuthenticated ?? false
                ? int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0")
                : (int?)null;

            var results = await _moviesService.SearchVideosAsync(query, genreId, sortBy, page, 20, locale, userId, type);

            ViewBag.Genres = await _moviesService.GetAllGenresAsync(locale);

            var catalogModel = new CatalogPageViewModel
            {
                Genres = await _moviesService.GetAllGenresAsync(locale),
                PopularVideos = results.Videos ?? new List<VideoCardViewModel>(),
                NewReleases = new List<VideoCardViewModel>(),
                TrendingVideos = new List<VideoCardViewModel>()
            };

            ViewData["IsSearch"] = true;
            ViewData["SearchQuery"] = query ?? "";
            ViewData["SelectedGenreId"] = genreId;
            ViewData["SortBy"] = sortBy;
            ViewData["Title"] = "Результати пошуку";
            ViewData["MenuTitle"] = "Усі";

            return View("Catalog", catalogModel);
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
