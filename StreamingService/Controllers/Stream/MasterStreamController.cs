using Microsoft.AspNetCore.Mvc;
using StreamingService.Service;
using System.Text;

namespace StreamingService.Controllers.Stream
{
    [ApiController]
    [Route("stream/{episodeId}")]
    public class MasterStreamController : Controller
    {
        private MasterManifestService _manifestService;

        public MasterStreamController(MasterManifestService manifestService)
        {
            _manifestService = manifestService;
        }

        [HttpGet("master")]
        public async Task<IActionResult> GetMaster(
            int episodeId,
            CancellationToken token)
        {
            var master = await _manifestService.BuildMasterAsync(episodeId, token);
            if (master is null)
                return NotFound();

            Response.Headers.CacheControl = "no-cache";

            return Content(master, "application/vnd.apple.mpegurl", Encoding.UTF8);
        }
    }
}