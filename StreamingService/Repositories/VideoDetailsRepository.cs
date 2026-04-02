using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;

namespace StreamingService.Repositories
{
    public class VideoDetailsRepository
    {
        private readonly AppDbContext _context;

        public VideoDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VideoCardViewModel?> GetVideoDetailsByIdAsync(int videoId, string locale, int? userId = null)
        {
            var video = await _context.Videos
                .Include(v => v.Translations)
                .Include(v => v.Images)
                .Include(v => v.Seasons)
                    .ThenInclude(s => s.Episodes)
                .Include(v => v.GenreVideos)
                    .ThenInclude(gv => gv.Genre)
                        .ThenInclude(g => g.GenreTranslations)
                .Include(v => v.PersonVideos)
                    .ThenInclude(pv => pv.Person)
                        .ThenInclude(p => p.PersonTranslations)
                .Include(v => v.PersonVideos)
                    .ThenInclude(pv => pv.Person)
                        .ThenInclude(p => p.Images)
                .Include(v => v.PersonVideos)
                    .ThenInclude(pv => pv.PersonRole)
                .Include(v => v.Lists)
                .FirstOrDefaultAsync(v => v.Id == videoId);

            if (video == null) return null;

            VideoType videoType = VideoType.Movie;
            if (!string.IsNullOrEmpty(video.VideoType))
            {
                Enum.TryParse(video.VideoType, true, out videoType);
            }

            return new VideoCardViewModel
            {
                Id = video.Id,

                Title = video.Translations
                    .Where(t => t.LocaleCode == locale)
                    .Select(t => t.Title)
                    .FirstOrDefault()
                    ?? video.Translations.Select(t => t.Title).FirstOrDefault()
                    ?? "Без назви",

                Description = video.Translations
                    .Where(t => t.LocaleCode == locale)
                    .Select(t => t.Description)
                    .FirstOrDefault()
                    ?? video.Translations.Select(t => t.Description).FirstOrDefault()
                    ?? "",

                PosterUrl = video.Images
                    .Where(i => i.Type == "poster")
                    .Select(i => i.BlobContainer == "external"
                        ? i.BlobPath
                        : "/" + i.BlobContainer + "/" + i.BlobPath)
                    .FirstOrDefault()
                    ?? "/images/placeholder-poster.jpg",

                BackdropUrl = video.Images
                    .Where(i => i.Type == "backdrop" || i.Type == "banner")
                    .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                    .FirstOrDefault()
                    ?? "/images/placeholder-backdrop.jpg",

                ThumbnailUrl = video.Images
                    .Where(i => i.Type == "thumbnail")
                    .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                    .FirstOrDefault()
                    ?? video.Images
                        .Where(i => i.Type == "poster")
                        .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                        .FirstOrDefault()
                    ?? "/images/placeholder-thumbnail.jpg",

                Rating = video.RatingCount == 0
                    ? 0
                    : Math.Round((double)video.RatingSum / video.RatingCount, 1),

                Year = video.Seasons
                    .OrderBy(s => s.NumberOfSeason)
                    .SelectMany(s => s.Episodes)
                    .Where(e => e.ReleaseDate != default(DateOnly))
                    .OrderBy(e => e.ReleaseDate)
                    .Select(e => e.ReleaseDate.Year)
                    .FirstOrDefault(),

                ReleaseDate = video.Seasons
                    .OrderBy(s => s.NumberOfSeason)
                    .SelectMany(s => s.Episodes)
                    .Where(e => e.ReleaseDate != default(DateOnly))
                    .OrderBy(e => e.ReleaseDate)
                    .Select(e => e.ReleaseDate.ToDateTime(TimeOnly.MinValue))
                    .FirstOrDefault(),

                Duration = video.Seasons
                    .OrderBy(s => s.NumberOfSeason)
                    .SelectMany(s => s.Episodes)
                    .OrderBy(e => e.EpisodeNumber)
                    .Select(e => e.Duration > 0 ? $"{e.Duration} хв" : "")
                    .FirstOrDefault()
                    ?? "",

                AgeRating = video.AgeRating ?? "12+",

                //TrailerUrl = video.TrailerUrl ?? "#",
                TrailerDuration = video.TrailerDuration.HasValue
                    ? $"{video.TrailerDuration.Value / 60}:{video.TrailerDuration.Value % 60:D2}"
                    : "2:30",

                Genres = video.GenreVideos
                    .Select(gv => gv.Genre.GenreTranslations
                        .Where(gt => gt.LocaleCode == locale)
                        .Select(gt => gt.Name)
                        .FirstOrDefault()
                        ?? gv.Genre.GenreTranslations.Select(gt => gt.Name).FirstOrDefault()
                        ?? gv.Genre.Code)
                    .Where(name => !string.IsNullOrEmpty(name))
                    .ToList(),

                IsFavorite = userId.HasValue && video.Lists
                    .Any(f => f.UserProfileId == userId.Value),

                IsSavedForLater = false, // TODO

                VideoType = videoType,

                Actors = video.PersonVideos
                    .Where(pv => pv.PersonRole.Code == "actor")
                    .Select(pv => new ActorViewModel
                    {
                        Id = pv.Person.Id,
                        Name = pv.Person.PersonTranslations
                            .Where(pt => pt.LocaleCode == locale)
                            .Select(pt => pt.Name)
                            .FirstOrDefault()
                            ?? pv.Person.PersonTranslations.Select(pt => pt.Name).FirstOrDefault()
                            ?? "",
                        PhotoUrl = pv.Person.Images
                            .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                            .FirstOrDefault()
                            ?? "/images/placeholder-actor.jpg",
                        Character = "" // TODO: можна додати поле character у persons_videos
                    })
                    .ToList(),

                Scenes = video.Images
                    .Where(i => i.Type == "scene")
                    .Select(i => new SceneViewModel
                    {
                        SceneImageUrl = "/" + i.BlobContainer + "/" + i.BlobPath,
                        Timestamp = "0:00"
                    })
                    .ToList()
            };
        }

        public async Task<List<VideoCardViewModel>> GetRecommendedVideosAsync(int videoId, string locale, int count = 10)
        {
            var currentVideoGenres = await _context.GenresVideos
                .Where(gv => gv.VideoId == videoId)
                .Select(gv => gv.GenreId)
                .ToListAsync();

            if (!currentVideoGenres.Any())
            {
                return await _context.Videos
                    .Where(v => v.Id != videoId)
                    .OrderByDescending(v => v.RatingCount == 0 ? 0 : (double)v.RatingSum / v.RatingCount)
                    .Take(count)
                    .Select(v => new VideoCardViewModel
                    {
                        Id = v.Id,
                        Title = v.Translations
                            .Where(t => t.LocaleCode == locale)
                            .Select(t => t.Title)
                            .FirstOrDefault() ?? "Без назви",
                        PosterUrl = v.Images
                            .Where(i => i.Type == "poster")
                            .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                            .FirstOrDefault() ?? "/images/placeholder-poster.jpg",
                        Rating = v.RatingCount == 0 ? 0 : (double)v.RatingSum / v.RatingCount,
                        Year = v.Seasons
                            .SelectMany(s => s.Episodes)
                            .Where(e => e.ReleaseDate != default)
                            .OrderBy(e => e.ReleaseDate)
                            .Select(e => e.ReleaseDate.Year)
                            .FirstOrDefault()
                    })
                    .ToListAsync();
            }

            return await _context.Videos
                .Where(v => v.Id != videoId
                    && v.GenreVideos.Any(gv => currentVideoGenres.Contains(gv.GenreId)))
                .OrderByDescending(v => v.GenreVideos.Count(gv => currentVideoGenres.Contains(gv.GenreId)))
                .ThenByDescending(v => v.RatingCount == 0 ? 0 : (double)v.RatingSum / v.RatingCount)
                .Take(count)
                .Select(v => new VideoCardViewModel
                {
                    Id = v.Id,
                    Title = v.Translations
                        .Where(t => t.LocaleCode == locale)
                        .Select(t => t.Title)
                        .FirstOrDefault() ?? "Без назви",
                    PosterUrl = v.Images
                        .Where(i => i.Type == "poster")
                        .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                        .FirstOrDefault() ?? "/images/placeholder-poster.jpg",
                    Rating = v.RatingCount == 0 ? 0 : (double)v.RatingSum / v.RatingCount,
                    Year = v.Seasons
                        .SelectMany(s => s.Episodes)
                        .Where(e => e.ReleaseDate != default)
                        .OrderBy(e => e.ReleaseDate)
                        .Select(e => e.ReleaseDate.Year)
                        .FirstOrDefault()
                })
                .ToListAsync();
        }
    }
}
