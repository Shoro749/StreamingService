using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;
using StreamingService.Extensions;
using StreamingService.Models;
using StreamingService.Services;
using System.Collections.Generic;
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
        
        public IActionResult Movies()
        {
            return View();
        }

        public IActionResult Catalog(VideoType? category)
        {
            SetPageHeaders(category, "Каталог");
            
            var catalogVideos = MockVideoService.GetAllVideos();

            catalogVideos = FilterByCategory(catalogVideos, category);
            
            ViewBag.CurrentCategory = category;

            return View(catalogVideos);
        }

        [Route("/favorites")]
        public IActionResult Favorites(VideoType? category)
        {
            SetPageHeaders(category, "Улюблене");
            
            var favoriteVideos = MockVideoService.GetAllVideos()
                .Where(video => video.IsFavorite)
                .ToList();

            var postponedVideos = MockUpcomingService.GetUpcomingReleases()
                .Where(video => video.IsSavedForLater)
                .ToList();

            favoriteVideos = FilterByCategory(favoriteVideos, category);
            postponedVideos = FilterByCategory(postponedVideos, category);

            ViewBag.PostponedVideos = postponedVideos;

            return View(favoriteVideos);
        }

        [Route("/upcoming")]
        public IActionResult Upcoming(VideoType? category)
        {
            SetPageHeaders(category, "Незабаром"); 

            var upcomingVideos = MockUpcomingService.GetUpcomingReleases();
            upcomingVideos = FilterByCategory(upcomingVideos, category);

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
            SetPageHeaders(category, "У тренді");

            var trendingVideos = MockVideoService.GetAllVideos().Take(10).ToList();

            trendingVideos = FilterByCategory(trendingVideos, category);

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
