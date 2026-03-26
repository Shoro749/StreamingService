using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;

namespace StreamingService.Services;

public static class MockUpcomingService
{
    private static List<VideoCardViewModel> _videos = new List<VideoCardViewModel>
    {
        new VideoCardViewModel
            {
                Id = 201, Title = "Хижак: Дикі землі",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/qRA3DbdUfQDJPgKkC7QnuCCU717.jpg",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/qRA3DbdUfQDJPgKkC7QnuCCU717.jpg",
                BackdropUrl = "https://www.themoviedb.org/t/p/w1280/qRA3DbdUfQDJPgKkC7QnuCCU717.jpg",
                VideoType = VideoType.Movie, Genres = new List<string> { "екшн", "фантастика", "трилер" },
                IsSavedForLater = true,
                ReleaseDate = new DateTime(2026, 4, 6),
                Year = "2026", Duration = "115 хв", AgeRating = "18+",
                Description = "Дія розгортається в майбутньому на віддаленій планеті, де молодий Хижак, вигнаний зі свого клану, знаходить малоймовірного союзника в особі Тії та вирушає в підступну подорож на пошуки свого остаточного супротивника.",
                TrailerUrl = "https://www.youtube.com/watch?v=1r_kvwIMqvs", TrailerDuration = "02:15",
                Actors = new List<ActorViewModel>
                {
                   new ActorViewModel { Name = "Елль Фаннінґ", Character = "Thia / Tessa", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/e8CUyxQSE99y5IOfzSLtHC0B0Ch.jpg" },
                   new ActorViewModel { Name = "Дімітріус Шустер-Колоаматанґі", Character = "Dek / Father", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/rmIZTT1AZK3C9fYhEOtGKtSrF8E.jpg" },
                   new ActorViewModel { Name = "Ravi Narayan", Character = "Bud", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/iM9dr3AjXTt7IGpRzZlQVG7hINa.jpg" },
                   new ActorViewModel { Name = "Michael Homick", Character = "Kwei (Suit)", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/a7IFYVtmNvBMJ7c20BVMc0LX6PT.jpg" },
                   new ActorViewModel { Name = "Stefan Grube", Character = "Kwei (voice)", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/7SJ13Np7xL20YJjPiUbM7PshdYA.jpg" }
                }
            },
        new VideoCardViewModel
        {
            Id = 202, Title = "Аватар: Вогонь і Попіл",
            ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/w23g9sNNDxhzjUYWTZZYqa4cNiJ.jpg",
            PosterUrl = "https://www.themoviedb.org/t/p/w1280/w23g9sNNDxhzjUYWTZZYqa4cNiJ.jpg",
            BackdropUrl = "https://www.themoviedb.org/t/p/w1280/w23g9sNNDxhzjUYWTZZYqa4cNiJ.jpg",
            VideoType = VideoType.Movie, Genres = new List<string> { "фантастика", "пригоди" },
            IsSavedForLater = true,
            ReleaseDate = new DateTime(2026, 4, 6),
            Year = "2025", Duration = "192 хв", AgeRating = "12+",
            Description = "Джейк Саллі та Нейтірі стикаються з новим, войовничим плем'ям На'ві — Людьми Попелу, які представляють набагато темнішу та жорстокішу сторону Пандори.",
            TrailerUrl = "https://www.youtube.com/watch?v=os_CcXsSHPM", TrailerDuration = "02:40",
            Actors = new List<ActorViewModel>
            {
                new ActorViewModel { Name = "Сем Вортінгтон", Character = "Джейк Саллі", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/mflBcox36s9ZPbsZPVOuhf6axaJ.jpg" },
                new ActorViewModel { Name = "Зої Салдана", Character = "Нейтірі", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/vQBwmsSOAd0JDaEcZ5p43J9xzsY.jpg" },
                new ActorViewModel { Name = "Сігурні Вівер", Character = "Кірі", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/wTSnfktNBLd6kwQxgvkqYw6vEon.jpg" },
                new ActorViewModel { Name = "Уна Чаплін", Character = "Варанг", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/tT7QQOrumeGRquaLmWNZk2DyL3Z.jpg" },
                new ActorViewModel { Name = "Стівен Ленґ", Character = "Quaritch", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/gnO5VfkDgA2fsHweD0622LUY3Hu.jpg" }
            }
        },
        new VideoCardViewModel
        {
            Id = 203, Title = "Анаконда",
            ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/9YcoOee415O7TQl3xSJ2C5taij5.jpg",
            PosterUrl = "https://www.themoviedb.org/t/p/w1280/9YcoOee415O7TQl3xSJ2C5taij5.jpg",
            VideoType = VideoType.Movie, Genres = new List<string> { "жахи", "пригоди" },
            ReleaseDate = new DateTime(2026, 4, 6),
            Actors = new List<ActorViewModel>
            {
                new ActorViewModel { Name = "Джек Блек", ImageUrl = "https://picsum.photos/seed/black/200/300" },
                new ActorViewModel { Name = "Пол Радд", ImageUrl = "https://picsum.photos/seed/rudd/200/300" },
                new ActorViewModel { Name = "Даніела Мельхіор", ImageUrl = "https://picsum.photos/seed/melchior/200/300" },
                new ActorViewModel { Name = "Кевін Гарт", ImageUrl = "https://picsum.photos/seed/hart/200/300" }
            }
        },
        new VideoCardViewModel
        {
            Id = 204, Title = "Служниця",
            ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/f95PQUGmv5sVPNiAKClFYLAF9fV.jpg",
            PosterUrl = "https://www.themoviedb.org/t/p/w1280/f95PQUGmv5sVPNiAKClFYLAF9fV.jpg",
            VideoType = VideoType.Movie, Genres = new List<string> { "драма", "трилер" },
            ReleaseDate = new DateTime(2026, 4, 13),
            Actors = new List<ActorViewModel>
            {
                new ActorViewModel { Name = "Аманда Сейфрід", ImageUrl = "https://picsum.photos/seed/seyfried/200/300" },
                new ActorViewModel { Name = "Річард Гір", ImageUrl = "https://picsum.photos/seed/gere/200/300" },
                new ActorViewModel { Name = "Клер Фой", ImageUrl = "https://picsum.photos/seed/foy/200/300" },
                new ActorViewModel { Name = "Ніколас Голт", ImageUrl = "https://picsum.photos/seed/hoult/200/300" }
            }
        },
        new VideoCardViewModel
        {
            Id = 205, Title = "Гренландія 2: Міграція",
            ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/2W6pCsQaUfVTtbwwxV8XIFVBV87.jpg",
            PosterUrl = "https://www.themoviedb.org/t/p/w1280/2W6pCsQaUfVTtbwwxV8XIFVBV87.jpg",
            BackdropUrl = "https://www.themoviedb.org/t/p/w1280/2W6pCsQaUfVTtbwwxV8XIFVBV87.jpg",
            VideoType = VideoType.Movie, Genres = new List<string> { "бойовик", "трилер" },
            IsSavedForLater = true,
            ReleaseDate = new DateTime(2026, 4, 13),
            Year = "2026", Duration = "120 хв", AgeRating = "16+",
            Description = "Після катастрофічного удару комети сім'я Герріті залишає свій бункер у Гренландії та вирушає у небезпечну подорож через спустошені землі Європи в пошуках нового дому.",
            TrailerUrl = "https://www.youtube.com/watch?v=V1LA1moMeOk", TrailerDuration = "02:05",
            Actors = new List<ActorViewModel>
            {
                new ActorViewModel { Name = "Джерард Батлер", Character = "Джон Герріті", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/i54XoxYieuff2w6MwyfwVUBvmR0.jpg" },
                new ActorViewModel { Name = "Морена Баккарін", Character = "Еллісон", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/kBSKKaOtsqIzZPhtEeHfCBmhWl9.jpg" },
                new ActorViewModel { Name = "Роман Ґріффін Девіс", Character = "Nathan Garrity", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/jEox6Bq4TlINrnp5EUjqSlDK3eP.jpg" },
                new ActorViewModel { Name = "Tommie Earl Jenkins", Character = "General Sharpe", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/kl2dzZU3p6pOjuKBi52wOnEGvEp.jpg" },
                new ActorViewModel { Name = "Ембер Роуз Рева", Character = "Dr Casey Amina", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/AjVg1UrGqm0mlbis8CVm0O56Ae2.jpg" }
            }
        },
        new VideoCardViewModel
        {
            Id = 206, Title = "28 років по тому: Храм кісток",
            ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/lgFNFYdG2v5jnaae6mtXR56GLnj.jpg",
            PosterUrl = "https://www.themoviedb.org/t/p/w1280/lgFNFYdG2v5jnaae6mtXR56GLnj.jpg",
            VideoType = VideoType.Movie, Genres = new List<string> { "жахи", "фантастика" },
            ReleaseDate = new DateTime(2026, 4, 13),
            Actors = new List<ActorViewModel>
            {
                new ActorViewModel { Name = "Аарон Тейлор-Джонсон", ImageUrl = "https://picsum.photos/seed/aaron/200/300" },
                new ActorViewModel { Name = "Рейф Файнс", ImageUrl = "https://picsum.photos/seed/fiennes/200/300" },
                new ActorViewModel { Name = "Джоді Комер", ImageUrl = "https://picsum.photos/seed/comer/200/300" },
                new ActorViewModel { Name = "Джеймі Белл", ImageUrl = "https://picsum.photos/seed/bell/200/300" }
            }
        },
        new VideoCardViewModel
        {
            Id = 207, Title = "Милосердя",
            ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/pyok1kZJCfyuFapYXzHcy7BLlQa.jpg",
            PosterUrl = "https://www.themoviedb.org/t/p/w1280/pyok1kZJCfyuFapYXzHcy7BLlQa.jpg",
            VideoType = VideoType.Movie, Genres = new List<string> { "фантастика", "трилер" },
            ReleaseDate = new DateTime(2026, 4, 20),
            Actors = new List<ActorViewModel>
            {
                new ActorViewModel { Name = "Кріс Пратт", ImageUrl = "https://picsum.photos/seed/pratt/200/300" },
                new ActorViewModel { Name = "Ребекка Фергюсон", ImageUrl = "https://picsum.photos/seed/ferguson/200/300" },
                new ActorViewModel { Name = "Аннабелль Волліс", ImageUrl = "https://picsum.photos/seed/wallis/200/300" },
                new ActorViewModel { Name = "Калі Реїс", ImageUrl = "https://picsum.photos/seed/reis/200/300" }
            }
        },
        new VideoCardViewModel
        {
            Id = 208, Title = "Команда руйнівників",
            ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/k3cvpfx0OMwgGNpaCYmidgoJmmr.jpg",
            PosterUrl = "https://www.themoviedb.org/t/p/w1280/k3cvpfx0OMwgGNpaCYmidgoJmmr.jpg",
            BackdropUrl = "https://www.themoviedb.org/t/p/w1280/k3cvpfx0OMwgGNpaCYmidgoJmmr.jpg",
            VideoType = VideoType.Movie, Genres = new List<string> { "екшн", "комедія" },
            IsSavedForLater = true,
            ReleaseDate = new DateTime(2026, 4, 20),
            Year = "2026", Duration = "110 хв", AgeRating = "16+",
            Description = "Два зведені брати — розкутий поліцейський та суворий військовий дисциплінатор — змушені об'єднати свої зусилля, щоб розслідувати вбивство їхнього спільного батька.",
            TrailerUrl = "https://www.youtube.com/watch?v=v8R0xDczERo", TrailerDuration = "01:55",
            Actors = new List<ActorViewModel>
            {
                new ActorViewModel { Name = "Джейсон Момоа", Character = "Поліцейський", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/3troAR6QbSb6nUFMDu61YCCWLKa.jpg" },
                new ActorViewModel { Name = "Дейв Батіста", Character = "Військовий", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/snk6JiXOOoRjPtHU5VMoy6qbd32.jpg" },
                new ActorViewModel { Name = "Темуера Моррісон", Character = "Батько", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/AvtSC0f9QW7fMyFFNXEWDeQyfUk.jpg" },
                new ActorViewModel { Name = "Френкі Адамс", Character = "Агентка", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/aAUHUSf0lh3OBRoaiCRL9ep8lfL.jpg" }
            }
        },
        new VideoCardViewModel
        {
            Id = 209, Title = "Проти полумʼя",
            ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/lV0MGWaMf6xMejCZlJq4Fzqg3Aw.jpg",
            PosterUrl = "https://www.themoviedb.org/t/p/w1280/lV0MGWaMf6xMejCZlJq4Fzqg3Aw.jpg",
            VideoType = VideoType.Movie, Genres = new List<string> { "драма", "історія" },
            ReleaseDate = new DateTime(2026, 4, 20),
            Actors = new List<ActorViewModel>
            {
                new ActorViewModel { Name = "Тай Шерідан", ImageUrl = "https://picsum.photos/seed/sheridan/200/300" },
                new ActorViewModel { Name = "Майкл Шеннон", ImageUrl = "https://picsum.photos/seed/shannon/200/300" },
                new ActorViewModel { Name = "Лора Дерн", ImageUrl = "https://picsum.photos/seed/dern/200/300" },
                new ActorViewModel { Name = "Бен Фостер", ImageUrl = "https://picsum.photos/seed/foster/200/300" }
            }
        },
        new VideoCardViewModel
        {
            Id = 210, Title = "Крик 7",
            ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/1bKN2QriglJRbrmECHC57Xkk5bk.jpg",
            PosterUrl = "https://www.themoviedb.org/t/p/w1280/1bKN2QriglJRbrmECHC57Xkk5bk.jpg",
            VideoType = VideoType.Movie, Genres = new List<string> { "жахи", "трилер" },
            ReleaseDate = new DateTime(2026, 4, 27),
            Actors = new List<ActorViewModel>
            {
                new ActorViewModel { Name = "Нів Кемпбелл", ImageUrl = "https://picsum.photos/seed/campbell/200/300" },
                new ActorViewModel { Name = "Патрік Демпсі", ImageUrl = "https://picsum.photos/seed/dempsey/200/300" },
                new ActorViewModel { Name = "Гейден Панеттьєр", ImageUrl = "https://picsum.photos/seed/panettiere/200/300" },
                new ActorViewModel { Name = "Джеймі Кеннеді", ImageUrl = "https://picsum.photos/seed/kennedy/200/300" }
            }
        },
        new VideoCardViewModel
        {
            Id = 211, Title = "Стрибунці",
            ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/mkONVgs5idDOb6HQVl81YaONXG0.jpg",
            PosterUrl = "https://www.themoviedb.org/t/p/w1280/mkONVgs5idDOb6HQVl81YaONXG0.jpg",
            VideoType = VideoType.AnimatedMovie, Genres = new List<string> { "анімація", "комедія" },
            ReleaseDate = new DateTime(2026, 4, 27),
            Actors = new List<ActorViewModel>
            {
                new ActorViewModel { Name = "Джон Гемм", ImageUrl = "https://picsum.photos/seed/hamm/200/300" },
                new ActorViewModel { Name = "Боббі Мойнаган", ImageUrl = "https://picsum.photos/seed/moynihan/200/300" },
                new ActorViewModel { Name = "Кіген-Майкл Кі", ImageUrl = "https://picsum.photos/seed/key/200/300" },
                new ActorViewModel { Name = "Аквафіна", ImageUrl = "https://picsum.photos/seed/awkwafina/200/300" }
            }
        },
        new VideoCardViewModel
        {
            Id = 212, Title = "Гострі картузи: Безсмертний",
            ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/94orFPM5kKmMkFKJabMC7mK2Ev3.jpg",
            PosterUrl = "https://www.themoviedb.org/t/p/w1280/94orFPM5kKmMkFKJabMC7mK2Ev3.jpg",
            BackdropUrl = "https://www.themoviedb.org/t/p/w1280/94orFPM5kKmMkFKJabMC7mK2Ev3.jpg",
            VideoType = VideoType.Movie, Genres = new List<string> { "драма", "кримінал" },
            IsSavedForLater = true,
            ReleaseDate = new DateTime(2026, 5, 4),
            Year = "2026", Duration = "135 хв", AgeRating = "18+",
            Description = "Епічне кінопродовження культового серіалу. Томмі Шелбі знову повертається у розпалі Другої світової війни для своєї останньої та найнебезпечнішої місії.",
            TrailerUrl = "https://www.youtube.com/watch?v=OStkX1HsAM4", TrailerDuration = "02:30",
            Actors = new List<ActorViewModel>
            {
                new ActorViewModel { Name = "Кілліан Мерфі", Character = "Томмі Шелбі", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/llkbyWKwpfowZ6C8peBjIV9jj99.jpg" },
                new ActorViewModel { Name = "Баррі Кеоган", Character = "Новий супротивник", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/ngoitknM6hw8fffLywyvjzy6Iti.jpg" },
                new ActorViewModel { Name = "Ребекка Фергюсон", Character = "Союзниця", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/lJloTOheuQSirSLXNA3JHsrMNfH.jpg" },
                new ActorViewModel { Name = "Тім Рот", Character = "Політик", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/qSizF2i9gz6c6DbAC5RoIq8sVqX.jpg" }
            }
        },
        new VideoCardViewModel
        {
            Id = 213, Title = "Пес 51",
            ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/olMvhbCRuhTbf6EMKxKGHi2on3L.jpg",
            PosterUrl = "https://www.themoviedb.org/t/p/w1280/olMvhbCRuhTbf6EMKxKGHi2on3L.jpg",
            VideoType = VideoType.Movie, Genres = new List<string> { "фантастика", "трилер" },
            ReleaseDate = new DateTime(2026, 5, 4),
            Actors = new List<ActorViewModel>
            {
                new ActorViewModel { Name = "Том Голланд", ImageUrl = "https://picsum.photos/seed/holland/200/300" },
                new ActorViewModel { Name = "Дейзі Рідлі", ImageUrl = "https://picsum.photos/seed/ridley/200/300" },
                new ActorViewModel { Name = "Джон Боєга", ImageUrl = "https://picsum.photos/seed/boyega/200/300" },
                new ActorViewModel { Name = "Енді Серкіс", ImageUrl = "https://picsum.photos/seed/serkis/200/300" }
            }
        }
    };
    public static List<VideoCardViewModel> GetUpcomingReleases()
    {
        return _videos;
    }

    public static bool ToggleSavedStatus(int videoId)
    {
        var video = _videos.FirstOrDefault(v => v.Id == videoId);
        if (video != null)
        {
            video.IsSavedForLater = !video.IsSavedForLater;
            return video.IsSavedForLater;
        }
        return false;
    }
}