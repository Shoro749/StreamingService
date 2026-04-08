using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class PersonVideoSeeder
    {
        public static async Task<List<PersonVideo>?> SeedAsync(AppDbContext context, List<Video>? videos, List<Person>? persons, List<PersonRole>? personRoles)
        {
            if (videos == null || persons == null || personRoles == null)
                return null;

            if (context.PersonsVideos.Any())
                return null;

            var personVideos = new List<PersonVideo>
            {
                new PersonVideo { Video = videos[0], Person = persons[2], PersonRole = personRoles[1] },
                new PersonVideo { Video = videos[0], Person = persons[3], PersonRole = personRoles[2] },
                new PersonVideo { Video = videos[0], Person = persons[0], PersonRole = personRoles[0] },
                new PersonVideo { Video = videos[0], Person = persons[1], PersonRole = personRoles[0] },

                new PersonVideo { Video = videos[1], Person = persons[6], PersonRole = personRoles[1] },
                new PersonVideo { Video = videos[1], Person = persons[7], PersonRole = personRoles[2] },
                new PersonVideo { Video = videos[1], Person = persons[4], PersonRole = personRoles[0] },
                new PersonVideo { Video = videos[1], Person = persons[5], PersonRole = personRoles[0] },

                new PersonVideo { Video = videos[2], Person = persons[2], PersonRole = personRoles[1] },
                new PersonVideo { Video = videos[2], Person = persons[3], PersonRole = personRoles[2] },
                new PersonVideo { Video = videos[2], Person = persons[0], PersonRole = personRoles[0] },
                new PersonVideo { Video = videos[2], Person = persons[1], PersonRole = personRoles[0] },

                new PersonVideo { Video = videos[3], Person = persons[6], PersonRole = personRoles[1] },
                new PersonVideo { Video = videos[3], Person = persons[7], PersonRole = personRoles[2] },
                new PersonVideo { Video = videos[3], Person = persons[8], PersonRole = personRoles[0] },
                new PersonVideo { Video = videos[3], Person = persons[9], PersonRole = personRoles[0] },

                new PersonVideo { Video = videos[4], Person = persons[2], PersonRole = personRoles[1] },
                new PersonVideo { Video = videos[4], Person = persons[7], PersonRole = personRoles[2] },
                new PersonVideo { Video = videos[4], Person = persons[1], PersonRole = personRoles[0] },
                new PersonVideo { Video = videos[4], Person = persons[0], PersonRole = personRoles[0] },

                new PersonVideo { Video = videos[5], Person = persons[6], PersonRole = personRoles[1] },
                new PersonVideo { Video = videos[5], Person = persons[3], PersonRole = personRoles[2] },
                new PersonVideo { Video = videos[5], Person = persons[4], PersonRole = personRoles[0] },
                new PersonVideo { Video = videos[5], Person = persons[5], PersonRole = personRoles[0] },

                new PersonVideo { Video = videos[6], Person = persons[6], PersonRole = personRoles[1] },
                new PersonVideo { Video = videos[6], Person = persons[7], PersonRole = personRoles[2] },
                new PersonVideo { Video = videos[6], Person = persons[8], PersonRole = personRoles[0] },
                new PersonVideo { Video = videos[6], Person = persons[9], PersonRole = personRoles[0] }
            };



            await context.PersonsVideos.AddRangeAsync(personVideos);
            await context.SaveChangesAsync();

            return personVideos;
        }
    }
}