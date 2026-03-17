using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Video/Stream/hls/{token}")]
        [AllowAnonymous]
        public async Task<IActionResult> StreamHLS(string token, string? file = null)
        {
            var streamData = _videoService.ValidateStreamToken(token);
            if (streamData == null) return Unauthorized();

            if (string.IsNullOrEmpty(file))
            {
                var playlistPath = await _videoService.GetVideoFilePathAsync(streamData.EpisodeId, "hls");
                if (!System.IO.File.Exists(playlistPath)) return NotFound();

                return File(System.IO.File.OpenRead(playlistPath), "application/vnd.apple.mpegurl");
            }

            var segmentPath = Path.Combine(
                Path.GetDirectoryName(await _videoService.GetVideoFilePathAsync(streamData.EpisodeId, "hls")) ?? "",
                file
            );

            if (!System.IO.File.Exists(segmentPath)) return NotFound();

            return File(System.IO.File.OpenRead(segmentPath), "video/mp2t");
        }
    }
}
