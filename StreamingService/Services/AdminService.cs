//using StreamingService.Repositories;

//namespace StreamingService.Services
//{
//    public class AdminService
//    {
//        private readonly AdminRepository _repository;
//        private readonly IWebHostEnvironment _environment;

//        public AdminService(AdminRepository repository, IWebHostEnvironment environment)
//        {
//            _repository = repository;
//            _environment = environment;
//        }

//        public async Task<DashboardStatsViewModel> GetDashboardStatsAsync()
//        {
//            return await _repository.GetDashboardStatsAsync();
//        }

//        public async Task<VideosPageViewModel> GetVideosPagedAsync(int page, int pageSize, string? search, int? genreId)
//        {
//            var videos = await _repository.GetVideosPagedAsync(page, pageSize, search, genreId);
//            var totalCount = await _repository.GetVideosCountAsync(search, genreId);

//            return new VideosPageViewModel
//            {
//                Videos = videos,
//                CurrentPage = page,
//                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
//                Search = search,
//                GenreId = genreId
//            };
//        }

//        public async Task<CreateVideoViewModel> GetVideoCreateModelAsync()
//        {
//            var genres = await _repository.GetAllGenresAsync();

//            return new CreateVideoViewModel
//            {
//                AvailableGenres = genres
//            };
//        }

//        public async Task<OperationResult> CreateVideoAsync(CreateVideoViewModel model)
//        {
//            try
//            {
//                var videoId = await _repository.CreateVideoAsync(model);
//                return OperationResult.Success(videoId);
//            }
//            catch (Exception ex)
//            {
//                return OperationResult.Failure(ex.Message);
//            }
//        }

//        public async Task<EditVideoViewModel?> GetVideoEditModelAsync(int id)
//        {
//            return await _repository.GetVideoEditModelAsync(id);
//        }

//        public async Task<OperationResult> UpdateVideoAsync(int id, EditVideoViewModel model)
//        {
//            try
//            {
//                await _repository.UpdateVideoAsync(id, model);
//                return OperationResult.Success();
//            }
//            catch (Exception ex)
//            {
//                return OperationResult.Failure(ex.Message);
//            }
//        }

//        public async Task<OperationResult> DeleteVideoAsync(int id)
//        {
//            try
//            {
//                await _repository.DeleteVideoAsync(id);
//                return OperationResult.Success();
//            }
//            catch (Exception ex)
//            {
//                return OperationResult.Failure(ex.Message);
//            }
//        }

//        public async Task<UploadResult> UploadPosterAsync(int videoId, IFormFile file)
//        {
//            try
//            {
//                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
//                var extension = Path.GetExtension(file.FileName).ToLower();

//                if (!allowedExtensions.Contains(extension))
//                {
//                    return UploadResult.Failure("Дозволені тільки зображення (jpg, png, webp)");
//                }

//                if (file.Length > 5 * 1024 * 1024)
//                {
//                    return UploadResult.Failure("Файл занадто великий (макс 5MB)");
//                }

//                var uploadsPath = Path.Combine(_environment.WebRootPath, "images", "posters");
//                Directory.CreateDirectory(uploadsPath);

//                var fileName = $"video_{videoId}_poster_{Guid.NewGuid()}{extension}";
//                var filePath = Path.Combine(uploadsPath, fileName);

//                using (var stream = new FileStream(filePath, FileMode.Create))
//                {
//                    await file.CopyToAsync(stream);
//                }

//                var relativePath = $"images/posters/{fileName}";
//                await _repository.SaveImagePathAsync(videoId, "images", $"posters/{fileName}", "poster");

//                return UploadResult.Success(relativePath);
//            }
//            catch (Exception ex)
//            {
//                return UploadResult.Failure(ex.Message);
//            }
//        }

//        public async Task<UploadResult> UploadVideoFileAsync(int episodeId, IFormFile file)
//        {
//            try
//            {
//                var allowedExtensions = new[] { ".mp4", ".mkv", ".avi" };
//                var extension = Path.GetExtension(file.FileName).ToLower();

//                if (!allowedExtensions.Contains(extension))
//                {
//                    return UploadResult.Failure("Дозволені тільки відео файли (mp4, mkv, avi)");
//                }

//                var episode = await _repository.GetEpisodeByIdAsync(episodeId);
//                if (episode == null)
//                {
//                    return UploadResult.Failure("Епізод не знайдено");
//                }

//                var uploadsPath = Path.Combine(_environment.WebRootPath, "videos");
//                Directory.CreateDirectory(uploadsPath);

//                var fileName = $"video_{episode.VideoSeason.VideoId}_s{episode.VideoSeason.NumberOfSeason}_e{episode.EpisodeNumber}.mp4";
//                var filePath = Path.Combine(uploadsPath, fileName);

//                using (var stream = new FileStream(filePath, FileMode.Create))
//                {
//                    await file.CopyToAsync(stream);
//                }

//                return UploadResult.Success($"videos/{fileName}");
//            }
//            catch (Exception ex)
//            {
//                return UploadResult.Failure(ex.Message);
//            }
//        }

//        public async Task<OperationResult> AddSeasonAsync(int videoId, int seasonNumber)
//        {
//            try
//            {
//                await _repository.AddSeasonAsync(videoId, seasonNumber);
//                return OperationResult.Success();
//            }
//            catch (Exception ex)
//            {
//                return OperationResult.Failure(ex.Message);
//            }
//        }

//        public async Task<OperationResult> AddEpisodeAsync(int seasonId, AddEpisodeViewModel model)
//        {
//            try
//            {
//                await _repository.AddEpisodeAsync(seasonId, model);
//                return OperationResult.Success();
//            }
//            catch (Exception ex)
//            {
//                return OperationResult.Failure(ex.Message);
//            }
//        }

//        public async Task<List<GenreAdminViewModel>> GetAllGenresAsync()
//        {
//            return await _repository.GetAllGenresAsync();
//        }

//        public async Task<OperationResult> CreateGenreAsync(CreateGenreViewModel model)
//        {
//            try
//            {
//                await _repository.CreateGenreAsync(model);
//                return OperationResult.Success();
//            }
//            catch (Exception ex)
//            {
//                return OperationResult.Failure(ex.Message);
//            }
//        }

//        public async Task<PersonsPageViewModel> GetPersonsPagedAsync(int page, int pageSize, string? search)
//        {
//            var persons = await _repository.GetPersonsPagedAsync(page, pageSize, search);
//            var totalCount = await _repository.GetPersonsCountAsync(search);

//            return new PersonsPageViewModel
//            {
//                Persons = persons,
//                CurrentPage = page,
//                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
//                Search = search
//            };
//        }

//        public async Task<OperationResult> CreatePersonAsync(CreatePersonViewModel model)
//        {
//            try
//            {
//                await _repository.CreatePersonAsync(model);
//                return OperationResult.Success();
//            }
//            catch (Exception ex)
//            {
//                return OperationResult.Failure(ex.Message);
//            }
//        }

//        public async Task<UploadResult> UploadPersonPhotoAsync(int personId, IFormFile file)
//        {
//            try
//            {
//                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
//                var extension = Path.GetExtension(file.FileName).ToLower();

//                if (!allowedExtensions.Contains(extension))
//                {
//                    return UploadResult.Failure("Дозволені тільки зображення");
//                }

//                var uploadsPath = Path.Combine(_environment.WebRootPath, "images", "actors");
//                Directory.CreateDirectory(uploadsPath);

//                var fileName = $"person_{personId}_{Guid.NewGuid()}{extension}";
//                var filePath = Path.Combine(uploadsPath, fileName);

//                using (var stream = new FileStream(filePath, FileMode.Create))
//                {
//                    await file.CopyToAsync(stream);
//                }

//                var relativePath = $"images/actors/{fileName}";
//                await _repository.SavePersonImagePathAsync(personId, "images", $"actors/{fileName}", "profile");

//                return UploadResult.Success(relativePath);
//            }
//            catch (Exception ex)
//            {
//                return UploadResult.Failure(ex.Message);
//            }
//        }

//        public async Task<StatisticsViewModel> GetStatisticsAsync()
//        {
//            return await _repository.GetStatisticsAsync();
//        }

//        public async Task<List<TopVideoViewModel>> GetTopVideosByViewsAsync(int days)
//        {
//            return await _repository.GetTopVideosByViewsAsync(days);
//        }
//    }

//    public class OperationResult
//    {
//        public bool Success { get; set; }
//        public string? ErrorMessage { get; set; }
//        public int? VideoId { get; set; }

//        public static OperationResult Success(int? videoId = null) =>
//            new OperationResult { Success = true, VideoId = videoId };

//        public static OperationResult Failure(string error) =>
//            new OperationResult { Success = false, ErrorMessage = error };
//    }

//    public class UploadResult
//    {
//        public bool Success { get; set; }
//        public string? FilePath { get; set; }
//        public string? ErrorMessage { get; set; }

//        public static UploadResult Success(string path) =>
//            new UploadResult { Success = true, FilePath = path };

//        public static UploadResult Failure(string error) =>
//            new UploadResult { Success = false, ErrorMessage = error };
//    }
//}
