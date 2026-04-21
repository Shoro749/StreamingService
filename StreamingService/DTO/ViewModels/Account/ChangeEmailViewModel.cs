using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels.Account;

public class ChangeEmailViewModel
{
    public string CurrentEmail { get; set; }

    [Required(ErrorMessage = "Введіть нову адресу електронної пошти")]
    [EmailAddress(ErrorMessage = "Невірний формат пошти")]
    [Display(Name = "Адреса електронної пошти *")]
    public string NewEmail { get; set; }
}
