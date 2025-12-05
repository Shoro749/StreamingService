using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamingService.Context;
using StreamingService.DTO;

namespace StreamingService.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly DataContext _context;

        public FavoritesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int userId)
        {
            var favorites = await _context.UserVideoFavorites
                .Where(f => f.UserProfileId == userId)
                .Select(f => new VideoCardViewModel
                {
                    Id = f.Video.Id,
                    Title = f.Video.Translations
                        .Where(t => t.LocaleCode == "uk")
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
                            .Where(t => t.LocaleCode == "uk")
                            .Select(t => t.Name)
                            .FirstOrDefault())
                        .ToList()
                })
                .ToListAsync();

            return View(favorites);
        }
    }
}
