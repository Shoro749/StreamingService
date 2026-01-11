using Microsoft.AspNetCore.Mvc;
using StreamingService.Service;

namespace StreamingService.Controllers.Stream
{
    [ApiController]
    [Route("stream/{episodeId}/audio")]
    public class AudioStreamController : ControllerBase
    {
        private readonly IStreamStorage _storage;

        public AudioStreamController(IStreamStorage storage)
        {
            _storage = storage;
        }

        [HttpGet("{audioFileId}/playlist")]
        public async Task<IActionResult> GetPlaylist(
            int episodeId,
            int audioFileId,
            CancellationToken token)
        {
            var manifest = await _storage.GetAudioManifestAsync(episodeId, audioFileId, token);
            if (manifest is null)
                return NotFound();

            Response.Headers.CacheControl = "no-cache";

            return new FileStreamResult(manifest.Stream, manifest.ContentType);
        }

        [HttpGet("{audioFileId}/{file}")]
        public async Task<IActionResult> GetSegment(
            int episodeId,
            int audioFileId,
            string file, CancellationToken token)
        {
            if (!file.EndsWith(".aac") && !file.EndsWith(".m4a"))
                return BadRequest();

            var segment = await _storage.GetAudioSegmentAsync(episodeId, audioFileId, file, token);
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
