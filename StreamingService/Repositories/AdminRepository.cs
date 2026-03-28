//using Microsoft.EntityFrameworkCore;
//using StreamingService.Data;
//using StreamingService.DTO.ViewModels;
//using StreamingService.Models;

//namespace StreamingService.Repositories
//{
//    public class AdminRepository
//    {
//        private readonly AppDbContext _context;

//        public AdminRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<DashboardStatsViewModel> GetDashboardStatsAsync()
//        {
//            var totalVideos = await _context.Videos.CountAsync();
//            var totalUsers = await _context.UserProfiles.CountAsync();
//            var totalSubscriptions = await _context.UsersSubscriptions
//                .Where(s => s.Status == "Active")
//                .CountAsync();

//            var last30DaysViews = await _context.VideoEpisodeDailyStats
//                .Where(s => s.Date >= DateTime.UtcNow.AddDays(-30))
//                .SumAsync(s => s.TotalUserViews);

//            var recentVideos = await _context.Videos
//                .OrderByDescending(v => v.Id)
//                .Take(5)
//                .Select(v => new VideoSummaryViewModel
//                {
//                    Id = v.Id,
//                    Title = v.Translations.Select(t => t.Title).FirstOrDefault() ?? "Без назви",
//                    Rating = v.RatingCount > 0 ? (double)v.RatingSum / v.RatingCount : 0
//                })
//                .ToListAsync();

//            return new DashboardStatsViewModel
//            {
//                TotalVideos = totalVideos,
//                TotalUsers = totalUsers,
//                ActiveSubscriptions = totalSubscriptions,
//                Last30DaysViews = last30DaysViews,
//                RecentVideos = recentVideos
//            };
//        }

//        public async Task<List<VideoAdminViewModel>> GetVideosPagedAsync(
//            int page,
//            int pageSize,
//            string? search,
//            int? genreId)
//        {
//            var query = _context.Videos.AsQueryable();

//            if (!string.IsNullOrEmpty(search))
//            {
//                query = query.Where(v => v.Translations.Any(t => t.Title.Contains(search)));
//            }

//            if (genreId.HasValue)
//            {
//                query = query.Where(v => v.GenreVideos.Any(gv => gv.GenreId == genreId.Value));
//            }

//            return await query
//                .OrderByDescending(v => v.Id)
//                .Skip((page - 1) * pageSize)
//                .Take(pageSize)
//                .Select(v => new VideoAdminViewModel
//                {
//                    Id = v.Id,
//                    Title = v.Translations.Select(t => t.Title).FirstOrDefault() ?? "Без назви",
//                    AgeRating = v.AgeRating ?? "12+",
//                    Rating = v.RatingCount > 0 ? (double)v.RatingSum / v.RatingCount : 0,
//                    SeasonsCount = v.Seasons.Count,
//                    EpisodesCount = v.Seasons.SelectMany(s => s.Episodes).Count(),
//                    PosterUrl = v.Images
//                        .Where(i => i.Type == "poster")
//                        .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
//                        .FirstOrDefault() ?? "/images/placeholder-poster.jpg",
//                    Genres = v.GenreVideos
//                        .Select(gv => gv.Genre.Code)
//                        .ToList()
//                })
//                .ToListAsync();
//        }

//        public async Task<int> GetVideosCountAsync(string? search, int? genreId)
//        {
//            var query = _context.Videos.AsQueryable();

//            if (!string.IsNullOrEmpty(search))
//            {
//                query = query.Where(v => v.Translations.Any(t => t.Title.Contains(search)));
//            }

//            if (genreId.HasValue)
//            {
//                query = query.Where(v => v.GenreVideos.Any(gv => gv.GenreId == genreId.Value));
//            }

//            return await query.CountAsync();
//        }

//        public async Task<int> CreateVideoAsync(CreateVideoViewModel model)
//        {
//            var video = new Video
//            {
//                RatingSum = 0,
//                RatingCount = 0,
//                AgeRating = model.AgeRating,
//                TrailerDuration = model.TrailerDuration
//            };

//            _context.Videos.Add(video);
//            await _context.SaveChangesAsync();

//            foreach (var translation in model.Translations)
//            {
//                _context.VideoTranslations.Add(new VideoTranslation
//                {
//                    VideoId = video.Id,
//                    LocaleCode = translation.LocaleCode,
//                    Title = translation.Title,
//                    Description = translation.Description
//                });
//            }

//            foreach (var genreId in model.GenreIds)
//            {
//                _context.GenreVideos.Add(new GenreVideo
//                {
//                    VideoId = video.Id,
//                    GenreId = genreId
//                });
//            }

//            await _context.SaveChangesAsync();

//            return video.Id;
//        }

//        public async Task<EditVideoViewModel?> GetVideoEditModelAsync(int id)
//        {
//            var video = await _context.Videos
//                .Include(v => v.Translations)
//                .Include(v => v.Images)
//                .Include(v => v.GenreVideos)
//                .Include(v => v.Seasons)
//                    .ThenInclude(s => s.Episodes)
//                .Include(v => v.PersonVideos)
//                    .ThenInclude(pv => pv.Person)
//                        .ThenInclude(p => p.PersonTranslations)
//                .FirstOrDefaultAsync(v => v.Id == id);

//            if (video == null) return null;

//            return new EditVideoViewModel
//            {
//                Id = video.Id,
//                AgeRating = video.AgeRating ?? "12+",
//                TrailerDuration = video.TrailerDuration,
//                Translations = video.Translations.Select(t => new VideoTranslationViewModel
//                {
//                    LocaleCode = t.LocaleCode,
//                    Title = t.Title,
//                    Description = t.Description ?? ""
//                }).ToList(),
//                SelectedGenreIds = video.GenreVideos.Select(gv => gv.GenreId).ToList(),
//                PosterUrl = video.Images
//                    .Where(i => i.Type == "poster")
//                    .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
//                    .FirstOrDefault(),
//                Seasons = video.Seasons
//                    .OrderBy(s => s.NumberOfSeason)
//                    .Select(s => new SeasonAdminViewModel
//                    {
//                        Id = s.Id,
//                        SeasonNumber = s.NumberOfSeason,
//                        Episodes = s.Episodes
//                            .OrderBy(e => e.EpisodeNumber)
//                            .Select(e => new EpisodeAdminViewModel
//                            {
//                                Id = e.Id,
//                                EpisodeNumber = e.EpisodeNumber,
//                                Duration = e.Duration,
//                                ReleaseDate = e.ReleaseDate
//                            })
//                            .ToList()
//                    })
//                    .ToList(),
//                Actors = video.PersonVideos
//                    .Where(pv => pv.PersonRole.Code == "actor")
//                    .Select(pv => new PersonSummaryViewModel
//                    {
//                        Id = pv.Person.Id,
//                        Name = pv.Person.PersonTranslations.Select(pt => pt.Name).FirstOrDefault() ?? ""
//                    })
//                    .ToList()
//            };
//        }

//        public async Task UpdateVideoAsync(int id, EditVideoViewModel model)
//        {
//            var video = await _context.Videos
//                .Include(v => v.Translations)
//                .Include(v => v.GenreVideos)
//                .FirstOrDefaultAsync(v => v.Id == id);

//            if (video == null) return;

//            video.AgeRating = model.AgeRating;
//            video.TrailerDuration = model.TrailerDuration;

//            foreach (var translation in model.Translations)
//            {
//                var existing = video.Translations.FirstOrDefault(t => t.LocaleCode == translation.LocaleCode);

//                if (existing != null)
//                {
//                    existing.Title = translation.Title;
//                    existing.Description = translation.Description;
//                }
//                else
//                {
//                    _context.VideoTranslations.Add(new VideoTranslation
//                    {
//                        VideoId = id,
//                        LocaleCode = translation.LocaleCode,
//                        Title = translation.Title,
//                        Description = translation.Description
//                    });
//                }
//            }

//            _context.GenresVideos.RemoveRange(video.GenreVideos);
//            foreach (var genreId in model.SelectedGenreIds)
//            {
//                _context.GenresVideos.Add(new GenreVideo
//                {
//                    VideoId = id,
//                    GenreId = genreId
//                });
//            }

//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteVideoAsync(int id)
//        {
//            var video = await _context.Videos.FindAsync(id);
//            if (video != null)
//            {
//                _context.Videos.Remove(video);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task SaveImagePathAsync(int videoId, string container, string path, string type)
//        {
//            var oldImages = await _context.VideoImages
//                .Where(i => i.VideoId == videoId && i.Type == type)
//                .ToListAsync();

//            _context.VideoImages.RemoveRange(oldImages);

//            _context.VideoImages.Add(new VideoImage
//            {
//                VideoId = videoId,
//                BlobContainer = container,
//                BlobPath = path,
//                Type = type
//            });

//            await _context.SaveChangesAsync();
//        }

//        public async Task AddSeasonAsync(int videoId, int seasonNumber)
//        {
//            _context.VideoSeasons.Add(new VideoSeason
//            {
//                VideoId = videoId,
//                NumberOfSeason = seasonNumber
//            });

//            await _context.SaveChangesAsync();
//        }

//        public async Task AddEpisodeAsync(int seasonId, AddEpisodeViewModel model)
//        {
//            _context.VideoEpisode.Add(new VideoEpisode
//            {
//                VideoSeasonId = seasonId,
//                EpisodeNumber = model.EpisodeNumber,
//                Duration = model.Duration,
//                ReleaseDate = model.ReleaseDate
//            });

//            await _context.SaveChangesAsync();
//        }

//        public async Task<VideoEpisode?> GetEpisodeByIdAsync(int episodeId)
//        {
//            return await _context.VideoEpisode
//                .Include(e => e.VideoSeason)
//                .FirstOrDefaultAsync(e => e.Id == episodeId);
//        }

//        public async Task<List<GenreAdminViewModel>> GetAllGenresAsync()
//        {
//            return await _context.Genres
//                .Select(g => new GenreAdminViewModel
//                {
//                    Id = g.Id,
//                    Code = g.Code,
//                    Translations = g.GenreTranslations
//                        .Select(gt => new GenreTranslationViewModel
//                        {
//                            LocaleCode = gt.LocaleCode,
//                            Name = gt.Name
//                        })
//                        .ToList()
//                })
//                .ToListAsync();
//        }

//        public async Task CreateGenreAsync(CreateGenreViewModel model)
//        {
//            var genre = new Genre
//            {
//                Code = model.Code
//            };

//            _context.Genres.Add(genre);
//            await _context.SaveChangesAsync();

//            foreach (var translation in model.Translations)
//            {
//                _context.GenresTranslations.Add(new GenreTranslation
//                {
//                    GenreId = genre.Id,
//                    LocaleCode = translation.LocaleCode,
//                    Name = translation.Name
//                });
//            }

//            await _context.SaveChangesAsync();
//        }

//        public async Task<List<PersonAdminViewModel>> GetPersonsPagedAsync(int page, int pageSize, string? search)
//        {
//            var query = _context.Persons.AsQueryable();

//            if (!string.IsNullOrEmpty(search))
//            {
//                query = query.Where(p => p.PersonTranslations.Any(pt => pt.Name.Contains(search)));
//            }

//            return await query
//                .OrderByDescending(p => p.Id)
//                .Skip((page - 1) * pageSize)
//                .Take(pageSize)
//                .Select(p => new PersonAdminViewModel
//                {
//                    Id = p.Id,
//                    Name = p.PersonTranslations.Select(pt => pt.Name).FirstOrDefault() ?? "Невідомо",
//                    BirthDate = p.Birthday,
//                    PhotoUrl = p.Images
//                        .Where(i => i.Type == "profile")
//                        .Select(i => "/" + i.BlobContainer + "/" + i.BlobPath)
//                        .FirstOrDefault() ?? "/images/placeholder-actor.jpg",
//                    MoviesCount = p.PersonsVideos.Count()
//                })
//                .ToListAsync();
//        }

//        public async Task<int> GetPersonsCountAsync(string? search)
//        {
//            var query = _context.Persons.AsQueryable();

//            if (!string.IsNullOrEmpty(search))
//            {
//                query = query.Where(p => p.PersonTranslations.Any(pt => pt.Name.Contains(search)));
//            }

//            return await query.CountAsync();
//        }

//        public async Task CreatePersonAsync(CreatePersonViewModel model)
//        {
//            var person = new Person
//            {
//                Birthday = model.BirthDate
//            };

//            _context.Persons.Add(person);
//            await _context.SaveChangesAsync();

//            foreach (var translation in model.Translations)
//            {
//                _context.PersonsTranslations.Add(new PersonTranslation
//                {
//                    PersonId = person.Id,
//                    LocaleCode = translation.LocaleCode,
//                    Name = translation.Name
//                });
//            }

//            await _context.SaveChangesAsync();
//        }

//        public async Task SavePersonImagePathAsync(int personId, string container, string path, string type)
//        {
//            var oldImages = await _context.PersonImages
//                .Where(i => i.PersonId == personId && i.Type == type)
//                .ToListAsync();

//            _context.PersonImages.RemoveRange(oldImages);

//            _context.PersonImages.Add(new PersonImage
//            {
//                PersonId = personId,
//                BlobContainer = container,
//                BlobPath = path,
//                Type = type
//            });

//            await _context.SaveChangesAsync();
//        }

//        public async Task<StatisticsViewModel> GetStatisticsAsync()
//        {
//            var totalViews = await _context.VideoEpisodeDailyStats.SumAsync(s => s.TotalUserViews);
//            var totalVideos = await _context.Videos.CountAsync();
//            var totalGenres = await _context.Genres.CountAsync();

//            var topGenres = await _context.Genres
//                .Select(g => new GenreStatsViewModel
//                {
//                    GenreName = g.GenreTranslations.Select(gt => gt.Name).FirstOrDefault() ?? g.Code,
//                    VideosCount = g.GenreVideos.Count()
//                })
//                .OrderByDescending(g => g.VideosCount)
//                .Take(5)
//                .ToListAsync();

//            return new StatisticsViewModel
//            {
//                TotalViews = totalViews,
//                TotalVideos = totalVideos,
//                TotalGenres = totalGenres,
//                TopGenres = topGenres
//            };
//        }

//        public async Task<List<TopVideoViewModel>> GetTopVideosByViewsAsync(int days)
//        {
//            var startDate = DateTime.UtcNow.AddDays(-days);

//            return await _context.VideoEpisodeDailyStats
//                .Where(s => s.Date >= startDate)
//                .GroupBy(s => s.VideoEpisode.VideoSeason.VideoId)
//                .Select(g => new TopVideoViewModel
//                {
//                    VideoId = g.Key,
//                    Title = g.First().VideoEpisode.VideoSeason.Video.Translations
//                        .Select(t => t.Title)
//                        .FirstOrDefault() ?? "Без назви",
//                    TotalViews = g.Sum(x => x.TotalUserViews)
//                })
//                .OrderByDescending(v => v.TotalViews)
//                .Take(10)
//                .ToListAsync();
//        }
//    }
//}
