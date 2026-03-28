using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels
{
    public class CreatePersonViewModel
    {
        public DateOnly? BirthDate { get; set; }

        [Required]
        public List<PersonTranslationViewModel> Translations { get; set; } = new()
        {
            new PersonTranslationViewModel { LocaleCode = "uk" },
            new PersonTranslationViewModel { LocaleCode = "en" }
        };
    }
}
