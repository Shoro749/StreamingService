using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.DTO.Requests;
using StreamingService.Models;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class RatingService
    {
        private readonly EFRepository<UserVideoRating> _ratingRepo;
        private readonly EFRepository<Video> _videoRepo;

        public RatingService(
            EFRepository<UserVideoRating> ratingRepo,
            EFRepository<Video> videoRepo)
        {
            _ratingRepo = ratingRepo;
            _videoRepo = videoRepo;
        }

        public async Task<bool> SetRatingAsync(VideoRatingViewModel model)
        {
            if (model.Rating < 1 || model.Rating > 10) return false;

            var allRatings = await _ratingRepo.GetListDataAsync();
            var existing = allRatings.FirstOrDefault(r =>
                r.UserProfileId == model.UserProfileId && r.VideoId == model.VideoId);

            bool success;
            if (existing != null)
            {
                existing.Rating = model.Rating;
                success = await _ratingRepo.UpdateDataAsync(existing);
            }
            else
            {
                success = await _ratingRepo.AddDataAsync(new UserVideoRating
                {
                    UserProfileId = model.UserProfileId,
                    VideoId = model.VideoId,
                    Rating = model.Rating
                });
            }

            return success;
        }
    }
}
