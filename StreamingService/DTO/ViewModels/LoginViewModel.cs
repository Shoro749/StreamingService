using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels
{
    public class LoginViewModel
    {
        public string BackgroundText { get; set; } = "";

        [Required(ErrorMessage = "Введіть електронну пошту")]
        [EmailAddress(ErrorMessage = "Некоректний формат пошти")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
