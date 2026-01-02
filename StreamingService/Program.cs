using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using StreamingService.Data;
using StreamingService.Data.Seeders;
using StreamingService.Repositories;
using StreamingService.Services;

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
            builder.Services.AddScoped<VideoStatsRepository>();
            builder.Services.AddScoped<VideoStatsService>();
            builder.Services.AddAppRepositories();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
