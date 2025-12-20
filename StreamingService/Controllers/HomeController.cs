using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Models;

namespace StreamingService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // лендінг 
        public IActionResult Index()
        {
            return View();
        }
        //авторизація
        public IActionResult Auth()
        {
            return View();
        }
        
        //головна сторінка після авторизації
        public IActionResult Movies()
        {
            return View();
        }
        public IActionResult Tests()
        {
            return View();
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
