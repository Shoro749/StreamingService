using Microsoft.AspNetCore.Mvc;
using StreamingService.Services;

namespace StreamingService.Controllers
{
    public class VideoStatsController : Controller
    {
        private readonly VideoStatsService _statsService;

        public VideoStatsController(VideoStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpPost]
        public async Task<IActionResult> SyncProgress(int profileId, int episodeId, int currentTime, int totalDuration)
        {
            var success = await _statsService.UpdateWatchProgressAsync(profileId, episodeId, currentTime, totalDuration);
            if (success) return Ok();
            return BadRequest("Не вдалося зберегти прогрес перегляду");
        }

        [HttpGet]
        public async Task<IActionResult> GetContinueWatching(int profileId)
        {
            return Ok()
        }
    }
}
