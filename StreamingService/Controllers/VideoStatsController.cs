using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Requests;
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

        [HttpGet("daily/{episodeId}")]
        public async Task<IActionResult> GetDailyViews(int episodeId)
        {
            var views = await _statsService.GetDailyViewsAsync(episodeId);
            return Ok(new { episodeId, views });
        }

        [HttpPost("log")]
        public async Task<IActionResult> LogView([FromBody] LogViewDto dto)
        {
            await _statsService.AddTimedLogAsync(dto.UserId, dto.EpisodeId);
            return Ok(new { message = "View logged" });
        }

        [HttpGet("top")]
        public async Task<IActionResult> GetTopEpisodes([FromQuery] int limit = 20)
        {
            var list = await _statsService.GetTopEpisodesAsync(limit);
            return Ok(list);
        }
    }
}
