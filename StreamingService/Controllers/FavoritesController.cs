using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamingService.DTO;
using StreamingService.Repositories;
using StreamingService.Services;
using System.Security.Claims;

namespace StreamingService.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly IFavoritesService _service;

        public FavoritesController(IFavoritesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string locale = "uk")
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var favorites = await _service.GetUserFavoritesAsync(userId, locale);
            return View(favorites);
        }

        [HttpPost]
        public async Task<IActionResult> Toggle([FromBody] ToggleFavoriteRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var favorites = await _service.GetUserFavoritesAsync(userId, "uk");
            var isFavorite = favorites.Any(f => f.Id == request.VideoId);

            bool success;
            if (isFavorite)
            {
                success = await _service.RemoveFromFavoritesAsync(userId, request.VideoId);
            }
            else
            {
                success = await _service.AddToFavoritesAsync(userId, request.VideoId);
            }

            return Json(new { success, isFavorite = !isFavorite });
        }

        [HttpPost]
        public async Task<IActionResult> Add(int videoId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var success = await _service.AddToFavoritesAsync(userId, videoId);
            return Json(new { success });
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int videoId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var success = await _service.RemoveFromFavoritesAsync(userId, videoId);
            return Json(new { success });
        }
    }

    public class ToggleFavoriteRequest
    {
        public int VideoId { get; set; }
    }
}
