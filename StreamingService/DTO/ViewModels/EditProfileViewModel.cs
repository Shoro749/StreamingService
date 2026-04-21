using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels;

public class EditProfileViewModel
{
    public int ProfileId { get; set; }

    [Required(ErrorMessage = "Ім'я профілю є обов'язковим")]
    [Display(Name = "Ім'я профілю")]
    public string Username { get; set; }

    [Display(Name = "Дата народження")]
    public DateTime? Birthday { get; set; }

    public GenderType? Gender { get; set; }

    public IFormFile AvatarFile { get; set; }

    public string CurrentAvatarUrl { get; set; }
}
public enum GenderType
{
    Male,
    Female,
    PreferNotToSay
}
