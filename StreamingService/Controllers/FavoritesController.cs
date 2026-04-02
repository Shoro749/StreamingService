using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamingService.DTO;
using StreamingService.DTO.Enums;
using StreamingService.Repositories;
using StreamingService.Services;
using System.Security.Claims;

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

        [HttpPost]
        public async Task<IActionResult> Toggle([FromBody] ToggleFavoriteRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var exists = await _service.ExistsAsync(userId, request.VideoId, request.ListType);

            bool success;
            if (exists)
            {
                success = await _service.RemoveFromFavoritesAsync(userId, request.VideoId, request.ListType);
            }
            else
            {
                success = await _service.AddToFavoritesAsync(userId, request.VideoId, request.ListType);
            }

            return Json(new { success, isAdded = !exists });
        }

        public class ToggleFavoriteRequest
        {
            public int VideoId { get; set; }
            public UserVideoListType ListType { get; set; }
        }
    }
}
