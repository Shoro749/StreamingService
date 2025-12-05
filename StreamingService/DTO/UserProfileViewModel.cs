using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO
{
    public class UserProfileViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Username must be 3–64 characters.")]
        [RegularExpression("^[a-zA-Z0-9_]+$", ErrorMessage = "Username can contain letters, digits and _ only.")]
        public string Username { get; set; }
        public DateTime? Birthday { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
