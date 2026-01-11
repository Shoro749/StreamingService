using Microsoft.AspNetCore.Mvc;
using StreamingService.Service;

namespace StreamingService.Controllers.Stream
{
    [ApiController]
    [Route("stream/{episodeId}/video")]
    public class VideoStreamController : ControllerBase
    {
        private readonly IStreamStorage _storage;

        public VideoStreamController(IStreamStorage storage)
        {
            _storage = storage;
        }

        [HttpGet("{videoFileId}/playlist")]
        public async Task<IActionResult> GetPlaylist(
            int episodeId,
            int videoFileId,
            CancellationToken token)
        {
            var manifest = await _storage.GetVideoManifestAsync(episodeId, videoFileId, token);
            if (manifest is null)
                return NotFound();

            Response.Headers.CacheControl = "no-cache";

            return new FileStreamResult(manifest.Stream, manifest.ContentType);
        }

        [HttpGet("{videoFileId}/{file}")]
        public async Task<IActionResult> GetSegment(
            int episodeId,
            int videoFileId,
            string file,
            CancellationToken token)
        {
            if (!file.EndsWith(".ts") && !file.EndsWith(".m4s"))
                return BadRequest();

            var segment = await _storage.GetVideoSegmentAsync(episodeId, videoFileId, file, token);
            if (segment is null)
                return NotFound();

            Response.Headers.CacheControl =
                "public, max-age=31536000, immutable";

            return new FileStreamResult(segment.Stream, segment.ContentType)
            {
                EnableRangeProcessing = true
            };
        }
    }
}
