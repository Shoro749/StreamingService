using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
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
            builder.Services.AddScoped<MoviesRepository>();
            builder.Services.AddScoped<MoviesService>();
            builder.Services.AddScoped<FavoritesRepository>();
            builder.Services.AddScoped<FavoritesService>();
            builder.Services.AddScoped<ProfileRepository>();
            builder.Services.AddScoped<ProfileService>();
            builder.Services.AddScoped<PricingService>();
            builder.Services.AddScoped<VideoStatsService>();
            builder.Services.AddScoped<VideoStatsRepository>();
            builder.Services.AddScoped<HistoryRepository>();
            builder.Services.AddScoped<HistoryService>();
            builder.Services.AddScoped<SubscriptionService>();
            builder.Services.AddScoped<SubscriptionRepository>();
            builder.Services.AddAppRepositories();

            builder.Services.AddDistributedMemoryCache(); // Для збереження сесій у пам'яті
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Час життя сесії
                options.Cookie.HttpOnly = true; // Захист від XSS
                options.Cookie.IsEssential = true; // Обов'язковий cookie
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
                options.CallbackPath = "/Profile/GoogleCallback";

                options.Events.OnCreatingTicket = async context =>
                {
                    var profileService = context.HttpContext.RequestServices.GetRequiredService<ProfileService>();

                    var googleId = context.Identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    var email = context.Identity.FindFirst(ClaimTypes.Email)?.Value;
                    var name = context.Identity.FindFirst(ClaimTypes.Name)?.Value;
                    var picture = context.User.GetProperty("picture").GetString();

                    await profileService.HandleGoogleAuthAsync(googleId, email, name, picture);
                };
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                //var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserProfile>>();
                //var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await DbSeeder.SeedAllAsync(context);//, userManager, roleManager);
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
