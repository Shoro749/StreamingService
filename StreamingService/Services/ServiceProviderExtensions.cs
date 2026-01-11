using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddAppDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddAppRepositories(this IServiceCollection services)
        {
            services.AddScoped<VideoRepository>();
            services.AddScoped<UserRepository>();
            
            services.AddScoped<VideoService>();
            services.AddScoped<UserService>();
            services.AddScoped<VideoPreviewService>();

            return services;
        }

    }
}
