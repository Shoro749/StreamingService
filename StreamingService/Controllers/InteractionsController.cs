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

        [HttpPost("comment")]
        public async Task<IActionResult> PostComment(CommentCreateViewModel request)
        {
            await _commentService.AddCommentAsync(request);
            return Ok();
        }

        [HttpPost("comment/like")]
        public async Task<IActionResult> LikeComment(CommentLikeViewModel request)
        {
            await _commentService.ToggleLikeAsync(request);
            return Ok();
        }

        [HttpPost("rate")]
        public async Task<IActionResult> RateVideo(VideoRatingViewModel request)
        {
            await _ratingService.SetRatingAsync(request);
            return Ok();
        }
    }
}
