using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Requests;
using StreamingService.Services;
using System.Security.Claims;

namespace StreamingService.Controllers
{
    [Authorize]
    [Route("api/history")]
    public class HistoryController : Controller
    {
        private readonly HistoryService _historyService;

        public HistoryController(HistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpPost("remove/{videoId}")]
        public async Task<IActionResult> RemoveFromHistory(int videoId)
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdStr, out int userId))
            {
                return Unauthorized();
            }

            var success = await _historyService.RemoveFromHistoryAsync(userId, videoId);
            
            if (success)
            {
                return Ok(new { success = true });
            }
            
            return BadRequest(new { success = false, message = "Не вдалося знайти або видалити запис." });
        }
    }
}
