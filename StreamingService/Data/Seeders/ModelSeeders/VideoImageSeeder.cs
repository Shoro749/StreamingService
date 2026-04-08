using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class VideoImageSeeder
    {
        public static async Task<List<VideoImage>?> SeedAsync(AppDbContext context, List<Video>? videos)
        {
            if (videos == null)
                return null;

            if (context.VideoImages.Any())
                return null;

            var images = new List<VideoImage>
            {
                new VideoImage
                {
                    Type = "poster",
                    BlobContainer = "images",
                    BlobPath = "https://upload.wikimedia.org/wikipedia/ru/b/b9/Intouchables.jpg",
                    Video = videos[0]
                },
                new VideoImage
                {
                    Type = "backdrop",
                    BlobContainer = "images",
                    BlobPath = "https://upload.wikimedia.org/wikipedia/ru/b/b9/Intouchables.jpg",
                    Video = videos[0]
                },
                new VideoImage
                {
                    Type = "thumbnail",
                    BlobContainer = "images",
                    BlobPath = "https://upload.wikimedia.org/wikipedia/ru/b/b9/Intouchables.jpg",
                    Video = videos[0]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://upload.wikimedia.org/wikipedia/ru/b/b9/Intouchables.jpg",
                    Video = videos[0]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://upload.wikimedia.org/wikipedia/ru/b/b9/Intouchables.jpg",
                    Video = videos[0]
                },

                new VideoImage
                {
                    Type = "poster",
                    BlobContainer = "images",
                    BlobPath = "https://cdng.europosters.eu/pod_public/1300/263740.jpg",
                    Video = videos[1]
                },
                new VideoImage
                {
                    Type = "backdrop",
                    BlobContainer = "images",
                    BlobPath = "https://cdng.europosters.eu/pod_public/1300/263740.jpg",
                    Video = videos[1]
                },
                new VideoImage
                {
                    Type = "thumbnail",
                    BlobContainer = "images",
                    BlobPath = "https://cdng.europosters.eu/pod_public/1300/263740.jpg",
                    Video = videos[1]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://cdng.europosters.eu/pod_public/1300/263740.jpg",
                    Video = videos[1]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://cdng.europosters.eu/pod_public/1300/263740.jpg",
                    Video = videos[1]
                },

                new VideoImage
                {
                    Type = "poster",
                    BlobContainer = "images",
                    BlobPath = "https://image.tmdb.org/t/p/w600_and_h900_face/je5Z7gbFTzrs3FPHINo9yGiHoVo.jpg",
                    Video = videos[2]
                },
                new VideoImage
                {
                    Type = "backdrop",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w94_and_h141_face/je5Z7gbFTzrs3FPHINo9yGiHoVo.jpg",
                    Video = videos[2]
                },
                new VideoImage
                {
                    Type = "thumbnail",
                    BlobContainer = "images",
                    BlobPath = "https://image.tmdb.org/t/p/w600_and_h900_face/je5Z7gbFTzrs3FPHINo9yGiHoVo.jpg",
                    Video = videos[2]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://image.tmdb.org/t/p/w600_and_h900_face/je5Z7gbFTzrs3FPHINo9yGiHoVo.jpg",
                    Video = videos[2]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://image.tmdb.org/t/p/w600_and_h900_face/je5Z7gbFTzrs3FPHINo9yGiHoVo.jpg",
                    Video = videos[2]
                },

                new VideoImage
                {
                    Type = "poster",
                    BlobContainer = "images",
                    BlobPath = "https://image.tmdb.org/t/p/w600_and_h900_face/ztkUQFLlC19CCMYHW9o1zWhJRNq.jpg",
                    Video = videos[3]
                },
                new VideoImage
                {
                    Type = "backdrop",
                    BlobContainer = "images",
                    BlobPath = "https://image.tmdb.org/t/p/w600_and_h900_face/ztkUQFLlC19CCMYHW9o1zWhJRNq.jpg",
                    Video = videos[3]
                },
                new VideoImage
                {
                    Type = "thumbnail",
                    BlobContainer = "images",
                    BlobPath = "https://image.tmdb.org/t/p/w600_and_h900_face/ztkUQFLlC19CCMYHW9o1zWhJRNq.jpg",
                    Video = videos[3]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://image.tmdb.org/t/p/w600_and_h900_face/ztkUQFLlC19CCMYHW9o1zWhJRNq.jpg",
                    Video = videos[3]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://image.tmdb.org/t/p/w600_and_h900_face/ztkUQFLlC19CCMYHW9o1zWhJRNq.jpg",
                    Video = videos[3]
                },

                new VideoImage
                {
                    Type = "poster",
                    BlobContainer = "images",
                    BlobPath = "https://www.themoviedb.org/t/p/w1280/9d1sCoMSGJZtghS2X9us1h9u8lW.jpg",
                    Video = videos[4]
                },
                new VideoImage
                {
                    Type = "backdrop",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/65BTgbR7w8g5h8PlNwUgRVWqPyQ.jpg",
                    Video = videos[4]
                },
                new VideoImage
                {
                    Type = "thumbnail",
                    BlobContainer = "images",
                    BlobPath = "https://www.themoviedb.org/t/p/w1280/9d1sCoMSGJZtghS2X9us1h9u8lW.jpg",
                    Video = videos[4]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/65BTgbR7w8g5h8PlNwUgRVWqPyQ.jpg",
                    Video = videos[4]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/65BTgbR7w8g5h8PlNwUgRVWqPyQ.jpg",
                    Video = videos[4]
                },

                new VideoImage
                {
                    Type = "poster",
                    BlobContainer = "images",
                    BlobPath = "https://www.themoviedb.org/t/p/w1280/qRA3DbdUfQDJPgKkC7QnuCCU717.jpg",
                    Video = videos[5]
                },
                new VideoImage
                {
                    Type = "backdrop",
                    BlobContainer = "images",
                    BlobPath = "https://www.themoviedb.org/t/p/w1280/qRA3DbdUfQDJPgKkC7QnuCCU717.jpg",
                    Video = videos[5]
                },
                new VideoImage
                {
                    Type = "thumbnail",
                    BlobContainer = "images",
                    BlobPath = "https://www.themoviedb.org/t/p/w1280/qRA3DbdUfQDJPgKkC7QnuCCU717.jpg",
                    Video = videos[5]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://www.themoviedb.org/t/p/w1280/qRA3DbdUfQDJPgKkC7QnuCCU717.jpg",
                    Video = videos[5]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://www.themoviedb.org/t/p/w1280/qRA3DbdUfQDJPgKkC7QnuCCU717.jpg",
                    Video = videos[5]
                },

                new VideoImage
                {
                    Type = "poster",
                    BlobContainer = "images",
                    BlobPath = "https://www.themoviedb.org/t/p/w1280/94orFPM5kKmMkFKJabMC7mK2Ev3.jpg",
                    Video = videos[6]
                },
                new VideoImage
                {
                    Type = "backdrop",
                    BlobContainer = "images",
                    BlobPath = "https://www.themoviedb.org/t/p/w1280/94orFPM5kKmMkFKJabMC7mK2Ev3.jpg",
                    Video = videos[6]
                },
                new VideoImage
                {
                    Type = "thumbnail",
                    BlobContainer = "images",
                    BlobPath = "https://www.themoviedb.org/t/p/w1280/94orFPM5kKmMkFKJabMC7mK2Ev3.jpg",
                    Video = videos[6]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://www.themoviedb.org/t/p/w1280/94orFPM5kKmMkFKJabMC7mK2Ev3.jpg",
                    Video = videos[6]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://www.themoviedb.org/t/p/w1280/94orFPM5kKmMkFKJabMC7mK2Ev3.jpg",
                    Video = videos[6]
                }
            };

            await context.VideoImages.AddRangeAsync(images);
            await context.SaveChangesAsync();

            return images;
        }
    }
}