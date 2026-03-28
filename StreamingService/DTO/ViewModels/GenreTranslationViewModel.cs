using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels
{
    public class GenreTranslationViewModel
    {
        [Required]
        public string LocaleCode { get; set; } = "";

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "";
    }

}
