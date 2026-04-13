using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Requests;
using StreamingService.Services;

namespace StreamingService.Controllers
{
    public class VideoController : Controller
    {
        private readonly VideoService _videoService;

        public VideoController(VideoService videoService)
        {
            _videoService = videoService;
        }

        //[HttpGet]
        //public async Task<IActionResult> Play(int id, int? episodeId = null)
        //{
        //    int userProfileId = GetCurrentUserProfileId();

        //    var vm = await _videoService.GetPlaybackAsync(userProfileId, id, episodeId);

        //    if (vm == null)
        //    {
        //        TempData["ErrorMessage"] = "Для перегляду цього відео потрібна підписка вищого рівня.";
        //        return RedirectToAction("Details", "Movies", new { id = id });
        //    }

        //    return View(vm);
        //}

        // [HttpGet]
        // public IActionResult AccessDenied(int videoId)
        // {
        //     ViewBag.VideoId = videoId;
        //     return View();
        // }

        private int GetCurrentUserProfileId()
        {
            var claim = User.FindFirst("profile_id")?.Value;
            return int.TryParse(claim, out var id) ? id : 0;
        }
    }
}
