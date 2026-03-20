using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;
using System.Globalization;

namespace StreamingService.Repositories
{
    public class MoviesRepository
    {
        private readonly AppDbContext _context;
        public MoviesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<HeroItemViewModel>> GetHeroSlidersAsync(string locale, int? userId = null)
        {
            return await _context.Videos
                .Where(v => v.Seasons.Any(s => s.Episodes.Any()))
                .OrderByDescending(v => v.RatingSum / (v.RatingCount == 0 ? 1 : v.RatingCount))
                .Take(5)
                .Select(v => new HeroItemViewModel
                {
                    Id = v.Id,

                    Title = v.Translations
                        .Where(t => t.LocaleCode == locale)
                        .Select(t => t.Title)
                        .FirstOrDefault()
                        ?? v.Translations.Select(t => t.Title).FirstOrDefault()
                        ?? "Без назви",

                    ImageUrl = v.Images
                        .Where(i => i.Type == "banner" || i.Type == "backdrop")
                        .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                        .FirstOrDefault() ?? "/images/placeholder-banner.jpg",

                    Duration = v.Seasons
                        .OrderBy(s => s.NumberOfSeason)
                        .SelectMany(s => s.Episodes)
                        .OrderBy(e => e.EpisodeNumber)
                        .Select(e => e.Duration > 0 ? $"{e.Duration} хвилин" : "")
                        .FirstOrDefault() ?? "",

                    Year = v.Seasons
                        .OrderBy(s => s.NumberOfSeason)
                        .SelectMany(s => s.Episodes)
                        .Where(e => e.ReleaseDate != default(DateOnly))
                        .OrderBy(e => e.ReleaseDate)
                        .Select(e => e.ReleaseDate.Year)
                        .FirstOrDefault(),

                    AgeRating = v.AgeRating ?? "0+",

                    Genres = v.GenreVideos
                        .Select(gv => gv.Genre.GenreTranslations
                        .Where(gt => gt.LocaleCode == locale)
                        .Select(gt => gt.Name)
                        .FirstOrDefault())
                        .Where(name => !string.IsNullOrEmpty(name))
                        .ToList(),

                    TrailerUrl = "#",
                    TrailerDuration = v.TrailerDuration.ToString(),
                    IsFavorite = userId.HasValue && v.Favorites
                        .Any(f => f.UserProfileId == userId.Value),
                })
                .ToListAsync();
        }

        public IQueryable<VideoCardViewModel> GetVideoProjections(string locale, int? userId = null)
        {
            return _context.Videos
                .Select(v => new VideoCardViewModel
                {
                    Id = v.Id,

                    Title = v.Translations
                        .Where(t => t.LocaleCode == locale)
                        .Select(t => t.Title)
                        .FirstOrDefault()
                        ?? v.Translations.Select(t => t.Title).FirstOrDefault()
                        ?? "Без назви",

                    Description = v.Translations
                        .Where(t => t.LocaleCode == locale)
                        .Select(t => t.Description)
                        .FirstOrDefault()
                        ?? v.Translations.Select(t => t.Description).FirstOrDefault()
                        ?? "",

                    PosterUrl = v.Images
                        .Where(i => i.Type == "poster")
                        .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                        .FirstOrDefault()
                        ?? "/images/placeholder-poster.jpg",

                    BackdropUrl = v.Images
                        .Where(i => i.Type == "backdrop" || i.Type == "banner")
                        .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                        .FirstOrDefault()
                        ?? "/images/placeholder-backdrop.jpg",

                    ThumbnailUrl = v.Images
                        .Where(i => i.Type == "thumbnail")
                        .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                        .FirstOrDefault()
                        ?? v.Images
                            .Where(i => i.Type == "poster")
                            .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                            .FirstOrDefault()
                        ?? "/images/placeholder-thumbnail.jpg",

                    Rating = v.RatingCount == 0
                        ? 0
                        : (double)v.RatingSum / v.RatingCount,

                    Year = v.Seasons
                        .OrderBy(s => s.NumberOfSeason)
                        .SelectMany(s => s.Episodes)
                        .Where(e => e.ReleaseDate != default(DateOnly))
                        .OrderBy(e => e.ReleaseDate)
                        .Select(e => e.ReleaseDate.Year)
                        .FirstOrDefault(),

                    ReleaseDate = v.Seasons
                        .OrderBy(s => s.NumberOfSeason)
                        .SelectMany(s => s.Episodes)
                        .Where(e => e.ReleaseDate != default(DateOnly))
                        .OrderBy(e => e.ReleaseDate)
                        .Select(e => e.ReleaseDate.ToDateTime(TimeOnly.MinValue))
                        .FirstOrDefault(),

                    Duration = v.Seasons
                        .OrderBy(s => s.NumberOfSeason)
                        .SelectMany(s => s.Episodes)
                        .OrderBy(e => e.EpisodeNumber)
                        .Select(e => e.Duration > 0 ? $"{e.Duration} хв" : "")
                        .FirstOrDefault()
                        ?? "",

                    AgeRating = "0+",

                    Genres = v.GenreVideos
                        .Select(g => g.Genre.GenreTranslations
                            .Where(t => t.LocaleCode == locale)
                            .Select(t => t.Name)
                            .FirstOrDefault()
                            ?? g.Genre.GenreTranslations.Select(t => t.Name).FirstOrDefault())
                        .Where(name => !string.IsNullOrEmpty(name))
                        .ToList(),

                    TrailerUrl = "#",
                    TrailerDuration = v.TrailerDuration.ToString(),

                    IsFavorite = userId.HasValue && v.Favorites
                        .Any(f => f.UserProfileId == userId.Value),

                    IsSavedForLater = false, // TODO

                    VideoType = VideoType.Movie, // TODO

                    Actors = v.PersonVideos
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
                            //ImageUrl = pv.Person.Images
                            //    .Where(i => i.Type == "profile")
                            //    .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                            //    .FirstOrDefault()
                            //    ?? "/images/placeholder-actor.jpg",
                            Character = pv.Person.PersonTranslations
                                .Where(pt => pt.LocaleCode == locale)
                                .Select(pt => pt.Name)
                                .FirstOrDefault()
                                ?? ""
                        })
                        .ToList(),

                    Scenes = new List<SceneViewModel>()
                });
        }

        public async Task<Dictionary<string, List<VideoCardViewModel>>> GetUpcomingReleasesAsync(string locale)
        {
            var culture = new CultureInfo("uk-UA");

            var upcomingEpisodes = await _context.VideoEpisode
                .Where(e => e.ReleaseDate > DateOnly.FromDateTime(DateTime.UtcNow))
                .OrderBy(e => e.ReleaseDate)
                .Take(100)
                .Select(e => new
                {
                    VideoId = e.VideoSeason.VideoId,
                    ReleaseDate = e.ReleaseDate,
                    Video = e.VideoSeason.Video
                })
                .ToListAsync();

            var groupedReleases = upcomingEpisodes
                .GroupBy(e => e.ReleaseDate)
                .OrderBy(g => g.Key)
                .ToDictionary(
                    g => g.Key.ToString("dd MMM, yyyy", culture).Replace(".", "").ToLower(),
                    g => g.Select(e => new VideoCardViewModel
                    {
                        Id = e.VideoId,

                        Title = e.Video.Translations
                            .Where(t => t.LocaleCode == locale)
                            .Select(t => t.Title)
                            .FirstOrDefault()
                            ?? e.Video.Translations.Select(t => t.Title).FirstOrDefault()
                            ?? "Без назви",

                        PosterUrl = e.Video.Images
                            .Where(i => i.Type == "poster")
                            .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                            .FirstOrDefault()
                            ?? "/images/placeholder-poster.jpg",

                        Rating = e.Video.RatingCount == 0 ? 0 : (double)e.Video.RatingSum / e.Video.RatingCount,

                        Year = e.ReleaseDate.Year,

                        Genres = e.Video.GenreVideos
                            .Select(gv => gv.Genre.GenreTranslations
                                .Where(gt => gt.LocaleCode == locale)
                                .Select(gt => gt.Name)
                                .FirstOrDefault()
                                ?? gv.Genre.GenreTranslations.Select(gt => gt.Name).FirstOrDefault())
                            .Where(name => !string.IsNullOrEmpty(name))
                            .ToList()
                    })
                    .DistinctBy(v => v.Id)
                    .ToList()
                );

            return groupedReleases;
        }

        public async Task<List<VideoCardViewModel>> GetSliderVideosAsync(string locale, int? userId = null)
        {
            var query = GetVideoProjections(locale)
                .OrderByDescending(v => v.Rating)
                .Take(10);

            return await GetVideosWithUserDataAsync(query, userId, locale);
        }

        public async Task<List<VideoCardViewModel>> GetPopularVideosAsync(string locale, int? userId = null)
        {
            var query = GetVideoProjections(locale)
                .OrderByDescending(v => v.Rating)
                .Take(20);

            return await GetVideosWithUserDataAsync(query, userId, locale);
        }

        public async Task<List<VideoCardViewModel>> GetTrendingVideosAsync(string locale, int? userId = null)
        {
            var sevenDaysAgo = DateTime.UtcNow.Date.AddDays(-7);

            var videoIds = await _context.VideoEpisodeDailyStats
                .Where(s => s.Date >= sevenDaysAgo)
                .GroupBy(s => s.VideoEpisode.VideoSeason.VideoId)
                .OrderByDescending(g => g.Sum(x => x.TotalUserViews))
                .Take(20)
                .Select(g => g.Key)
                .ToListAsync();

            var query = GetVideoProjections(locale)
                .Where(v => videoIds.Contains(v.Id));

            return await GetVideosWithUserDataAsync(query, userId, locale);
        }

        public async Task<List<VideoCardViewModel>> GetNewReleasesVideosAsync(string locale, int? userId = null)
        {
            var videoIds = await _context.VideoEpisode
                .OrderByDescending(e => e.ReleaseDate)
                .Take(50)
                .Select(e => e.VideoSeason.VideoId)
                .Distinct()
                .Take(20)
                .ToListAsync();

            var query = GetVideoProjections(locale)
                .Where(v => videoIds.Contains(v.Id));

            return await GetVideosWithUserDataAsync(query, userId, locale);
        }

        public async Task<List<VideoCardViewModel>> GetWeeklyHitsVideosAsync(string locale, int? userId = null)
        {
            var sevenDaysAgo = DateTime.UtcNow.AddDays(-7);

            var videoIds = await _context.UserEpisodesHistories
                .Where(h => h.LastWatchedAt >= sevenDaysAgo)
                .GroupBy(h => h.VideoEpisode.VideoSeason.VideoId)
                .OrderByDescending(g => g.Count())
                .Take(20)
                .Select(g => g.Key)
                .ToListAsync();

            var query = GetVideoProjections(locale)
                .Where(v => videoIds.Contains(v.Id));

            return await GetVideosWithUserDataAsync(query, userId, locale);
        }

        public async Task<List<VideoCardViewModel>> GetVideosByGenreAsync(string genre, string locale, int count = 20)
        {
            return await _context.Videos
                .Where(v => v.GenreVideos.Any(gv => gv.Genre.GenreTranslations
                    .Any(gt => gt.LocaleCode == locale && gt.Name.ToLower().Contains(genre.ToLower()))))
                .OrderByDescending(v => v.RatingCount == 0 ? 0 : (double)v.RatingSum / v.RatingCount)
                .Take(count)
                .Select(v => new VideoCardViewModel
                {
                    Id = v.Id,
                    Title = v.Translations
                        .Where(t => t.LocaleCode == locale)
                        .Select(t => t.Title)
                        .FirstOrDefault()
                        ?? v.Translations.Select(t => t.Title).FirstOrDefault()
                        ?? "Без назви",
                    PosterUrl = v.Images
                        .Where(i => i.Type == "poster")
                        .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
                        .FirstOrDefault()
                        ?? "/images/placeholder-poster.jpg",
                    Rating = v.RatingCount == 0 ? 0 : (double)v.RatingSum / v.RatingCount,
                    Genres = v.GenreVideos
                        .Select(gv => gv.Genre.GenreTranslations
                            .Where(gt => gt.LocaleCode == locale)
                            .Select(gt => gt.Name)
                            .FirstOrDefault()
                            ?? gv.Genre.GenreTranslations.Select(gt => gt.Name).FirstOrDefault())
                        .Where(name => !string.IsNullOrEmpty(name))
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task<List<VideoCardViewModel>> GetVideosWithUserDataAsync(IQueryable<VideoCardViewModel> baseQuery, int? userId, string locale)
        {
            var videos = await baseQuery.ToListAsync();

            if (userId.HasValue)
            {
                var favoriteVideoIds = await _context.UserVideoFavorites
                    .Where(f => f.UserProfileId == userId.Value)
                    .Select(f => f.VideoId)
                    .ToListAsync();

                foreach (var video in videos)
                {
                    video.IsFavorite = favoriteVideoIds.Contains(video.Id);
                }
            }

            return videos;
        }

        public async Task<List<GenreViewModel>> GetAllGenresAsync(string locale)
        {
            return await _context.Genres
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Code = g.Code,
                    Name = g.GenreTranslations
                        .Where(t => t.LocaleCode == locale)
                        .Select(t => t.Name)
                        .FirstOrDefault()
                        ?? g.GenreTranslations.Select(t => t.Name).FirstOrDefault()
                        ?? g.Code
                })
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

        public async Task<List<VideoCardViewModel>> GetVideosByGenresAsync(List<string> genreCodes, string locale, int? userId = null)
        {
            var query = GetVideoProjections(locale, userId)
                .Where(v => v.Genres.Any(g => genreCodes.Contains(g)));

            return await query.ToListAsync();
        }
    }
}
