using Microsoft.AspNetCore.Mvc;

namespace StreamingService.Controllers
{
    public class PlayerController : Controller
    {
        public PlayerController() { }

        [HttpGet("/player/{episodeId}")]
        public IActionResult Index(int episodeId)
        {
            var masterUrl = $"stream/{episodeId}/master";

            return View((object)masterUrl);
        }
    }
}
