using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class PersonRoleSeeder
    {
        public static async Task<List<PersonRole>?> SeedAsync(AppDbContext context)
        {
            if (context.PersonRoles.Any())
                return null;

            var personRoles = new List<PersonRole>
            {
                new PersonRole {  Code = "actor" },
                new PersonRole { Code = "screenwriter" },
                new PersonRole { Code = "director" }
            };


            await context.PersonRoles.AddRangeAsync(personRoles);
            await context.SaveChangesAsync();

            return personRoles;
        }
    }
}