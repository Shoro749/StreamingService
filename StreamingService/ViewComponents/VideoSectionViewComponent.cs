using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;

namespace StreamingService.ViewComponents;

public class VideoSectionViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(string title, string sectionId, string linkUrl)
    {        

        var videos = new List<VideoCardViewModel>
        {
            // 1. Дюна: Частина друга (Фільм)
            new VideoCardViewModel
            {
                Id = 1,
                Title = "Дюна: Частина друга",
                PosterUrl = "https://image.tmdb.org/t/p/w500/1pdfLvkbY9ohJlCjQH2CZjjYVvJ.jpg",
                BackdropUrl = "https://image.tmdb.org/t/p/original/xOMo8BRK7PfcJv9JCnx7s5hj0PX.jpg",
                ThumbnailUrl = "https://image.tmdb.org/t/p/w200/1pdfLvkbY9ohJlCjQH2CZjjYVvJ.jpg",
                Rating = 8.3,
                Year = "2024",
                Description = "Пол Атрід об'єднується з Чані та фрименами, щоб помститися змовникам, які знищили його сім'ю. Перед ним стоїть вибір між коханням усього життя та запобіганням жахливому майбутньому.",
                Duration = "166 хв",
                AgeRating = "12+",
                TrailerUrl = "https://www.youtube.com/watch?v=U2QpYjThFVU",
                TrailerDuration = "02:30",
                Genres = new List<string> { "Фантастика", "Пригоди", "Екшн" },
                IsFavorite = true,
                VideoType = VideoType.Movie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel
                    {
                        Name = "Тімоті Шаламе",
                        Character = "Пол Атрід",
                        ImageUrl = "https://media.themoviedb.org/t/p/w600_and_h900_face/dFxpwRpmzpVfP1zjluH68DeQhyj.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Зендея",
                        Character = "Чані",
                        ImageUrl = "https://media.themoviedb.org/t/p/w600_and_h900_face/3WdOloHpjtjL96uVOhFRRCcYSwq.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Ребекка Фергюсон",
                        Character = "Леді Джессіка",
                        ImageUrl = "https://media.themoviedb.org/t/p/w600_and_h900_face/lJloTOheuQSirSLXNA3JHsrMNfH.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Джош Бролін",
                        Character = "Гурні Голлек",
                        ImageUrl = "https://image.tmdb.org/t/p/w200/sX2etBbIkxRaCsATyw5ZpOVMPTD.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Остін Батлер",
                        Character = "Фейд-Раута Гарконнен",
                        ImageUrl = "https://media.themoviedb.org/t/p/w600_and_h900_face/atdAs4pFGjUQ4m2W8kJYly7N6cC.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Флоренс П'ю",
                        Character = "Принцеса Ірулан",
                        ImageUrl = "https://media.themoviedb.org/t/p/w600_and_h900_face/1Uvfh7xL4U2evkhs0M3C7BbBYFf.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Дейв Батіста",
                        Character = "Глоссу Раббан",
                        ImageUrl = "https://media.themoviedb.org/t/p/w600_and_h900_face/snk6JiXOOoRjPtHU5VMoy6qbd32.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Стеллан Скарсгард",
                        Character = "Барон Гарконнен",
                        ImageUrl = "https://media.themoviedb.org/t/p/w180_and_h180_face/x78BtYHElirO7Iw8bL4m8CnzRDc.jpg"
                    }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/ylkdrn23p3gQcHx7ukIfuy2CkTE.jpg", SceneName = "Пол Атрід" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/lDrlJzuLdg2bKcvek4ZpmN3Lo47.jpg", SceneName = "Преподобна Мати" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/liUVvHJclyEWgeedUD3ITJE0zrg.jpg", SceneName = "Дуель" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/xbNjzR91rtvwTV3hp2N4AWgb8Qp.jpg", SceneName = "Муаддіб" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/sgvNKJ1opNXZuGCBiKNeeuanECU.jpg", SceneName = "Пустеля" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/aUPWBGuNUDGKwHRqlojhd3Gk6Ic.jpg", SceneName = "Фрімени" }
                }
            },

            // 2. Інтерстеллар (Фільм - високий рейтинг)
            new VideoCardViewModel
            {
                Id = 2,
                Title = "Інтерстеллар",
                PosterUrl = "https://upload.wikimedia.org/wikipedia/en/b/bc/Interstellar_film_poster.jpg",
                BackdropUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/02/Artist%27s_concept_of_a_black_hole_with_an_accretion_disk.jpg/1280px-Artist%27s_concept_of_a_black_hole_with_an_accretion_disk.jpg",
                ThumbnailUrl = "https://upload.wikimedia.org/wikipedia/en/b/bc/Interstellar_film_poster.jpg",
                Rating = 8.7,
                Year = "2014",
                Description = "Коли посуха приводить людство до продовольчої кризи, колектив дослідників і вчених вирушає крізь червоточину в подорож, щоб знайти планету з відповідними для людства умовами.",
                Duration = "169 хв",
                AgeRating = "12+",
                TrailerUrl = "https://www.youtube.com/watch?v=zSWdZVtXT7E",
                TrailerDuration = "02:20",
                Genres = new List<string> { "Фантастика", "Драма", "Пригоди" },
                IsFavorite = false,
                VideoType = VideoType.Movie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel
                    {
                        Name = "Метью Макконахі",
                        Character = "Купер",
                        ImageUrl = "https://media.themoviedb.org/t/p/w180_and_h180_face/lCySuYjhXix3FzQdS4oceDDrXKI.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Енн Гетевей",
                        Character = "Амелія Бренд",
                        ImageUrl = "https://image.tmdb.org/t/p/w200/tLelKoPNiyJCSEtQTz1FGv4TLGc.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Джессіка Честейн",
                        Character = "Мерф (доросла)",
                        ImageUrl = "https://media.themoviedb.org/t/p/w180_and_h180_face/bXFXSlfCzoE5Py7KBP9P0Y0Ot1v.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Маккензі Фой",
                        Character = "Мерф (дитина)",
                        ImageUrl = "https://media.themoviedb.org/t/p/w180_and_h180_face/wzH60SrqWp2XMkBfLgdBhx5EJ82.jpgg"
                    },
                    new ActorViewModel
                    {
                        Name = "Майкл Кейн",
                        Character = "Професор Бренд",
                        ImageUrl = "https://media.themoviedb.org/t/p/w180_and_h180_face/bVZRMlpjTAO2pJK6v90buFgVbSW.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Метт Деймон",
                        Character = "Доктор Манн",
                        ImageUrl = "https://media.themoviedb.org/t/p/w180_and_h180_face/4KAxONjmVq7qcItdXo38SYtnpul.jpg"
                    }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/l33oR0mnvf20avWyIMxW02EtQxn.jpg", SceneName = "Сцена 1" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/ln2Gre4IYRhpjuGVybbtaF4CLo5.jpg", SceneName = "Сцена 2" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/pbrkL804c8yAv3zBZR4QPEafpAR.jpg", SceneName = "Сцена 3" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/5C3RriLKkIAQtQMx85JLtu4rVI2.jpg", SceneName = "Сцена 4" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/gg12Nnz7YETfC2Nwb6jGM5sif6X.jpg", SceneName = "Сцена 5" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/b08gByARHhXbHnVV4iUXCrFfp8p.jpg", SceneName = "Сцена 6" }
                }
            },

            // 3. Пуститися берега (Серіал)
            new VideoCardViewModel
            {
                Id = 3,
                Title = "Пуститися берега",
                PosterUrl = "https://image.tmdb.org/t/p/w500/ggFHVNu6YYI5L9pCfOacjizRGt.jpg",
                BackdropUrl = "https://image.tmdb.org/t/p/original/tsRy63Mu5CU8etTIGBI77atUs5s.jpg",
                ThumbnailUrl = "https://image.tmdb.org/t/p/w200/ggFHVNu6YYI5L9pCfOacjizRGt.jpg",
                Rating = 9.5,
                Year = "2008",
                Description = "Вчитель хімії дізнається, що хворий на рак. Щоб забезпечити сім'ю, він починає варити метамфетамін разом зі своїм колишнім учнем.",
                Duration = "5 сезонів",
                AgeRating = "18+",
                TrailerUrl = "https://www.youtube.com/watch?v=HhesaQXLuRY",
                TrailerDuration = "01:45",
                Genres = new List<string> { "Кримінал", "Драма", "Триллер" },
                IsFavorite = true,
                VideoType = VideoType.Series,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel
                    {
                        Name = "Браян Кренстон",
                        Character = "Волтер Вайт",
                        ImageUrl = "https://image.tmdb.org/t/p/w200/7Jahy5LZX2Fo8fGJltMreAI49hC.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Аарон Пол",
                        Character = "Джессі Пінкман",
                        ImageUrl = "https://media.themoviedb.org/t/p/w180_and_h180_face/8Ac9uuoYwZoYVAIJfRLzzLsGGJn.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Анна Ґанн",
                        Character = "Скайлер Вайт",
                        ImageUrl = "https://media.themoviedb.org/t/p/w600_and_h900_face/adppyeu1a4REN3khtgmXusrapFi.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Дін Норріс",
                        Character = "Хенк Шрейдер",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/mKRrEbsxAX3ro700HsViFArRM7l.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Бетсі Брандт",
                        Character = "Марі Шрейдер",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/xAnuzyjdMbQq9L1c4JNwXL52Wm4.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Боб Оденкерк",
                        Character = "Сол Гудман",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/rF0Lb6SBhGSTvjRffmlKRSeI3jE.jpg"
                    }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/tsRy63Mu5cu8etL1X7ZLyf7UP1M.jpg", SceneName = "Сцена 1" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/sp1RSDvoVsbvDouQx1A75ebU35e.jpg", SceneName = "Сцена 2" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/gc8PfyTqzqltKPW3X0cIVUGmagz.jpg", SceneName = "Сцена 3" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/5WKVhTcc1cVaCsXwEUtB8lHzgm4.jpg", SceneName = "Сцена 4" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/5TUskRDtyg2Qw1viUU6wfP8dLLL.jpg", SceneName = "Сцена 5" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/hDRfskJOAgqe05OXBRusu3YVnVO.jpg", SceneName = "Сцена 6" }
                }
            },

            // 4. Людина-павук: Крізь Всесвіт (Мультфільм)
            new VideoCardViewModel
            {
                Id = 4,
                Title = "Людина-павук: Крізь Всесвіт",
                PosterUrl = "https://image.tmdb.org/t/p/w500/8Vt6mWEReuy4Of61Lnj5Xj704m8.jpg",
                BackdropUrl = "https://image.tmdb.org/t/p/original/4HodYYKEIsGOdinkGi2Ucz6X9i0.jpg",
                ThumbnailUrl = "https://image.tmdb.org/t/p/w200/8Vt6mWEReuy4Of61Lnj5Xj704m8.jpg",
                Rating = 8.4,
                Year = "2023",
                Description = "Майлз Моралес повертається для наступної глави оскароносної саги про Павуків. Він потрапляє в мультивсесвіт, де зустрічає команду Людей-павуків, які захищають саме його існування.",
                Duration = "140 хв",
                AgeRating = "PG",
                TrailerUrl = "https://www.youtube.com/watch?v=cqGjhVJWtEg",
                TrailerDuration = "02:15",
                Genres = new List<string> { "Анімація", "Екшн", "Пригоди" },
                IsFavorite = true,
                VideoType = VideoType.AnimatedMovie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel
                    {
                        Name = "Шамейк Мур",
                        Character = "Майлз Моралес",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/ovUKfVOwJ7CadEHaG3NDsfA5xRq.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Гейлі Стайнфелд",
                        Character = "Ґвен Стейсі",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/jiClUr3gaySWAyfXAHiCgmmtvij.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Оскар Айзек",
                        Character = "Мігель О'Гара",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/dW5U5yrIIPmMjRThR9KT2xH6nTz.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Джейк Джонсон",
                        Character = "Пітер Б. Паркер",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/3UNfW2qZgRkW81neNVfQvaRC92K.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Ісса Рей",
                        Character = "Джессіка Дрю",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/uFjimuDgBv8kckApr19t8DykxPH.jpg"
                    }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/kVd3a9YeLGkoeR50jGEXM6EqseS.jpg", SceneName = "Сцена 1" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/bpvjzk0QXbJPV4wVwrHuYiq1TbP.jpg", SceneName = "Сцена 2" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/9wsyNsux778zw0cp8p6sWqlvEcQ.jpg", SceneName = "Сцена 3" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/kZoU1R6C0UpTtXo7P0ni4ghTFC2.jpg", SceneName = "Сцена 4" }
                }
            },

            // 5. Оппенгеймер (Фільм - історичний)
            new VideoCardViewModel
            {
                Id = 5,
                Title = "Оппенгеймер",
                PosterUrl = "https://image.tmdb.org/t/p/w500/8Gxv8gSFCU0XGDykEGv7zR1n2ua.jpg",
                BackdropUrl = "https://image.tmdb.org/t/p/original/fm6KqXpk3M2HVveHwCrBSSBaB0V.jpg",
                ThumbnailUrl = "https://image.tmdb.org/t/p/w200/8Gxv8gSFCU0XGDykEGv7zR1n2ua.jpg",
                Rating = 8.1,
                Year = "2023",
                Description = "Історія життя фізика-теоретика Роберта Оппенгеймера, директора Лос-Аламоської лабораторії під час Манхеттенського проекту, і його внесок у створення атомної бомби.",
                Duration = "180 хв",
                AgeRating = "16+",
                TrailerUrl = "https://www.youtube.com/watch?v=uYPbbksJxIg",
                TrailerDuration = "03:00",
                Genres = new List<string> { "Біографія", "Драма", "Історія" },
                IsFavorite = false,
                VideoType = VideoType.Movie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel
                    {
                        Name = "Кілліан Мерфі",
                        Character = "Роберт Оппенгеймер",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/llkbyWKwpfowZ6C8peBjIV9jj99.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Емілі Блант",
                        Character = "Кітті Оппенгеймер",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/5nCSG5TL1bP1geD8aaBfaLnLLCD.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Метт Деймон",
                        Character = "Леслі Гровс",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/4KAxONjmVq7qcItdXo38SYtnpul.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Роберт Дауні молодший",
                        Character = "Льюїс Штраус",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/5qHNjhtjMD4YWH3UP0rm4tKwxCL.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Флоренс П'ю",
                        Character = "Джин Тетлок",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/1Uvfh7xL4U2evkhs0M3C7BbBYFf.jpg"
                    }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/ycnO0cjsAROSGJKuMODgRtWsHQw.jpg", SceneName = "Сцена 1" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/fm6KqXpk3M2HVveHwCrBSSBaO0V.jpg", SceneName = "Сцена 2" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/kMa1TSDj76zTSleXE7xsuZ4s3i0.jpg", SceneName = "Сцена 3" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/zUObcYmP3F86mq61oNbtZz4tRjT.jpg", SceneName = "Сцена 4" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/ce9r4S56O6XCTSUY2IMGZsBen6.jpg", SceneName = "Сцена 5" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/mpbcBkHbnr9ecUUOOPAKQ4WLVqi.jpg", SceneName = "Сцена 6" }
                }
            },

            // 6. Аркейн (Мультсеріал)
            new VideoCardViewModel
            {
                Id = 6,
                Title = "Аркейн",
                PosterUrl = "https://image.tmdb.org/t/p/w500/fqldf2t8ztc9aiwn3k6mlX3tvRT.jpg",
                BackdropUrl = "https://image.tmdb.org/t/p/original/w2eO7X1j05qfNf5hX5g5t1X5q5.jpg",
                ThumbnailUrl = "https://image.tmdb.org/t/p/w200/fqldf2t8ztc9aiwn3k6mlX3tvRT.jpg",
                Rating = 9.1,
                Year = "2021",
                Description = "Історія розгортається в утопічному краї Пілтовер та жорстокому підземному світі Заун, розповідаючи про становлення двох легендарних чемпіонів Ліги та про силу, що розведе їх по різні боки барикад.",
                Duration = "2 сезони",
                AgeRating = "16+",
                TrailerUrl = "https://www.youtube.com/watch?v=fXmAurh012s",
                TrailerDuration = "02:10",
                Genres = new List<string> { "Анімація", "Фантастика", "Драма" },
                IsFavorite = true,
                VideoType = VideoType.AnimatedSeries,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel
                    {
                        Name = "Гейлі Стайнфелд",
                        Character = "Вай",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/jiClUr3gaySWAyfXAHiCgmmtvij.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Елла Пернелл",
                        Character = "Джинкс",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/5PscK9HNXGFQMIxkpbR8ObB7vuR.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Кевін Алехандро",
                        Character = "Джейсі",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/bh4aQqP7kJzL2Ls9tj5OmhsBlqi.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Кеті Льюнг",
                        Character = "Кейтлін",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/9gztOAk27dpZVspSJpb27ek7LlT.jpg"
                    },
                    new ActorViewModel
                    {
                        Name = "Джейсон Спайсек",
                        Character = "Сілко",
                        ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/yWxJDXNcocccr1LkEuVXapVdcXS.jpg"
                    }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/sYXLeu5usz6yEz0k00FYvtEdodD.jpg", SceneName = "Сцена 1" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/cJ0vEnEGWZDv2a5SRRRGxtRTlPm.jpg", SceneName = "Сцена 2" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/5SXCdStomTouV3487vCSkDPEBHr.jpg", SceneName = "Сцена 3" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/5cvnxEHT3e39DvT6ARw4GNCFrB0.jpg", SceneName = "Сцена 4" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/fELr878XFIuLtkKZvTbm9M5vTiO.jpg", SceneName = "Сцена 5" }
                }
            }
        };

        var model = new VideoSectionViewModel
        {
            Title = title,
            SectionId = sectionId,
            LinkUrl = linkUrl,
            Videos = videos
        };

        return View(model);
    }
}

