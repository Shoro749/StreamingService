using Microsoft.AspNetCore.Mvc;
using StreamingService.Services;

namespace StreamingService.Controllers;

[ApiController]
[Route("api/saved")]
public class SavedController : ControllerBase
{
    private readonly MockVideoService _mockService;

    public SavedController(MockVideoService mockService)
    {
        _mockService = mockService;
    }

    public class ToggleRequest
    {
        public int VideoId { get; set; }
    }

    [HttpPost("toggle")]
    public IActionResult Toggle([FromBody] ToggleRequest request)
    {
        _mockService.ToggleSavedStatus(request.VideoId);
        return Ok();
    }
   
}
