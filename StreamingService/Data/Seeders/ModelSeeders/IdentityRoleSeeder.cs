using Microsoft.AspNetCore.Identity;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public class IdentityRoleSeeder
    {
        public static async Task<List<IdentityRole>?> SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = new[] { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var rolesList = roleManager.Roles.ToList().Where(obj =>
            {
                return roles.Contains(obj.Name);
            }).ToList();

            return rolesList;
        }
    }
}
