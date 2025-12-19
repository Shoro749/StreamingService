using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamingService.DTO;
using StreamingService.Repositories;
using StreamingService.Services;

namespace StreamingService.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly FavoritesService _service;

        public FavoritesController(FavoritesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string locale = "uk")
        {
            var userProfileIdClaim = User.FindFirst("UserProfileId")?.Value;

            if (userProfileIdClaim == null || !int.TryParse(userProfileIdClaim, out int userProfileId))
            {
                return RedirectToAction("Create", "Profile");
            }

            var favorites = await _service.GetUserFavoritesAsync(userProfileId, locale);

            return View(favorites);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int userProfileId, int videoId)
        {
            await _service.AddToFavoritesAsync(userProfileId, videoId);
            return Ok(new { message = "Video added to favorites" });
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFromFavoritesAsync(int userProfileId, int videoId)
        {
            await _service.RemoveFromFavoritesAsync(userProfileId, videoId);
            return Ok(new { message = "Video removed from favorites" });
        }
    }
}
