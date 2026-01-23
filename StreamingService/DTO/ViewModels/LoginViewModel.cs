using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username or Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
