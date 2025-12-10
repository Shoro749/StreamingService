using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class PersonTranslationSeeder
    {
        public static async Task<List<PersonTranslation>?> SeedAsync(AppDbContext context, List<Person>? persons)
        {
            if (persons == null)
                return null;

            if (context.PersonsTranslations.Any())
                return null;

            var personTranslations = new List<PersonTranslation>
            {
                new PersonTranslation { Person = persons[0], LocaleCode = "en", IsOriginal = true, Name = "John", LastName = "Doe", Patronymic = "" },
                new PersonTranslation { Person = persons[0], LocaleCode = "uk", IsOriginal = false, Name = "Джон", LastName = "Доу", Patronymic = "" },

                new PersonTranslation { Person = persons[1], LocaleCode = "en", IsOriginal = true, Name = "Jane", LastName = "Smith", Patronymic = "" },
                new PersonTranslation { Person = persons[1], LocaleCode = "uk", IsOriginal = false, Name = "Джейн", LastName = "Сміт", Patronymic = "" },

                new PersonTranslation { Person = persons[2], LocaleCode = "en", IsOriginal = true, Name = "Alice", LastName = "Johnson", Patronymic = "" },
                new PersonTranslation { Person = persons[2], LocaleCode = "uk", IsOriginal = false, Name = "Аліса", LastName = "Джонсон", Patronymic = "" },

                new PersonTranslation { Person = persons[3], LocaleCode = "en", IsOriginal = true, Name = "Bob", LastName = "Brown", Patronymic = "" },
                new PersonTranslation { Person = persons[3], LocaleCode = "uk", IsOriginal = false, Name = "Боб", LastName = "Браун", Patronymic = "" },

                new PersonTranslation { Person = persons[4], LocaleCode = "en", IsOriginal = true, Name = "Charlie", LastName = "Davis", Patronymic = "" },
                new PersonTranslation { Person = persons[4], LocaleCode = "uk", IsOriginal = false, Name = "Чарлі", LastName = "Девіс", Patronymic = "" },

                new PersonTranslation { Person = persons[5], LocaleCode = "en", IsOriginal = true, Name = "Emily", LastName = "Clark", Patronymic = "" },
                new PersonTranslation { Person = persons[5], LocaleCode = "uk", IsOriginal = false, Name = "Емілі", LastName = "Кларк", Patronymic = "" },

                new PersonTranslation { Person = persons[6], LocaleCode = "en", IsOriginal = true, Name = "Frank", LastName = "Miller", Patronymic = "" },
                new PersonTranslation { Person = persons[6], LocaleCode = "uk", IsOriginal = false, Name = "Френк", LastName = "Міллер", Patronymic = "" },

                new PersonTranslation { Person = persons[7], LocaleCode = "en", IsOriginal = true, Name = "Grace", LastName = "Lee", Patronymic = "" },
                new PersonTranslation { Person = persons[7], LocaleCode = "uk", IsOriginal = false, Name = "Грейс", LastName = "Лі", Patronymic = "" },

                new PersonTranslation { Person = persons[8], LocaleCode = "en", IsOriginal = true, Name = "Hannah", LastName = "Wilson", Patronymic = "" },
                new PersonTranslation { Person = persons[8], LocaleCode = "uk", IsOriginal = false, Name = "Ганна", LastName = "Вілсон", Patronymic = "" },

                new PersonTranslation { Person = persons[9], LocaleCode = "en", IsOriginal = true, Name = "Ian", LastName = "Taylor", Patronymic = "" },
                new PersonTranslation { Person = persons[9], LocaleCode = "uk", IsOriginal = false, Name = "Іан", LastName = "Тейлор", Patronymic = "" }
            };



            await context.PersonsTranslations.AddRangeAsync(personTranslations);
            await context.SaveChangesAsync();

            return personTranslations;
        }
    }
}