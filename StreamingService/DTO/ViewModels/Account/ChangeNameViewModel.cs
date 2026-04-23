using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels.Account;

public class ChangeNameViewModel
{
    public string CurrentName { get; set; }

    [Required(ErrorMessage = "Введіть ім'я")]
    [MinLength(2, ErrorMessage = "Ім'я має містити щонайменше 2 символи")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Введіть прізвище")]
    [MinLength(2, ErrorMessage = "Прізвище має містити щонайменше 2 символи")]
    public string LastName { get; set; }
}
