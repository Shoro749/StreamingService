using Microsoft.AspNetCore.Mvc;
using StreamingService.Services;

namespace StreamingService.Controllers;

[ApiController]
[Route("api/videos")]
public class VideoInfoController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetDetails(int id)
    {
        var video = MockVideoService.GetAllVideos()
            .Concat(MockUpcomingService.GetUpcomingReleases())
            .FirstOrDefault(v => v.Id == id);

        if (video == null)
        {
            return NotFound();
        }

        return Ok(video);
    }
}
