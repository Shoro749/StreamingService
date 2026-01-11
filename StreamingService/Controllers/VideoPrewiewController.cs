using Microsoft.AspNetCore.Mvc;
using StreamingService.Services;

namespace StreamingService.Controllers
{
    public class VideoPrewiewController : Controller
    {
        private VideoPreviewService _videoPreviewService;
        public VideoPrewiewController(VideoPreviewService videoPreviewService)
        {
            _videoPreviewService = videoPreviewService;
        }

        [HttpGet("preview/{episodeId}")]
        public async Task<IActionResult> Index(int episodeId, [FromQuery] string locale = "uk")
        {
            var preview = await _videoPreviewService.GetVideoPreviewByIdAsync(locale, episodeId);
            return View(preview);
        }
    }
}
