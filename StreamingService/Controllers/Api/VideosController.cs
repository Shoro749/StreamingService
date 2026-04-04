using Microsoft.AspNetCore.Mvc;
using StreamingService.Services;
using System.Globalization;
using System.Security.Claims;

namespace StreamingService.Controllers.Api;

[ApiController]
[Route("api/videos")]
public class VideosController : ControllerBase
{
    private readonly VideoDetailsService _videoDetailsService;

    public VideosController(VideoDetailsService videoDetailsService)
    {
        _videoDetailsService = videoDetailsService;
    }

    [HttpGet("{id:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> Get(int id)
    {
        var locale = CultureInfo.CurrentCulture.Name;
        int userId = 0;
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0", out userId);
        }

        var model = await _videoDetailsService.GetVideoDetailsAsync(id, locale, userId);
        if (model == null)
            return NotFound();

        return Ok(model);
    }
}