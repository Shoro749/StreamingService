using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.DTO;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class FavoritesRepository
    {
        private readonly AppDbContext _context;

        public FavoritesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<VideoCardViewModel>> GetFavoritesByProfileIdAsync(int userProfileId, string locale = "uk")
        {
            return await _context.UserVideoFavorites
                .Where(f => f.UserProfileId == userProfileId)
                .Select(f => new VideoCardViewModel
                {
                    Id = f.Video.Id,

                    Title = f.Video.Translations
                        .Where(t => t.LocaleCode == locale)
                        .Select(t => t.Title)
                        .FirstOrDefault(),

                    PosterUrl = f.Video.Images
                        .Where(i => i.Type == "poster")
                        .Select(i => i.BlobContainer + "/" + i.BlobPath)
                        .FirstOrDefault(),

                    Rating = f.Video.RatingCount == 0
                        ? 0
                        : (double)f.Video.RatingSum / f.Video.RatingCount,

                    Genres = f.Video.GenreVideos
                        .Select(g => g.Genre.GenreTranslations
                            .Where(t => t.LocaleCode == locale)
                            .Select(t => t.Name)
                            .FirstOrDefault())
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task<bool> AddToFavoritesAsync(int userProfileId, int videoId)
        {
            try
            {
                var exists = await _context.UserVideoFavorites
                .AnyAsync(f => f.UserProfileId == userProfileId && f.VideoId == videoId);

                if (!exists)
                {
                    var favorite = new UserVideoFavorite
                    {
                        UserProfileId = userProfileId,
                        VideoId = videoId
                    };

                    await _context.UserVideoFavorites.AddAsync(favorite);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public async Task<bool> RemoveFromFavoritesAsync(int userProfileId, int videoId)
        {
            try
            {
                var favorite = await _context.UserVideoFavorites
                .FirstOrDefaultAsync(f => f.UserProfileId == userProfileId && f.VideoId == videoId);

                if (favorite != null)
                {
                    _context.UserVideoFavorites.Remove(favorite);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
