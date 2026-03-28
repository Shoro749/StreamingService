using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels
{
    public class CreateVideoViewModel
    {
        [Required(ErrorMessage = "Вікове обмеження обов'язкове")]
        public string AgeRating { get; set; } = "12+";

        public string? TrailerUrl { get; set; }

        [Range(0, 600, ErrorMessage = "Тривалість від 0 до 600 секунд")]
        public int? TrailerDuration { get; set; }

        [Required(ErrorMessage = "Додайте хоча б один переклад")]
        public List<VideoTranslationViewModel> Translations { get; set; } = new()
        {
            new VideoTranslationViewModel { LocaleCode = "uk" },
            new VideoTranslationViewModel { LocaleCode = "en" }
        };

        [Required(ErrorMessage = "Виберіть хоча б один жанр")]
        public List<int> GenreIds { get; set; } = new();

        public List<GenreAdminViewModel> AvailableGenres { get; set; } = new();
    }
}
