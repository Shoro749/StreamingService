//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using StreamingService.DTO.ViewModels;
//using StreamingService.Services;

//namespace StreamingService.Controllers
//{
//    [Authorize(Roles = "Admin")]
//    [Route("Admin")]
//    public class AdminController : Controller
//    {
//        private readonly AdminService _adminService;
//        private readonly ILogger<AdminController> _logger;

//        public AdminController(AdminService adminService, ILogger<AdminController> logger)
//        {
//            _adminService = adminService;
//            _logger = logger;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Index()
//        {
//            var stats = await _adminService.GetDashboardStatsAsync();
//            return View(stats);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Videos(int page = 1, string? search = null, int? genreId = null)
//        {
//            var videos = await _adminService.GetVideosPagedAsync(page, 20, search, genreId);
//            return View(videos);
//        }

//        [HttpGet]
//        public async Task<IActionResult> CreateVideo()
//        {
//            var model = await _adminService.GetVideoCreateModelAsync();
//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> CreateVideo(CreateVideoViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            var result = await _adminService.CreateVideoAsync(model);

//            if (result.Success)
//            {
//                TempData["Success"] = "Відео успішно створено!";
//                return RedirectToAction("EditVideo", new { id = result.VideoId });
//            }

//            TempData["Error"] = result.ErrorMessage;
//            return View(model);
//        }

//        [HttpGet]
//        public async Task<IActionResult> EditVideo(int id)
//        {
//            var model = await _adminService.GetVideoEditModelAsync(id);

//            if (model == null)
//            {
//                return NotFound();
//            }

//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> EditVideo(int id, EditVideoViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            var result = await _adminService.UpdateVideoAsync(id, model);

//            if (result.Success)
//            {
//                TempData["Success"] = "Відео успішно оновлено!";
//                return RedirectToAction("EditVideo", new { id });
//            }

//            TempData["Error"] = result.ErrorMessage;
//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteVideo(int id)
//        {
//            var result = await _adminService.DeleteVideoAsync(id);

//            if (result.Success)
//            {
//                TempData["Success"] = "Відео успішно видалено!";
//            }
//            else
//            {
//                TempData["Error"] = result.ErrorMessage;
//            }

//            return RedirectToAction("Videos");
//        }

//        [HttpPost]
//        public async Task<IActionResult> UploadPoster(int id, IFormFile file)
//        {
//            if (file == null || file.Length == 0)
//            {
//                return Json(new { success = false, message = "Файл не обрано" });
//            }

//            var result = await _adminService.UploadPosterAsync(id, file);
//            return Json(result);
//        }

//        [HttpPost]
//        public async Task<IActionResult> UploadVideo(int episodeId, IFormFile file)
//        {
//            if (file == null || file.Length == 0)
//            {
//                return Json(new { success = false, message = "Файл не обрано" });
//            }

//            var result = await _adminService.UploadVideoFileAsync(episodeId, file);
//            return Json(result);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> AddSeason(int videoId, int seasonNumber)
//        {
//            var result = await _adminService.AddSeasonAsync(videoId, seasonNumber);

//            if (result.Success)
//            {
//                TempData["Success"] = $"Сезон {seasonNumber} додано!";
//            }
//            else
//            {
//                TempData["Error"] = result.ErrorMessage;
//            }

//            return RedirectToAction("EditVideo", new { id = videoId });
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> AddEpisode(int seasonId, AddEpisodeViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                TempData["Error"] = "Невірні дані";
//                return RedirectToAction("EditVideo", new { id = model.VideoId });
//            }

//            var result = await _adminService.AddEpisodeAsync(seasonId, model);

//            if (result.Success)
//            {
//                TempData["Success"] = $"Епізод {model.EpisodeNumber} додано!";
//            }
//            else
//            {
//                TempData["Error"] = result.ErrorMessage;
//            }

//            return RedirectToAction("EditVideo", new { id = model.VideoId });
//        }

//        [HttpGet]
//        public async Task<IActionResult> Genres()
//        {
//            var genres = await _adminService.GetAllGenresAsync();
//            return View(genres);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> CreateGenre(CreateGenreViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                TempData["Error"] = "Невірні дані";
//                return RedirectToAction("Genres");
//            }

//            var result = await _adminService.CreateGenreAsync(model);

//            if (result.Success)
//            {
//                TempData["Success"] = "Жанр створено!";
//            }
//            else
//            {
//                TempData["Error"] = result.ErrorMessage;
//            }

//            return RedirectToAction("Genres");
//        }

//        [HttpGet]
//        public async Task<IActionResult> Persons(int page = 1, string? search = null)
//        {
//            var persons = await _adminService.GetPersonsPagedAsync(page, 20, search);
//            return View(persons);
//        }

//        [HttpGet]
//        public IActionResult CreatePerson()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> CreatePerson(CreatePersonViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            var result = await _adminService.CreatePersonAsync(model);

//            if (result.Success)
//            {
//                TempData["Success"] = "Актора додано!";
//                return RedirectToAction("Persons");
//            }

//            TempData["Error"] = result.ErrorMessage;
//            return View(model);
//        }

//        [HttpPost)]
//        public async Task<IActionResult> UploadPersonPhoto(int personId, IFormFile file)
//        {
//            if (file == null || file.Length == 0)
//            {
//                return Json(new { success = false, message = "Файл не обрано" });
//            }

//            var result = await _adminService.UploadPersonPhotoAsync(personId, file);
//            return Json(result);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Statistics()
//        {
//            var stats = await _adminService.GetStatisticsAsync();
//            return View(stats);
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetTopVideos(int days = 30)
//        {
//            var topVideos = await _adminService.GetTopVideosByViewsAsync(days);
//            return Json(topVideos);
//        }
//    }
//}
