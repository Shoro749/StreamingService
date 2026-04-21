using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels.Account;

public class ChangePasswordViewModel
{
    public bool HasPassword { get; set; }

    [DataType(DataType.Password)]
    public string? CurrentPassword { get; set; }

    [Required(ErrorMessage = "Введіть новий пароль")]
    [MinLength(10, ErrorMessage = "Пароль має містити щонайменше 10 символів")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }
}
