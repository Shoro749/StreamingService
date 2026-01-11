using Microsoft.AspNetCore.Mvc;
using StreamingService.Service;

namespace StreamingService.Controllers.Stream
{
    [ApiController]
    [Route("stream/{episodeId}/subtitle")]
    public class SubtitleStreamController : ControllerBase
    {
        private readonly IStreamStorage _storage;

        public SubtitleStreamController(IStreamStorage storage)
        {
            _storage = storage;
        }

        [HttpGet("{subtitleId}")]
        public async Task<IActionResult> GetSubtitle(int episodeId, int subtitleId, CancellationToken token)
        {
            var file = await _storage.GetSubtitleAsync(episodeId, subtitleId, token);
            if (file is null)
                return NotFound();

            Response.Headers.CacheControl = "public, max-age=86400";

            return new FileStreamResult(file.Stream, file.ContentType);
        }
    }

}
