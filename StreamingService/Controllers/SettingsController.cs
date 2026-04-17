using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StreamingService.Services;
using System.Security.Claims;

namespace StreamingService.Controllers;
[Authorize]
[Route("settings")]
public class SettingsController : Controller
{
    private readonly ProfileService _profileService;
    private readonly SettingsService _settingsService;
    private readonly HistoryService _historyService;

    public SettingsController(ProfileService profileService, SettingsService settingsService, HistoryService historyService)
    {
        _profileService = profileService;
        _settingsService = settingsService; 
        _historyService = historyService;
    }
    // ==========================================
    // 1. НАЛАШТУВАННЯ КОРИСТУВАЧА
    // ==========================================

    [HttpGet]
    [HttpGet("profile")]
    public async Task<IActionResult> Profile(string returnUrl = "/Home/Index")
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        int userId = int.TryParse(userIdClaim, out var id) ? id : 0;

        var userInfo = await _profileService.GetProfileSettingsAsync(userId);

        ViewBag.ActiveTab = "profile";
        ViewBag.ReturnUrl = returnUrl;
        return View(userInfo);
    }

    [HttpGet("privacy")]
    public async Task<IActionResult> Privacy(string returnUrl = "/Home/Index")
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        int userId = int.TryParse(userIdClaim, out var id) ? id : 0;

        var settings = await _settingsService.GetUserSettingsAsync(userId) ?? new Models.UserSettings { UserProfileId = userId };

        if (settings == null && userId > 0)
        {
            settings = new Models.UserSettings { UserProfileId = userId };
            await _settingsService.CreateUserSettingsAsync(settings);
        }

        ViewBag.ActiveTab = "privacy";
        ViewBag.ReturnUrl = returnUrl;
        
        return View(settings);
    }

    [HttpPost("privacy")]
    public async Task<IActionResult> Privacy(Models.UserSettings settings, string returnUrl = "/Home/Index")
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (int.TryParse(userIdClaim, out var userId))
        {
            settings.UserProfileId = userId;

            var existingSettings = await _settingsService.GetUserSettingsAsync(userId);

            if (existingSettings == null)
            {
                await _settingsService.CreateUserSettingsAsync(settings);
            }
            else
            {
                await _settingsService.UpdateUserSettingsAsync(settings);
            }

            await _settingsService.UpdateUserSettingsAsync(settings);
        }

        return RedirectToAction(nameof(Privacy), new { returnUrl });
    }

    [HttpGet("devices")]
    public IActionResult Devices(string returnUrl = "/Home/Index")
    {
        ViewBag.ActiveTab = "devices";
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpGet("history")]
    public async Task<IActionResult> History(string returnUrl = "/Home/Index")
    {
        ViewBag.ActiveTab = "history";
        ViewBag.ReturnUrl = returnUrl;

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out var userId))
        {
            return RedirectToAction("Login", "Account");
        }

        var historyData = await _historyService.GetUserHistoryAsync(userId, "uk");

        return View(historyData);
    }

    [HttpGet("integrations")]
    public IActionResult Integrations(string returnUrl = "/Home/Index")
    {
        ViewBag.ActiveTab = "integrations";
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    // ==========================================
    // 2. ПІДПИСКА І ОПЛАТА
    // ==========================================

    [HttpGet("plans")]
    public IActionResult Plans(string returnUrl = "/Home/Index")
    {
        ViewBag.ActiveTab = "plans";
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpGet("subscriptions")]
    public IActionResult Subscriptions(string returnUrl = "/Home/Index")
    {
        ViewBag.ActiveTab = "subscriptions";
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpGet("payment-methods")]
    public IActionResult PaymentMethods(string returnUrl = "/Home/Index")
    {
        ViewBag.ActiveTab = "payment-methods";
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpGet("gift-cards")]
    public IActionResult GiftCards(string returnUrl = "/Home/Index")
    {
        ViewBag.ActiveTab = "gift-cards";
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    // ==========================================
    // 3. НАЛАШТУВАННЯ САЙТУ
    // ==========================================

    [HttpGet("notifications")]
    public IActionResult Notifications(string returnUrl = "/Home/Index")
    {
        ViewBag.ActiveTab = "notifications";
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpGet("language")]
    public IActionResult Language(string returnUrl = "/Home/Index")
    {
        ViewBag.ActiveTab = "language";
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpGet("playback")]
    public IActionResult Playback(string returnUrl = "/Home/Index")
    {
        ViewBag.ActiveTab = "playback";
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpGet("accessibility")]
    public IActionResult Accessibility(string returnUrl = "/Home/Index")
    {
        ViewBag.ActiveTab = "accessibility";
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }


}