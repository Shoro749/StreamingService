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
                    BlobPath = "https://images.kinorium.com/movie/poster/537521/h280_54725014.jpg",
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
                    BlobPath = "https://images.kinorium.com/movie/shot/537521/h280_672535.jpg?21442296802",
                    Video = videos[0]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://images.kinorium.com/movie/shot/537521/h280_48906164.jpg?21619522420",
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
                    BlobPath = "https://static0.srcdn.com/wordpress/wp-content/uploads/2017/03/pirates-caribbean-5-movie-posters.jpg",
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
                    BlobPath = "https://i0.wp.com/images1.wikia.nocookie.net/__cb20121206144931/pirates/images/8/87/Parley_AWE.jpg",
                    Video = videos[1]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://akns-images.eonline.com/eol_images/Entire_Site/2019421/rs_1024x759-190521101525-1024-Johnny-Depp-Pirates-Dead-Mans-Chest-Disney-LT-052119.jpg?fit=around%7C1024:759&output-quality=90&crop=1024:759;center,top",
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
                    BlobPath = "https://i0.wp.com/pelikulamania.com/wp-content/uploads/2015/10/the-little-prince.jpg?fit=907%2C496&ssl=1",
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
                    BlobPath = "https://m.media-amazon.com/images/M/MV5BMTQ5MjQ2NTcwOF5BMl5BanBnXkFtZTgwOTM0MDQ2NTE@._V1_QL75_UX516_.jpg",
                    Video = videos[2]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://m.media-amazon.com/images/M/MV5BMTYyNjYxMjAwMl5BMl5BanBnXkFtZTgwMDQ0MDQ2NTE@._V1_QL75_UX513_.jpg",
                    Video = videos[2]
                },

                new VideoImage
                {
                    Type = "poster",
                    BlobContainer = "images",
                    BlobPath = "https://image.tmdb.org/t/p/w500/ggFHVNu6YYI5L9pCfOacjizRGt.jpg",
                    Video = videos[3]
                },
                new VideoImage
                {
                    Type = "backdrop",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/63FA8vwSZnXkGxedrDQwni4JuZN.jpg",
                    Video = videos[3]
                },
                new VideoImage
                {
                    Type = "thumbnail",
                    BlobContainer = "images",
                    BlobPath = "https://image.tmdb.org/t/p/w200/ggFHVNu6YYI5L9pCfOacjizRGt.jpg",
                    Video = videos[3]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/tsRy63Mu5cu8etL1X7ZLyf7UP1M.jpg",
                    Video = videos[3]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/sp1RSDvoVsbvDouQx1A75ebU35e.jpg",
                    Video = videos[3]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/gc8PfyTqzqltKPW3X0cIVUGmagz.jpg",
                    Video = videos[3]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/5WKVhTcc1cVaCsXwEUtB8lHzgm4.jpg",
                    Video = videos[3]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/5TUskRDtyg2Qw1viUU6wfP8dLLL.jpg",
                    Video = videos[3]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/hDRfskJOAgqe05OXBRusu3YVnVO.jpg",
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
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/l33oR0mnvf20avWyIMxW02EtQxn.jpg",
                    Video = videos[4]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/ln2Gre4IYRhpjuGVybbtaF4CLo5.jpg",
                    Video = videos[4]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/pbrkL804c8yAv3zBZR4QPEafpAR.jpg",
                    Video = videos[4]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/5C3RriLKkIAQtQMx85JLtu4rVI2.jpg",
                    Video = videos[4]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/gg12Nnz7YETfC2Nwb6jGM5sif6X.jpg",
                    Video = videos[4]
                },
                new VideoImage
                {
                    Type = "scene",
                    BlobContainer = "images",
                    BlobPath = "https://media.themoviedb.org/t/p/w1000_and_h563_face/b08gByARHhXbHnVV4iUXCrFfp8p.jpg",
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
            };

            await context.VideoImages.AddRangeAsync(images);
            await context.SaveChangesAsync();

            return images;
        }
    }
}