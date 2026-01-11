using StreamingService.DTO.ViewModels;

namespace StreamingService.Services
{
    public class TopMovieSeeder
    {
        public static List<TopMovieItem> Seed()
        {
            return new List<TopMovieItem>
            {
                new TopMovieItem
                {
                    Rank = "1",
                    Title = "Дикий робот",
                    Poster = "/images/landing/posters/movie_1.png"
                },
                new TopMovieItem
                {
                    Rank = "2",
                    Title = "Відьмак",
                    Poster = "/images/landing/posters/movie_2.png"
                },
                new TopMovieItem
                {
                    Rank = "3",
                    Title = "Дім дракона",
                    Poster = "/images/landing/posters/movie_3.png"
                },
                new TopMovieItem
                {
                    Rank = "4",
                    Title = "Довга хода",
                    Poster = "/images/landing/posters/movie_4.png"
                },
                new TopMovieItem
                {
                    Rank = "5",
                    Title = "Я не залізна",
                    Poster = "/images/landing/posters/movie_5.png"
                },
                new TopMovieItem
                {
                    Rank = "6",
                    Title = "Муфаса",
                    Poster = "/images/landing/posters/movie_6.png"
                },
                new TopMovieItem
                {
                    Rank = "7",
                    Title = "Ліло і Стіч",
                    Poster = "/images/landing/posters/movie_7.png"
                },
                new TopMovieItem
                {
                    Rank = "8",
                    Title = "Потік",
                    Poster = "/images/landing/posters/movie_8.png"
                },
                new TopMovieItem
                {
                    Rank = "9",
                    Title = "Місія неможлива Фінальна розплата",
                    Poster = "/images/landing/posters/movie_9.png"
                },
                new TopMovieItem
                {
                    Rank = "10",
                    Title = "Дюна",
                    Poster = "/images/landing/posters/movie_10.png"
                }
            };
        }
    }
}
