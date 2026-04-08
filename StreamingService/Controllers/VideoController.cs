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

        [HttpGet]
        public async Task<IActionResult> Play(int id, int? episodeId = null)
        {
            int userProfileId = GetCurrentUserProfileId();

            var vm = await _videoService.GetPlaybackAsync(userProfileId, id, episodeId);

            if (vm == null)
                return RedirectToAction("AccessDenied", new { videoId = id });

            return View(vm);
        }

        [HttpGet]
        public IActionResult AccessDenied(int videoId)
        {
            ViewBag.VideoId = videoId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveProgress([FromBody] SaveProgressRequest request)
        {
            if (request.EpisodeId <= 0)
                return BadRequest();

            int userProfileId = GetCurrentUserProfileId();

            bool isFullyWatched = request.Duration > 0 && (double)request.CurrentTime / request.Duration >= 0.9;

            await _videoService.SaveProgressAsync(userProfileId, request.EpisodeId, isFullyWatched);
            return Ok();
        }

        private int GetCurrentUserProfileId()
        {
            var claim = User.FindFirst("profile_id")?.Value;
            return int.TryParse(claim, out var id) ? id : 0;
        }
    }
}
