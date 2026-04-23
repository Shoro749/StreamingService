using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;
using StreamingService.Extensions;
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
                        .Select(i => /*"/" + i.BlobContainer + "/" +*/ i.BlobPath)
                        .FirstOrDefault() ?? "/images/placeholder-banner.jpg",

                    Duration = v.Seasons
                        .OrderBy(s => s.NumberOfSeason)
                        .SelectMany(s => s.Episodes)
                        .OrderBy(e => e.EpisodeNumber)
                        .Select(e => e.Duration > 0 ? $"{e.Duration / 60} хв" : "")
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

                    TrailerUrl = v.Trailerurl ?? "#",
                    TrailerDuration = v.TrailerDuration.HasValue
                        ? $"{v.TrailerDuration.Value / 60:D2}:{v.TrailerDuration.Value % 60:D2}"
                        : "00:00",
                    IsFavorite = userId.HasValue && v.Lists
                        .Any(f => f.UserProfileId == userId.Value),
                })
                .ToListAsync();
        }

        public IQueryable<VideoCardViewModel> GetVideoProjections(string locale, VideoType? mediaType = null, int? userId = null)
        {
            var baseVideos = _context.Videos.AsQueryable();

            if (mediaType.HasValue)
            {
                baseVideos = baseVideos.ApplyMediaTypeFilter(mediaType.Value.ToString());
            }

            return baseVideos
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
                        .Select(i => /*"/" + i.BlobContainer + "/" +*/ i.BlobPath)
                        .FirstOrDefault()
                        ?? "/images/placeholder-poster.jpg",

                    BackdropUrl = v.Images
                        .Where(i => i.Type == "backdrop" || i.Type == "banner")
                        .Select(i => /*"/" + i.BlobContainer + "/" +*/ i.BlobPath)
                        .FirstOrDefault()
                        ?? "/images/placeholder-backdrop.jpg",

                    ThumbnailUrl = v.Images
                        .Where(i => i.Type == "thumbnail")
                        .Select(i => /*"/" + i.BlobContainer + "/" +*/ i.BlobPath)
                        .FirstOrDefault()
                        ?? v.Images
                            .Where(i => i.Type == "poster")
                            .Select(i => /*"/" + i.BlobContainer + "/" +*/ i.BlobPath)
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
                        .Select(e => e.Duration > 0 ? $"{e.Duration / 60} хв" : "")
                        .FirstOrDefault()
                        ?? "",

                    AgeRating = v.AgeRating ?? "0+",

                    Genres = v.GenreVideos
                        .Select(g => g.Genre.GenreTranslations
                            .Where(t => t.LocaleCode == locale)
                            .Select(t => t.Name)
                            .FirstOrDefault()
                            ?? g.Genre.GenreTranslations.Select(t => t.Name).FirstOrDefault())
                        .Where(name => !string.IsNullOrEmpty(name))
                        .ToList(),

                    TrailerUrl = v.Trailerurl ?? "#",
                    TrailerDuration = v.TrailerDuration.HasValue
                        ? $"{v.TrailerDuration.Value / 60:D2}:{v.TrailerDuration.Value % 60:D2}"
                        : "00:00",

                    IsFavorite = userId.HasValue && v.Lists
                        .Any(l => l.UserProfileId == userId.Value && l.ListType == UserVideoListType.Favorite),

                    IsSavedForLater = userId.HasValue && v.Lists
                        .Any(l => l.UserProfileId == userId.Value && l.ListType == UserVideoListType.WatchLater),

                    VideoType = !string.IsNullOrEmpty(v.VideoType)
                        ? Enum.Parse<VideoType>(v.VideoType)
                        : VideoType.Movie,

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

                    Scenes = v.Images
                        .Where(i => i.Type == "scene")
                        .Select(i => new SceneViewModel
                        {
                            SceneImageUrl = /*"/" + i.BlobContainer + "/" +*/ i.BlobPath,
                        })
                        .ToList()
                });
        }

        public async Task<Dictionary<string, List<VideoCardViewModel>>> GetUpcomingReleasesAsync(string locale, int? userId = null, VideoType? mediaType = null)
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

            var videoIds = upcomingEpisodes
                .Select(e => e.VideoId)
                .Distinct()
                .ToList();

            var videosQuery = GetVideoProjections(locale, mediaType, userId).Where(v => videoIds.Contains(v.Id));

            var videosWithUserData = await GetVideosWithUserDataAsync(videosQuery, userId, locale);

            var groupedReleases = upcomingEpisodes
                .GroupBy(e => e.ReleaseDate)
                .OrderBy(g => g.Key)
                .ToDictionary(
                    g => g.Key.ToString("dd MMM, yyyy", culture).Replace(".", "").ToLower(),
                    g => g
                        .Select(e =>
                        {
                            var vid = videosWithUserData.FirstOrDefault(v => v.Id == e.VideoId);
                            if (vid == null) return null;

                            vid.Year = e.ReleaseDate.Year;
                            return vid;
                        })
                        .Where(v => v != null)
                        .DistinctBy(v => v!.Id)
                        .Select(v => v!)
                        .ToList()
                );

            return groupedReleases;
        }

        public async Task<List<VideoCardViewModel>> GetSliderVideosAsync(string locale, int? userId = null, VideoType? mediaType = null)
        {
            var query = GetVideoProjections(locale, mediaType)
                .OrderByDescending(v => v.Rating)
                .Take(10);

            return await GetVideosWithUserDataAsync(query, userId, locale);
        }

        public async Task<List<VideoCardViewModel>> GetPopularVideosAsync(string locale, int? userId = null, VideoType? mediaType = null)
        {
            var query = GetVideoProjections(locale, mediaType)
                .OrderByDescending(v => v.Rating)
                .Take(20);

            return await GetVideosWithUserDataAsync(query, userId, locale);
        }

        public async Task<List<VideoCardViewModel>> GetTrendingVideosAsync(string locale, int? userId = null, VideoType? mediaType = null)
        {
            var sevenDaysAgo = DateTime.UtcNow.Date.AddDays(-7);

            var videoIds = await _context.VideoEpisodeDailyStats
                .Where(s => s.Date >= sevenDaysAgo)
                .GroupBy(s => s.VideoEpisode.VideoSeason.VideoId)
                .OrderByDescending(g => g.Sum(x => x.TotalUserViews))
                .Take(20)
                .Select(g => g.Key)
                .ToListAsync();

            var query = GetVideoProjections(locale, mediaType, userId).Where(v => videoIds.Contains(v.Id));

            return await GetVideosWithUserDataAsync(query, userId, locale);
        }

        public async Task<List<VideoCardViewModel>> GetNewReleasesVideosAsync(string locale, int? userId = null, VideoType? mediaType = null)
        {
            var videoIds = await _context.VideoEpisode
                .OrderByDescending(e => e.ReleaseDate)
                .Take(50)
                .Select(e => e.VideoSeason.VideoId)
                .Distinct()
                .Take(20)
                .ToListAsync();

            var query = GetVideoProjections(locale, mediaType)
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
                        .Select(i => /*"/" + i.BlobContainer + "/" +*/ i.BlobPath)
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
                var userLists = await _context.UserVideoLists
                    .Where(f => f.UserProfileId == userId.Value)
                    .Select(f => new { f.VideoId, f.ListType })
                    .ToListAsync();

                foreach (var video in videos)
                {
                    video.IsFavorite = userLists.Any(l => l.VideoId == video.Id && l.ListType == UserVideoListType.Favorite);
                    video.IsSavedForLater = userLists.Any(l => l.VideoId == video.Id && l.ListType == UserVideoListType.WatchLater);
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
            if (genreCodes == null || !genreCodes.Any())
                return new List<VideoCardViewModel>();

            var normalized = genreCodes
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim().ToLowerInvariant())
                .ToList();

            if (!normalized.Any())
                return new List<VideoCardViewModel>();

            var matchingGenreIds = await _context.Genres
                .Where(g =>
                    normalized.Contains(g.Code.ToLower()) ||
                    g.GenreTranslations.Any(gt =>
                        gt.LocaleCode == locale && normalized.Contains(gt.Name.ToLower())))
                .Select(g => g.Id)
                .ToListAsync();

            if (!matchingGenreIds.Any())
                return new List<VideoCardViewModel>();

            var videoIds = await _context.GenresVideos
                .Where(gv => matchingGenreIds.Contains(gv.GenreId))
                .Select(gv => gv.VideoId)
                .Distinct()
                .ToListAsync();

            if (!videoIds.Any())
                return new List<VideoCardViewModel>();

            var query = GetVideoProjections(locale, null, userId)
                .Where(v => videoIds.Contains(v.Id))
                .OrderByDescending(v => v.Rating)
                .Take(20);

            return await GetVideosWithUserDataAsync(query, userId, locale);
        }

        public async Task<SearchResultsViewModel> SearchVideosAsync(string? query, int? genreId, string? sortBy, int page, int pageSize, string locale, int? userId, VideoType? mediaType = null)
        {
            var baseQuery = GetVideoProjections(locale, mediaType, userId);

            if (!string.IsNullOrWhiteSpace(query))
            {
                baseQuery = baseQuery.Where(v =>
                    v.Title.Contains(query) ||
                    v.Description.Contains(query) ||
                    v.Genres.Any(g => g.Contains(query))
                );
            }

            if (genreId.HasValue)
            {
                var videoIds = await _context.GenresVideos
                    .Where(gv => gv.GenreId == genreId.Value)
                    .Select(gv => gv.VideoId)
                    .Distinct()
                    .ToListAsync();

                if (!videoIds.Any())
                {
                    return new SearchResultsViewModel
                    {
                        Query = query,
                        SelectedGenreId = genreId,
                        SortBy = sortBy,
                        Videos = new List<VideoCardViewModel>(),
                        TotalResults = 0,
                        CurrentPage = page,
                        TotalPages = 0,
                        PageSize = pageSize
                    };
                }

                baseQuery = baseQuery.Where(v => videoIds.Contains(v.Id));
            }

            baseQuery = sortBy switch
            {
                "rating" => baseQuery.OrderByDescending(v => v.Rating),
                "year" => baseQuery.OrderByDescending(v => v.Year),
                "title" => baseQuery.OrderBy(v => v.Title),
                "newest" => baseQuery.OrderByDescending(v => v.Id),
                _ => baseQuery.OrderByDescending(v => v.Rating)
            };

            var totalCount = await baseQuery.CountAsync();

            var videos = await baseQuery.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new SearchResultsViewModel
            {
                Query = query,
                SelectedGenreId = genreId,
                SortBy = sortBy,
                Videos = videos,
                TotalResults = totalCount,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                PageSize = pageSize
            };
        }

        public async Task<List<string>> GetSearchSuggestionsAsync(string query, string locale, int limit)
        {
            var normalizedQuery = query.ToLower().Trim();

            var videoTitles = await _context.VideoTranslations
                .Where(vt => vt.LocaleCode.StartsWith(locale) && vt.Title.ToLower().Contains(normalizedQuery))
                .Select(vt => vt.Title)
                .Distinct()
                .Take(limit / 2)
                .ToListAsync();

            var genreNames = await _context.GenresTranslations
                .Where(gt => gt.LocaleCode.StartsWith(locale) && gt.Name.ToLower().Contains(normalizedQuery))
                .Select(gt => gt.Name)
                .Distinct()
                .Take(limit / 2)
                .ToListAsync();
            var suggestions = videoTitles.Concat(genreNames).Distinct().Take(limit).ToList();

            return suggestions;
        }
    }
}
