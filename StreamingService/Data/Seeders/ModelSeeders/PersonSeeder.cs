using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class PersonSeeder
    {
        public static async Task<List<Person>?> SeedAsync(AppDbContext context)
        {
            if (context.Persons.Any())
                return null;

            var persons = new List<Person>
            {
                new Person { Name = "John", LastName = "Doe", Patronymic = "", Birthday = new DateOnly(1975, 5, 12), Biography = "Famous actor." },
                new Person { Name = "Jane", LastName = "Smith", Patronymic = "", Birthday = new DateOnly(1980, 7, 23), Biography = "Acclaimed actress." },
                new Person { Name = "Alice", LastName = "Johnson", Patronymic = "", Birthday = new DateOnly(1965, 3, 5), Biography = "Screenwriter." },
                new Person { Name = "Bob", LastName = "Brown", Patronymic = "", Birthday = new DateOnly(1970, 11, 30), Biography = "Director." },
                new Person { Name = "Charlie", LastName = "Davis", Patronymic = "", Birthday = new DateOnly(1990, 2, 15), Biography = "Actor." },
                new Person { Name = "Emily", LastName = "Clark", Patronymic = "", Birthday = new DateOnly(1985, 6, 18), Biography = "Actress." },
                new Person { Name = "Frank", LastName = "Miller", Patronymic = "", Birthday = new DateOnly(1960, 9, 10), Biography = "Screenwriter." },
                new Person { Name = "Grace", LastName = "Lee", Patronymic = "", Birthday = new DateOnly(1978, 4, 22), Biography = "Director." },
                new Person { Name = "Hannah", LastName = "Wilson", Patronymic = "", Birthday = new DateOnly(1988, 12, 2), Biography = "Actress." },
                new Person { Name = "Ian", LastName = "Taylor", Patronymic = "", Birthday = new DateOnly(1982, 1, 14), Biography = "Actor." }
            };


            await context.Persons.AddRangeAsync(persons);
            await context.SaveChangesAsync();

            return persons;
        }
    }
}