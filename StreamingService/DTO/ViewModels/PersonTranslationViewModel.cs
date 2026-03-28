using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels
{
    public class PersonTranslationViewModel
    {
        [Required]
        public string LocaleCode { get; set; } = "";

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = "";
    }
}
