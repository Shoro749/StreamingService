using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;
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

        public async Task<List<VideoCardViewModel>> GetFavoritesByProfileIdAsync(int userProfileId, string locale, UserVideoListType listType)
        {
            return await _context.UserVideoLists
                .Where(f => f.UserProfileId == userProfileId && f.ListType == listType)
                .Select(f => new VideoCardViewModel
                {
                    Id = f.Video.Id,
                    Title = f.Video.Translations
                        .Where(t => t.LocaleCode == locale)
                        .Select(t => t.Title)
                        .FirstOrDefault()
                        ?? f.Video.Translations.Select(t => t.Title).FirstOrDefault()
                        ?? "Без назви",

                    PosterUrl = f.Video.Images
                        .Where(i => i.Type == "poster")
                        .Select(i => /*"/" + i.BlobContainer + "/" +*/ i.BlobPath)
                        .FirstOrDefault()
                        ?? "/images/placeholder-poster.jpg",

                    Rating = f.Video.RatingCount == 0 ? 0 : (double)f.Video.RatingSum / f.Video.RatingCount,

                    Year = f.Video.Seasons
                        .OrderBy(s => s.NumberOfSeason)
                        .SelectMany(s => s.Episodes)
                        .Where(e => e.ReleaseDate != default(DateOnly))
                        .OrderBy(e => e.ReleaseDate)
                        .Select(e => e.ReleaseDate.Year)
                        .FirstOrDefault(),

                    TrailerUrl = f.Video.Trailerurl ?? "#",

                    Genres = f.Video.GenreVideos
                        .Select(gv => gv.Genre.GenreTranslations
                            .Where(gt => gt.LocaleCode == locale)
                            .Select(gt => gt.Name)
                            .FirstOrDefault()
                            ?? gv.Genre.GenreTranslations.Select(gt => gt.Name).FirstOrDefault())
                        .Where(name => !string.IsNullOrEmpty(name))
                        .ToList(),

                    IsFavorite = f.ListType == UserVideoListType.Favorite,

                    IsSavedForLater = f.ListType == UserVideoListType.WatchLater,

                    Actors = f.Video.PersonVideos
                        .Where(pv => pv.PersonRole.Code == "actor")
                        .Select(pv => new ActorViewModel
                        {
                            //Id = pv.Person.Id,
                            Name = pv.Person.PersonTranslations
                                .Where(pt => pt.LocaleCode == locale)
                                .Select(pt => pt.Name)
                                .FirstOrDefault()
                                ?? pv.Person.PersonTranslations.Select(pt => pt.Name).FirstOrDefault()
                                ?? "",
                            ImageUrl = pv.Person.Images
                                .Select(i => /*"/" + i.BlobContainer + "/" +*/ i.BlobPath)
                                .FirstOrDefault()
                                ?? "/images/placeholder-actor.jpg",
                            Character = pv.Person.PersonTranslations
                                .Where(pt => pt.LocaleCode == locale)
                                .Select(pt => pt.Name)
                                .FirstOrDefault()
                                ?? ""
                        })
                        .ToList(),
                })
                .ToListAsync();
        }

        public async Task<bool> AddToFavoritesAsync(int userProfileId, int videoId, UserVideoListType listType)
        {
            try
            {
                var exists = await _context.UserVideoLists
                .AnyAsync(f => f.UserProfileId == userProfileId && f.VideoId == videoId);

                if (!exists)
                {
                    var favorite = new UserVideoList
                    {
                        UserProfileId = userProfileId,
                        VideoId = videoId,
                        ListType = listType
                    };

                    await _context.UserVideoLists.AddAsync(favorite);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public async Task<bool> RemoveFromFavoritesAsync(int userProfileId, int videoId, UserVideoListType listType)
        {
            try
            {
                var favorite = await _context.UserVideoLists
                .FirstOrDefaultAsync(f => f.UserProfileId == userProfileId && f.VideoId == videoId && f.ListType == listType);

                if (favorite != null)
                {
                    _context.UserVideoLists.Remove(favorite);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public async Task<bool> ExistsAsync(int userId, int videoId, UserVideoListType type)
        {
            return await _context.UserVideoLists.AnyAsync(x =>
                x.UserProfileId == userId &&
                x.VideoId == videoId &&
                x.ListType == type);
        }
    }
}
