using StreamingService.Data;
using StreamingService.DTO.ViewModel;

namespace StreamingService.Repositories
{
    public class VideoRepository
    {
        private readonly AppDbContext _context;
        public VideoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<VideoPreviewViewModel> GetVideoPreviewByIdAsync(string locale, int id)
        {
            var video = await _context.Videos.FindAsync(id);

            return new VideoPreviewViewModel
            {
                Id = id,

                Title = video.Translations
                    .Where(v => v.LocaleCode == locale)
                    .Select(vt => vt.Title)
                    .FirstOrDefault(),

                Description = video.Translations
                    .Where(v => v.LocaleCode == locale)
                    .Select(vt => vt.Description)
                    .FirstOrDefault(),

                Genres = video.GenreVideos
                    .Select(g => g.Genre.GenreTranslations
                        .Where(gt => gt.LocaleCode == locale)
                        .FirstOrDefault())
                    .Select(gt => gt.Name)
                    .ToList(),

                Rating = video.RatingSum / video.RatingCount,

                Actors = video.PersonVideos
                    .Select(p =>
                        p.Person.PersonTranslations
                        .Where(pt => pt.LocaleCode == locale)
                        .Select(pt => new PersonVideoPreviewVideoModel
                        {
                            Id = pt.Person.Id,
                            Name = pt.Name,
                            LastName = pt.LastName,
                            Patronymic = pt.Patronymic
                        })
                        .FirstOrDefault())
                    .ToList(),

                ReleaseDate = video.Seasons.First().Episodes.First().ReleaseDate
            };
        }
    }
}
