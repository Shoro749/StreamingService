using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels
{
    public class VideoTranslationViewModel
    {
        [Required]
        public string LocaleCode { get; set; } = "";

        [Required(ErrorMessage = "Назва обов'язкова")]
        [StringLength(200)]
        public string Title { get; set; } = "";

        [StringLength(2000)]
        public string Description { get; set; } = "";
    }
}
