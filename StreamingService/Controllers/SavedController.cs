using Microsoft.AspNetCore.Mvc;
using StreamingService.Services;

namespace StreamingService.Controllers;

[ApiController]
[Route("api/saved")]
public class SavedController : ControllerBase
{
    public class ToggleRequest
    {
        public int VideoId { get; set; }
    }

    [HttpPost("toggle")]
    public IActionResult Toggle([FromBody] ToggleRequest request)
    {
        bool isFoundInUpcoming = MockUpcomingService.ToggleSavedStatus(request.VideoId);
        if (!isFoundInUpcoming)
        {
            MockVideoService.ToggleSavedStatus(request.VideoId);
        }
        return Ok();
    }
   
}
