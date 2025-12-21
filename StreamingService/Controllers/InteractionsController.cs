using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Requests;
using StreamingService.Services;

namespace StreamingService.Controllers
{
    public class InteractionsController : Controller
    {
        private readonly CommentService _commentService;
        private readonly RatingService _ratingService;

        public InteractionsController(CommentService commentService, RatingService ratingService)
        {
            _commentService = commentService;
            _ratingService = ratingService;
        }

        [HttpPost]
        public async Task<IActionResult> PostComment([FromBody] CommentCreateViewModel request) =>
            await _commentService.AddCommentAsync(request) ? Ok() : BadRequest();

        [HttpPost]
        public async Task<IActionResult> LikeComment([FromBody] CommentLikeViewModel request) =>
            await _commentService.ToggleLikeAsync(request) ? Ok() : BadRequest();

        [HttpPost]
        public async Task<IActionResult> RateVideo([FromBody] VideoRatingViewModel request) =>
            await _ratingService.SetRatingAsync(request) ? Ok() : BadRequest();
    }
}
