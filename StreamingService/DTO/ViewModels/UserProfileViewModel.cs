using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.DTO.ViewModels
{
    public class UserProfileViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Username must be 3–64 characters.")]
        [RegularExpression("^[a-zA-Z0-9_]+$", ErrorMessage = "Username can contain letters, digits and _ only.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be 8–100 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        public DateTime? Birthday { get; set; }
        public string? AvatarUrl { get; set; }
        public string? GoogleId { get; set; }
    }
}
