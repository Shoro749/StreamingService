using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Requests;
using StreamingService.Services;

namespace StreamingService.Controllers
{
    public class HistoryController : Controller
    {
        //private readonly HistoryService _historyService;

        //public HistoryController(HistoryService continueService)
        //{
        //    _historyService = continueService;
        //}

        //[HttpGet("continue")]
        //public async Task<IActionResult> GetContinueWatching(int userId)
        //{
        //    var result = await _historyService.GetContinueWatchingAsync(userId);
        //    return Ok(result);
        //}

        //[HttpPost("save")]
        //public async Task<IActionResult> SaveHistory(SaveProgressDto dto)
        //{
        //    await _historyService.SaveWatchingProgressAsync(dto.UserId, dto.EpisodeId, dto.PausedTime);
        //    return Ok();
        //}
    }

}
