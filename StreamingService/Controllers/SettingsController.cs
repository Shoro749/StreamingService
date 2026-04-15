using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;
using StreamingService.Extensions;
using StreamingService.Services;
using System.Collections.Generic;
using System.Security.Claims;


namespace StreamingService.Controllers;
[Authorize]
[Route("settings")]
public class SettingsController : Controller
{
    private readonly ProfileService _profileService;

    public SettingsController(ProfileService profileService)
    {
        _profileService = profileService;
    }
    // ==========================================
    // 1. НАЛАШТУВАННЯ КОРИСТУВАЧА
    // ==========================================

    [HttpGet]
    [HttpGet("profile")]
    public async Task<IActionResult> Profile(string returnUrl = "/Home/Index")
    {
        // Отримуємо ID поточного користувача
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        int userId = int.TryParse(userIdClaim, out var id) ? id : 0;

        // Отримуємо дані користувача з бази
        var userInfo = await _profileService.GetProfileSettingsAsync(userId);

        ViewBag.ActiveTab = "profile";
        ViewBag.ReturnUrl = returnUrl;
        return View(userInfo); // Передаємо дані у View
    }

    [HttpGet("privacy")]
    public async Task<IActionResult> Privacy(string returnUrl = "/Home/Index")
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        int userId = int.TryParse(userIdClaim, out var id) ? id : 0;

        var settings = await _profileService.GetUserSettingsAsync(userId) ?? new Models.UserSettings { UserProfileId = userId };

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
            await _profileService.UpdateUserSettingsAsync(settings);
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
    public IActionResult History(string returnUrl = "/Home/Index")
    {
        ViewBag.ActiveTab = "history";
        ViewBag.ReturnUrl = returnUrl;

        // Створюємо екземпляр Mock-сервісу для імітації бази даних
        var mockService = new StreamingService.Services.MockVideoService();
        var allVideos = mockService.GetAllVideos();

        // Створюємо комбіновану історію, використовуючи існуючі фільми з Mock-файлу
        var historyData = new List<StreamingService.DTO.ViewModels.HistoryItemViewModel>
    {
        new StreamingService.DTO.ViewModels.HistoryItemViewModel
        {
            Video = allVideos.First(v => v.Id == 1),
            ViewedDate = "вчора, 21:17",
            DeviceName = "MacBook Pro — Safari",
            ViewProgress = "100%"
        },
        new StreamingService.DTO.ViewModels.HistoryItemViewModel
        {
            Video = allVideos.First(v => v.Id == 5),
            ViewedDate = "10 квітня, 14:22",
            DeviceName = "Android — Lumeo App",
            ViewProgress = "100%"
        }
    };

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