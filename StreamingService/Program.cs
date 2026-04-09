using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.DataProtection;
using StreamingService.Data;
using StreamingService.Data.Seeders;
using StreamingService.DTO.ViewModels;
using StreamingService.Models;
using StreamingService.Repositories;
using StreamingService.Services;
using System.Security.Claims;

namespace StreamingService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAppDbContext(builder.Configuration);
            builder.Services.AddScoped<VideoRepository>();
            builder.Services.AddScoped<VideoService>();
            builder.Services.AddScoped<MoviesRepository>();
            builder.Services.AddScoped<MoviesService>();
            builder.Services.AddScoped<FavoritesRepository>();
            builder.Services.AddScoped<FavoritesService>();

            // TODO для бекенду: Тимчасово закоментував старі сервіси бази даних і підключив Mock-сервіс 
            // через інтерфейси для тестування UI (робота з каталогом, улюбленим, сторінкою "Незабаром").
            // Коли база буде готова, просто розкоментуйте свої сервіси та прив'яжіть їх до інтерфейсів.
            //builder.Services.AddSingleton<MockVideoService>();
            //builder.Services.AddSingleton<IMoviesService>(provider => provider.GetRequiredService<MockVideoService>());
            //builder.Services.AddSingleton<IFavoritesService>(provider => provider.GetRequiredService<MockVideoService>());

            builder.Services.AddScoped<ProfileRepository>();
            builder.Services.AddScoped<ProfileService>();
            builder.Services.AddScoped<PricingService>();
            builder.Services.AddScoped<VideoStatsService>();
            builder.Services.AddScoped<VideoStatsRepository>();
            builder.Services.AddScoped<HistoryRepository>();
            builder.Services.AddScoped<HistoryService>();
            builder.Services.AddScoped<SubscriptionService>();
            builder.Services.AddScoped<SubscriptionRepository>();
            builder.Services.AddScoped<VideoDetailsRepository>();
            builder.Services.AddScoped<VideoDetailsService>();
            builder.Services.AddAppRepositories();

            builder.Services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "keys")))
                .SetApplicationName("StreamingService");

            builder.Services.AddDistributedMemoryCache(); // Для збереження сесій у пам'яті
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Час життя сесії
                options.Cookie.HttpOnly = true; // Захист від XSS
                options.Cookie.IsEssential = true; // Обов'язковий cookie
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Profile/Logout";
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            })
            .AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
                //options.CallbackPath = "/Profile/GoogleCallback";
                options.CallbackPath = "/signin-google";
                options.SaveTokens = true;

                options.CorrelationCookie.SameSite = SameSiteMode.None;
                options.CorrelationCookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

                options.Events.OnCreatingTicket = async context =>
                {
                    try
                    {
                        var profileService = context.HttpContext.RequestServices.GetRequiredService<ProfileService>();

                        var googleId = context.Identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        var email = context.Identity.FindFirst(ClaimTypes.Email)?.Value;
                        var name = context.Identity.FindFirst(ClaimTypes.Name)?.Value;
                        var picture = context.User.GetProperty("picture").GetString();

                        var success = await profileService.HandleGoogleAuthAsync(googleId, email, name, picture);

                        if (!success)
                        {
                            context.Fail("Не вдалося створити або оновити користувача");
                            return;
                        }

                        var user = await profileService.GetByGoogleIdAsync(googleId);
                        if (user != null)
                        {
                            var identity = (ClaimsIdentity)context.Principal.Identity;

                            var existingClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
                            if (existingClaim != null)
                            {
                                identity.RemoveClaim(existingClaim);
                            }

                            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                            identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));

                            if (!string.IsNullOrEmpty(picture))
                            {
                                identity.AddClaim(new Claim("avatar_url", picture));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Google Auth Error: {ex.Message}");
                        context.Fail(ex);
                    }
                };
            });

            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                //var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserProfile>>();
                //var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    await DbSeeder.SeedAllAsync(context);//, userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
                    logger?.LogError(ex, "Database seeding failed");

                    Console.WriteLine("Database seeding failed:");
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
