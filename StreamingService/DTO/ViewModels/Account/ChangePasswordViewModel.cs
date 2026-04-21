using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels.Account;

public class ChangePasswordViewModel
{
    [Required(ErrorMessage = "Введіть поточний пароль")]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; }

    [Required(ErrorMessage = "Введіть новий пароль")]
    [MinLength(10, ErrorMessage = "Пароль має містити щонайменше 10 символів")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }
}
