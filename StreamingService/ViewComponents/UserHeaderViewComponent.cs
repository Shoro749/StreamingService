using Microsoft.AspNetCore.Mvc;
using StreamingService.Services;
using System.Security.Claims;

namespace StreamingService.ViewComponents
{
    public class UserHeaderViewComponent : ViewComponent
    {
        private readonly ProfileService _profileService;

        public UserHeaderViewComponent(ProfileService userProfileService)
        {
            _profileService = userProfileService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return View("Default");
            }

            var userIdClaim = (HttpContext.User as ClaimsPrincipal)?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
            {
                return View("Default");
            }

            var userInfo = await _profileService.GetUserHeaderInfoAsync(userId);

            return View("Default", userInfo);
        }
    }
}
