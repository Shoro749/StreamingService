using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels
{
    public class CreateGenreViewModel
    {
        [Required]
        [StringLength(50)]
        public string Code { get; set; } = "";

        [Required]
        public List<GenreTranslationViewModel> Translations { get; set; } = new()
        {
            new GenreTranslationViewModel { LocaleCode = "uk" },
            new GenreTranslationViewModel { LocaleCode = "en" }
        };
    }
}
