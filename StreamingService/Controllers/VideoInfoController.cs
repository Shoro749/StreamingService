using Microsoft.AspNetCore.Mvc;
using StreamingService.Services;

namespace StreamingService.Controllers;

[ApiController]
[Route("api/videos")]
public class VideoInfoController : ControllerBase
{
    private readonly MockVideoService _mockService;
    public VideoInfoController(MockVideoService mockService)
    {
        _mockService = mockService;
    }

    [HttpGet("{id}")]
    public IActionResult GetDetails(int id)
    {
        var video = _mockService.GetAllVideos()
            .FirstOrDefault(v => v.Id == id);

        if (video == null)
        {
            return NotFound();
        }

        return Ok(video);
    }
}
