using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;
using StreamingService.DTO.ViewModels.Account;
using StreamingService.Resources;
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
    private readonly IWebHostEnvironment _webHostEnvironment;

    public SettingsController(ProfileService profileService, SettingsService settingsService, HistoryService historyService, IWebHostEnvironment webHostEnvironment)
    {
        _profileService = profileService;
        _settingsService = settingsService; 
        _historyService = historyService;
        _settingsService = settingsService;
        _webHostEnvironment = webHostEnvironment;
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

    // ==========================================
    // РЕДАГУВАННЯ ПРОФІЛЮ
    // ==========================================

    [HttpGet("edit-profile")]
    public async Task<IActionResult> EditProfile(string returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out var userId)) return RedirectToAction("Login", "Account");

        var user = await _profileService.GetByIdAsync(userId);
        if (user == null) return NotFound();

        var model = new EditProfileViewModel
        {
            ProfileId = user.Id,
            Username = user.Username,
            CurrentAvatarUrl = user.AvatarUrl ?? "/images/default-avatar.png"
        };

        return View(model);
    }

    [HttpPost("edit-profile")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditProfile(EditProfileViewModel model, string returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        if (!ModelState.IsValid) return View(model);

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out var userId)) return RedirectToAction("Login", "Account");

        var user = await _profileService.GetByIdAsync(userId);
        if (user == null) return NotFound();

        string newAvatarPath = model.CurrentAvatarUrl;

        // Збереження файлу аватарки
        if (model.AvatarFile != null && model.AvatarFile.Length > 0)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.AvatarFile.FileName);
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "avatars");
            
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);
            
            using (var fileStream = new FileStream(Path.Combine(uploadsFolder, fileName), FileMode.Create))
            {
                await model.AvatarFile.CopyToAsync(fileStream);
            }
            newAvatarPath = "/images/avatars/" + fileName;
        }

        user.Username = model.Username;
        user.AvatarUrl = newAvatarPath;
        user.Birthday = model.Birthday;

        await _profileService.UpdateUserProfileAsync(user);

        return RedirectToAction("Profile", new { returnUrl = returnUrl });
    }

    // ==========================================
    // РЕДАГУВАННЯ ЕЛЕКТРОННОЇ ПОШТИ
    // ==========================================

    [HttpGet("edit-email")]
    public async Task<IActionResult> EditEmail(string returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out var userId)) return RedirectToAction("Login", "Account");

        var user = await _profileService.GetByIdAsync(userId);
        if (user == null) return NotFound();

        var model = new ChangeEmailViewModel
        {
            CurrentEmail = user.Email
        };

        return View(model);
    }

    [HttpPost("edit-email")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditEmail(ChangeEmailViewModel model, string returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        if (!ModelState.IsValid) return View(model);

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out var userId)) return RedirectToAction("Login", "Account");

        var user = await _profileService.GetByIdAsync(userId);
        if (user == null) return NotFound();

        var existingUser = await _profileService.GetByEmailAsync(model.NewEmail);
        if (existingUser != null && existingUser.Id != user.Id)
        {
            ModelState.AddModelError("NewEmail", "Ця адреса вже використовується іншим обліковим записом.");
            return View(model);
        }

        user.Email = model.NewEmail;
        await _profileService.UpdateUserProfileAsync(user);

        return RedirectToAction("Profile", new { returnUrl = returnUrl });
    }

    // ==========================================
    // РЕДАГУВАННЯ ПАРОЛЯ
    // ==========================================

    [HttpGet("edit-password")]
    public async Task<IActionResult> EditPassword(string returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out var userId)) return RedirectToAction("Login", "Account");

        var user = await _profileService.GetByIdAsync(userId);
        if (user == null) return NotFound();

        var model = new ChangePasswordViewModel
        {
            HasPassword = !string.IsNullOrEmpty(user.PasswordHash)
        };

        return View(model);
    }

    [HttpPost("edit-password")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditPassword(ChangePasswordViewModel model, string returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        if (!ModelState.IsValid) return View(model);

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out var userId)) return RedirectToAction("Login", "Account");

        var user = await _profileService.GetByIdAsync(userId);

        if (user == null) 
        {
            ModelState.AddModelError(string.Empty, "Користувача не знайдено.");
            return View(model);
        }

        bool hasExistingPassword = !string.IsNullOrEmpty(user.PasswordHash);

        if (hasExistingPassword)
        {
            if (string.IsNullOrEmpty(model.CurrentPassword))
            {
                ModelState.AddModelError(nameof(model.CurrentPassword), "Введіть поточний пароль");
                model.HasPassword = true;
                return View(model);
            }

            if (!PasswordHasher.VerifyPassword(model.CurrentPassword, user.PasswordHash))
            {
                ModelState.AddModelError("CurrentPassword", "Невірний поточний пароль.");
                model.HasPassword = true;
                return View(model);
            }
        }

        user.PasswordHash = PasswordHasher.HashPassword(model.NewPassword);
        await _profileService.UpdateUserProfileAsync(user);

        return RedirectToAction("Profile", new { returnUrl = returnUrl });
    }

    // ==========================================
    // РЕДАГУВАННЯ ВІДОБРАЖУВАНОГО ІМЕНІ
    // ==========================================

    [HttpGet("edit-name")]
    public async Task<IActionResult> EditName(string returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out var userId)) return RedirectToAction("Login", "Account");

        var user = await _profileService.GetByIdAsync(userId);
        if (user == null) return NotFound();

        // Розбиваємо поточне Username на Ім'я та Прізвище по пробілу
        var nameParts = user.Username?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();
        var firstName = nameParts.Length > 0 ? nameParts[0] : "";
        var lastName = nameParts.Length > 1 ? string.Join(" ", nameParts.Skip(1)) : "";

        var model = new ChangeNameViewModel
        {
            CurrentName = user.Username,
            FirstName = firstName,
            LastName = lastName
        };

        return View(model);
    }

    [HttpPost("edit-name")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditName(ChangeNameViewModel model, string returnUrl = null)
    {
        if (!ModelState.IsValid) return View(model);

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out var userId)) return RedirectToAction("Login", "Account");

        var user = await _profileService.GetByIdAsync(userId);
        if (user == null) return NotFound();

        // Склеюємо Ім'я та Прізвище назад в один рядок
        user.Username = $"{model.FirstName.Trim()} {model.LastName.Trim()}";
        await _profileService.UpdateUserProfileAsync(user);

        return RedirectToAction("Profile", new { returnUrl = returnUrl });
    }
}