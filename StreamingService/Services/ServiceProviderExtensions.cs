
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StreamingService.Data;
using StreamingService.Models;

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
            // services.AddScoped<IRepository<>, EFRepository<>>();
            return services;
        }
    }
}
