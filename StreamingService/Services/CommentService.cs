using StreamingService.DTO.Requests;
using StreamingService.Models;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class CommentService
    {
        private readonly EFRepository<Comment> _commentRepository;
        private readonly EFRepository<UserCommentLike> _likeRepository;

        public CommentService(EFRepository<Comment> commentRepo, EFRepository<UserCommentLike> likeRepo)
        {
            _commentRepository = commentRepo;
            _likeRepository = likeRepo;
        }

        public async Task<bool> AddCommentAsync(CommentCreateViewModel request)
        {
            var comment = new Comment
            {
                UserProfileId = request.UserProfileId,
                VideoId = request.VideoId,
                Text = request.Text,
                ParentId = request.ParentId,
                CreateAt = DateTime.UtcNow
            };
            return await _commentRepository.AddDataAsync(comment);
        }

        public async Task<bool> ToggleLikeAsync(CommentLikeViewModel request)
        {
            var existingLike = (await _likeRepository.GetListDataAsync())
                .FirstOrDefault(l => l.UserProfileId == request.UserProfileId && l.CommentId == request.CommentId);

            if (existingLike != null)
            {
                return await _likeRepository.DeleteDataAsync(existingLike.Id);
            }

            return await _likeRepository.AddDataAsync(new UserCommentLike
            {
                UserProfileId = request.UserProfileId,
                CommentId = request.CommentId
            });
        }
    }
}
