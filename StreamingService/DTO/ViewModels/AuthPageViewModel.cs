using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels
{
    public class AuthPageViewModel
    {
        public string? BackgroundText { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть ім'я")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть прізвище")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введіть електронну пошту")] // Якщо поле пусте
        [EmailAddress(ErrorMessage = "Некоректний формат електронної пошти")] // Якщо формат неправильний
        public string Email { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль має бути не менше {2} символів")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^.*[0-9\W].*$", ErrorMessage = "Пароль має містити принаймні одну цифру або спец. символ")]
        public string Password { get; set; }

        public bool IsSubscribed { get; set; }
        public string? SubscriptionPlan { get; set; }
    }
}