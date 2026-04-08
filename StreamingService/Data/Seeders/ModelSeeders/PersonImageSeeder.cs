using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class PersonImageSeeder
    {
        public static async Task<List<PersonImage>?> SeedAsync(AppDbContext context, List<Person>? persons)
        {
            if (persons == null)
                return null;

            if (context.PersonImages.Any())
                return null;

            var personImages = new List<PersonImage>
            {
                new PersonImage {
                    BlobContainer = "person-images",
                    BlobPath = "https://media.themoviedb.org/t/p/w600_and_h900_face/dFxpwRpmzpVfP1zjluH68DeQhyj.jpg",
                    Person = persons[0],
                },
                new PersonImage {
                    BlobContainer = "person-images",
                    BlobPath = "https://media.themoviedb.org/t/p/w600_and_h900_face/3WdOloHpjtjL96uVOhFRRCcYSwq.jpg",
                    Person = persons[1],
                },
                new PersonImage {
                    BlobContainer = "person-images",
                    BlobPath = "https://media.themoviedb.org/t/p/w600_and_h900_face/lJloTOheuQSirSLXNA3JHsrMNfH.jpg",
                    Person = persons[2],
                },
                new PersonImage {
                    BlobContainer = "person-images",
                    BlobPath = "https://image.tmdb.org/t/p/w200/sX2etBbIkxRaCsATyw5ZpOVMPTD.jpg",
                    Person = persons[3],
                },
                new PersonImage {
                    BlobContainer = "person-images",
                    BlobPath = "https://media.themoviedb.org/t/p/w600_and_h900_face/atdAs4pFGjUQ4m2W8kJYly7N6cC.jpg",
                    Person = persons[4],
                },
                new PersonImage {
                    BlobContainer = "person-images",
                    BlobPath = "https://media.themoviedb.org/t/p/w600_and_h900_face/1Uvfh7xL4U2evkhs0M3C7BbBYFf.jpg",
                    Person = persons[5],
                },
                new PersonImage {
                    BlobContainer = "person-images",
                    BlobPath = "https://media.themoviedb.org/t/p/w600_and_h900_face/snk6JiXOOoRjPtHU5VMoy6qbd32.jpg",
                    Person = persons[6],
                },
                new PersonImage {
                    BlobContainer = "person-images",
                    BlobPath = "https://media.themoviedb.org/t/p/w180_and_h180_face/x78BtYHElirO7Iw8bL4m8CnzRDc.jpg",
                    Person = persons[7],
                },
                new PersonImage {
                    BlobContainer = "person-images",
                    BlobPath = "https://media.themoviedb.org/t/p/w180_and_h180_face/lCySuYjhXix3FzQdS4oceDDrXKI.jpg",
                    Person = persons[8],
                },
                new PersonImage {
                    BlobContainer = "person-images",
                    BlobPath = "https://image.tmdb.org/t/p/w200/tLelKoPNiyJCSEtQTz1FGv4TLGc.jpg",
                    Person = persons[9],
                },
            };

            await context.PersonImages.AddRangeAsync(personImages);
            await context.SaveChangesAsync();

            return personImages;
        }
    }
}
