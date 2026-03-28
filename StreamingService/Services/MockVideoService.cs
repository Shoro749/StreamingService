using StreamingService.DTO.Enums;
using StreamingService.DTO.ViewModels;

namespace StreamingService.Services;

public static class MockVideoService
{
    public static List<VideoCardViewModel> GetAllVideos()
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
                Year = 2024,
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
                Year = 2014,
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
                Year = 2008,
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
                Year = 2023,
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
                Year = 2023,
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
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/wQEW3xLrQAThu1GvqpsKQyejrYS.jpg",
                ThumbnailUrl = "https://image.tmdb.org/t/p/w200/fqldf2t8ztc9aiwn3k6mlX3tvRT.jpg",
                Rating = 9.1,
                Year = 2021,
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
            },

            // 7. Гострі картузи (Серіал)
            new VideoCardViewModel
            {
                Id = 7,
                Title = "Гострі картузи",
                PosterUrl = "https://media.themoviedb.org/t/p/w440_and_h660_face/a7y0YJrAy7fX8jyWeZUFhDu2L3k.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/wiE9doxiLwq3WCGamDIOb2PqBqc.jpg",
                ThumbnailUrl = "https://media.themoviedb.org/t/p/w440_and_h660_face/eDv4gpFrfOiYqSljTCBobWTccit.jpg",
                Rating = 8.6,
                Year = 2013,
                Description = "Британія, 1919 рік. Вулицями Бірмінгема керує жорстока банда «Гострі картузи», на чолі якої стоїть амбітний і хитрий Томмі Шелбі. Він прагне легалізувати сімейний бізнес і розширити свій вплив.",
                Duration = "6 сезонів",
                AgeRating = "18+",
                TrailerUrl = "https://www.youtube.com/watch?v=oVzVdvGIC7U",
                TrailerDuration = "02:05",
                Genres = new List<string> { "Драма", "Кримінал" },
                IsFavorite = false,
                VideoType = VideoType.Series,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Кілліан Мерфі", Character = "Томмі Шелбі", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/llkbyWKwpfowZ6C8peBjIV9jj99.jpg" },
                    new ActorViewModel { Name = "Пол Андерсон", Character = "Артур Шелбі", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/xROnQbYvFH3OSEoC9EgRriVAQ1G.jpg" },
                    new ActorViewModel { Name = "Софі Рандл", Character = "Ада Шелбі", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/9HxJ6pG1Q0BBbIV1UXk5iU9zDM9.jpg" },
                    new ActorViewModel { Name = "Гелен МакКрорі", Character = "Поллі Грей", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/dVtwKuGce3BhUcqfdpxFvpCT8YT.jpg" },
                    new ActorViewModel { Name = "Фінн Коул", Character = "Michael Gray", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/dVtwKuGce3BhUcqfdpxFvpCT8YT.jpg" },
                    new ActorViewModel { Name = "Ієн Пек", Character = "Curly", ImageUrl = "https://media.themoviedb.org/t/p/w276_and_h350_face/dVtwKuGce3BhUcqfdpxFvpCT8YT.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/l8v3gJDlASN0lNn51gR8zQJsu5O.jpg", SceneName = "Сцена 1" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/or7wKwv1IT6LEOktt395O5qi7e.jpg", SceneName = "Сцена 2" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/xqwY1TqwKECESoMnSpitrNGN5OO.jpg", SceneName = "Сцена 3" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/n8efGaafd9xFGuTfQfQe4QjTGEn.jpg", SceneName = "Сцена 4" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/bZ08ZTYJXSBUTsh29ycFZkvL3qP.jpg", SceneName = "Сцена 5" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/yZhneG0QGk89BCJZ4nBER5kJ1KC.jpg", SceneName = "Сцена 6" }
                }
            },

            // 8. Єллоустоун (Серіал)
            new VideoCardViewModel
            {
                Id = 8,
                Title = "Єллоустоун",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/b5SrNjmklwnXN2xXwb0coWu2tna.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/ynSOcgDLZfdLCZfRSYZGiTgYJVo.jpg",
                ThumbnailUrl = "https://media.themoviedb.org/t/p/w440_and_h660_face/6FCVZy5aprxGo0r3QcM0Erch6v0.jpg",
                Rating = 8.1,
                Year = 2018,
                Description = "Сім'я Даттонів володіє найбільшим ранчо в США. Їм доводиться постійно боротися за свої землі з індіанською резервацією, першим національним парком та жадібними забудовниками.",
                Duration = "5 сезонів",
                AgeRating = "18+",
                TrailerUrl = "https://www.youtube.com/watch?v=3nYesBABecI",
                TrailerDuration = "02:22",
                Genres = new List<string> { "Вестерн", "Драма" },
                IsFavorite = true,
                VideoType = VideoType.Series,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Кевін Костнер", Character = "Джон Даттон", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/608blZipRDZkDpzp8VItB64qMaT.jpg" },
                    new ActorViewModel { Name = "Люк Граймс", Character = "Кейсі Даттон", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/52KsHFCu0LToakebnxqC4VeRixl.jpg" },
                    new ActorViewModel { Name = "Келлі Райллі", Character = "Бет Даттон", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/gof8bWW9E7MH30GpvA97PwGiIuu.jpg" },
                    new ActorViewModel { Name = "Вес Бентлі", Character = "Джеймі Даттон", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/voD93lzFZrr9xfAggwFcPRBi84i.jpg" },
                    new ActorViewModel { Name = "Коул Гаузер", Character = "Rip Wheeler", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/1SNoIDILoXtAUJu4f7nDCPVQH5j.jpg" },
                    new ActorViewModel { Name = "Gil Birmingham", Character = "Thomas Rainwater", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/bWYOwtq0zUgpbEhTyiJHo2TmVju.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/oBilGalyrQJTtDuYIljRQGNXXb8.jpg", SceneName = "Сцена 1" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/8CN6Wwe7lmKdkLN3Q21wnFxzU4G.jpg", SceneName = "Сцена 2" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/uzKBAqpZAvo8xyKcklqXhMlQXhZ.jpg", SceneName = "Сцена 3" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/9fhNCUq6cELG5Y5XLdFZ7Fi2NPC.jpg", SceneName = "Сцена 4" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/djyUmcQJzvRH1WbZTmiVUHNoGLn.jpg", SceneName = "Сцена 5" }
                }
            },

            // 9. Краще подзвоніть Солу (Серіал)
            new VideoCardViewModel
            {
                Id = 9,
                Title = "Краще подзвоніть Солу",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/3vEJ21DnLpojV3xvOQk4fHdCiOK.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/jwD493AhnFVh57phFmAnSNOBeeX.jpg",
                ThumbnailUrl = "https://media.themoviedb.org/t/p/w440_and_h660_face/qzwy3GRjCRdSCMARugNPlWOw0e0.jpg",
                Rating = 8.9,
                Year = 2015,
                Description = "Історія перетворення дрібного адвоката Джиммі МакҐілла на сумнозвісного кримінального юриста Сола Гудмана за шість років до його зустрічі з Волтером Вайтом.",
                Duration = "6 сезонів",
                AgeRating = "16+",
                TrailerUrl = "https://www.youtube.com/watch?v=HN4oydykJFc",
                TrailerDuration = "02:11",
                Genres = new List<string> { "Драма", "Кримінал" },
                IsFavorite = true,
                VideoType = VideoType.Series,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Боб Оденкерк", Character = "Сол Гудман", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/rF0Lb6SBhGSTvjRffmlKRSeI3jE.jpg" },
                    new ActorViewModel { Name = "Рія Сігорн", Character = "Кім Векслер", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/t78ffWaeKkdGfnEGNb8TwsoxeHi.jpg" },
                    new ActorViewModel { Name = "Джонатан Бенкс", Character = "Майк Ермантраут", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/bswk26L13PvY4iMTwUTAsepXCLv.jpg" },
                    new ActorViewModel { Name = "Джанкарло Еспозіто", Character = "Ґус Фрінґ", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/gvPVjZRelOcbRryhsHQD7Vew35x.jpg" },
                    new ActorViewModel { Name = "Майкл Мендо", Character = "Nacho Varga", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/gvM2wG66bjEpiirdeQdyG9EzUfv.jpg" },
                    new ActorViewModel { Name = "Тоні Далтон", Character = "Lalo Salamanca", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/vWteTJu9Dyrax7gQq8ndTjx5s6V.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/y1AD4sbw6mYNiiSFkW1nVZzz4Zn.jpg", SceneName = "Сцена 1" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/u5pPTiLMEvxaPtdhF2Wj6YTXI2h.jpg", SceneName = "Сцена 2" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/oyGRbr6a8uQeNRuamdI13AijMiW.jpg", SceneName = "Сцена 3" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/egcNHq9PQDprPPTDlF3rys6WVy.jpg", SceneName = "Сцена 4" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/gxW8jcVf0nN5BBjiIRqJssh7m0p.jpg", SceneName = "Сцена 5" }
                }
            },

            // 10. Відьмак (Серіал)
            new VideoCardViewModel
            {
                Id = 10,
                Title = "Відьмак",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/f7Cghnb6SQ4JpLhuFPmxoOeN78s.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/s56eyXy8rADp5DpZknfe2HXq4u4.jpg",
                ThumbnailUrl = "https://media.themoviedb.org/t/p/w440_and_h660_face/fPKm17PzAAzZt4YVQ7IfEQOHeCx.jpg",
                Rating = 8.0,
                Year = 2019,
                Description = "Мутант і мисливець на монстрів Ґеральт із Рівії шукає своє місце у світі, де люди часто виявляються гіршими за чудовиськ.",
                Duration = "3 сезони",
                AgeRating = "18+",
                TrailerUrl = "https://www.youtube.com/watch?v=ndl1W4ltcmg",
                TrailerDuration = "02:15",
                Genres = new List<string> { "Фентезі", "Екшн", "Пригоди" },
                IsFavorite = false,
                VideoType = VideoType.Series,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Генрі Кавілл", Character = "Ґеральт із Рівії", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/kN3A5oLgtKYAxa9lAkpsIGYKYVo.jpg" },
                    new ActorViewModel { Name = "Аня Чалотра", Character = "Йеннефер", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/gq0RpJ2Y5kHOFMbUWHIc60xCZrd.jpg" },
                    new ActorViewModel { Name = "Фрейя Аллан", Character = "Цірі", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/8RuLG2mePw8YgFNUjWROBuxMrwT.jpg" },
                    new ActorViewModel { Name = "Джої Беті", Character = "Любисток", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/4uo4JPaK6KpdN7v8C1pbwKpNVJU.jpg" },
                    new ActorViewModel { Name = "Міанна Берінг", Character = "Тіссая", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/oN3YUXsQYfcss2lJZetkRPoKx21.jpg0" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/uBbxU8JEgLBkmALGEKJnoeAzLRp.jpg", SceneName = "Полювання" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/4qxZb9W13WVmmxde0TWe6d5FDZa.jpg", SceneName = "Академія" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/gBRDu0yMI3OQ5tCWdj14ETr9PIv.jpg", SceneName = "Зустріч" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/nZ3MAeMiyvgGM7HAmgXXD90ZwLM.jpg", SceneName = "Битва" }
                }
            },

            // 11. Гра престолів (Серіал)
            new VideoCardViewModel
            {
                Id = 11,
                Title = "Гра престолів",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/cdhtHAfcYhiSVYpN40XMDrPoapP.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/wXSnajAZ5ppTKa8Z5zzWGOK85YH.jpg",
                ThumbnailUrl = "https://media.themoviedb.org/t/p/w440_and_h660_face/x4NhJMyFSnWrTUAs8fZZpv7MsGO.jpg",
                Rating = 9.2,
                Year = 2011,
                Description = "Дев'ять шляхетних родин борються за контроль над міфічними землями Вестеросу, поки давній ворог повертається після тисячоліть сну.",
                Duration = "8 сезонів",
                AgeRating = "18+",
                TrailerUrl = "https://www.youtube.com/watch?v=KPLWWIOCOOQ",
                TrailerDuration = "02:30",
                Genres = new List<string> { "Фентезі", "Драма", "Екшн" },
                IsFavorite = true,
                VideoType = VideoType.Series,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Емілія Кларк", Character = "Дейенеріс Таргарієн", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/wb8VfDPGpyqcFltnRcJR1Wj3h4Z.jpg" },
                    new ActorViewModel { Name = "Кіт Герінгтон", Character = "Джон Сноу", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/iCFQAQqb0SgvxEdVYhJtZLhM9kp.jpg" },
                    new ActorViewModel { Name = "Пітер Дінклейдж", Character = "Тіріон Ланністер", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/9CAd7wr8QZyIN0E7nm8v1B6WkGn.jpg" },
                    new ActorViewModel { Name = "Ліна Гіді", Character = "Серсея Ланністер", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/xR2IBnBlUdyBe5hecaVdtRuQqUE.jpg" },
                    new ActorViewModel { Name = "Ніколай Костер-Валдау", Character = "Джеймі Ланністер", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/rpFOERbHkj7GWxkinUNiQ76sSGk.jpg" },
                    new ActorViewModel { Name = "Мейсі Вільямс", Character = "Ар'я Старк", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/5RjD4dDpRDAhalFtvcUj7zdLWYB.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/wk6cDSS9krjsgBy2mPbSewjAPjt.jpg", SceneName = "Стіна" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/4kTINu9mv2YV1PqFqPGG1FZMnhi.jpg", SceneName = "Дракони" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/ujGkN3a8COVz8cg6TVpTM35ntMr.jpg", SceneName = "Королівська Гавань" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/j5FxKWMWSQgzz4NzB8TrizbMve8.jpg", SceneName = "Північ" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/vsSBKT1GB5XxNcHn7EvtKxVzHHt.jpg", SceneName = "Залізний Трон" }
                }
            },

            // 12. Король Талси (Серіал)
            new VideoCardViewModel
            {
                Id = 12,
                Title = "Король Талси",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/11Zu9w5heCOhzNIjQVjAnpiVa9W.jpg",
                BackdropUrl = "https://picsum.photos/seed/tulsa_bg/1920/1080",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/11Zu9w5heCOhzNIjQVjAnpiVa9W.jpg",
                Rating = 8.4,
                Year = 2022,
                Description = "Після 25 років в'язниці капо нью-йоркської мафії Дуайт «Генерал» Манфреді висланий босом у Талсу, штат Оклахома, щоб заснувати там нову кримінальну імперію.",
                Duration = "2 сезони",
                AgeRating = "18+",
                TrailerUrl = "https://www.youtube.com/watch?v=aaQSScwJcbc",
                TrailerDuration = "01:55",
                Genres = new List<string> { "Кримінал", "Драма" },
                IsFavorite = false,
                VideoType = VideoType.Series,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Сильвестр Сталлоне", Character = "Дуайт Манфреді", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/gn3pDWthJqR0VDYGViGD3048og7.jpg" },
                    new ActorViewModel { Name = "Андреа Севідж", Character = "Стейсі Біл", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/dh2prcwPU9U1PBdCNu5SSd4Of9j.jpg" },
                    new ActorViewModel { Name = "Мартін Старр", Character = "Бодхі", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/cxGxr0S1jnvOpOHyZDYXrg2GHju.jpg" },
                    new ActorViewModel { Name = "Джей Вілл", Character = "Тайсон", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/6ABA1136deiDOBMOHAtJIMsOnSM.jpg" },
                    new ActorViewModel { Name = "Макс Казелла", Character = "Армандо", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/gwjxobbLikH5UV2UROkrNxzpqI0.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/i6G8ke6B4h0OgtRXv6b9ppxlsxP.jpg", SceneName = "Нове місто" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/4Qw4FT9jsCaSo0AzmTaWyhdlfM.jpg", SceneName = "Зустріч" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/aZmiOoPIKdlCKK96R31dqfswUdz.jpg", SceneName = "Бар" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/tOVQvaIgi13Z5xVI3YkNnFD5rks.jpg", SceneName = "Конфлікт" }
                }
            },

            // 13. Віднесені привидами (Мультфільм)
            new VideoCardViewModel
            {
                Id = 13,
                Title = "Віднесені привидами",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/m8qLMkpEwfgUdi2o1S96N1dIbkJ.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/ukfI9QkU1aIhOhKXYWE9n3z1mFR.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/m8qLMkpEwfgUdi2o1S96N1dIbkJ.jpg",
                Rating = 8.6,
                Year = 2001,
                Description = "Під час переїзду десятирічна Чіхіро потрапляє у світ духів і богів. Щоб врятувати своїх батьків, перетворених на свиней, вона змушена працювати в лазні могутньої відьми Юбаби.",
                Duration = "125 хв",
                AgeRating = "12+",
                TrailerUrl = "https://www.youtube.com/watch?v=ByXuk9QqQkk",
                TrailerDuration = "02:30",
                Genres = new List<string> { "Анімація", "Фентезі", "Пригоди" },
                IsFavorite = true,
                VideoType = VideoType.AnimatedMovie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Румі Хіїраґі", Character = "Чіхіро", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/zITaVtFyc4xSM3mxSoPRWHbqgJI.jpg" },
                    new ActorViewModel { Name = "Мію Іріно", Character = "Хаку", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/8qEEhHUObNvGQr4e6eqLu5z4qTz.jpg" },
                    new ActorViewModel { Name = "Марі Нацукі", Character = "Юбаба", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/MIFzUc77Sx57FQOZsoiGWEbpH2.jpg" },
                    new ActorViewModel { Name = "Такаші Найто", Character = "Акіо", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/xwsm0ygjG79jLIogutwo6r64igy.jpg" },
                    new ActorViewModel { Name = "Ясуко Савагучі", Character = "Юґо", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/rWspusb13VeJowmctnniXYYTcqq.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/hZth9NCeXvvO7Xi98d8q34e1Ier.jpg", SceneName = "Місто духів" },
                    new SceneViewModel { SceneImageUrl = "https://image.tmdb.org/t/p/original/vfDyXTSdEV9aj0lX3JHOLwov61W.jpg", SceneName = "Лазня" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/bf9shWfUKyEB5oB7awJeKIoCehl.jpg", SceneName = "Хаку і Чіхіро" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/Ab8mkHmkYADjU7wQiOkia9BzGvS.jpg", SceneName = "Потяг" }
                }
            },

            // 14. Форрест Ґамп (Фільм)
            new VideoCardViewModel
            {
                Id = 14,
                Title = "Форрест Ґамп",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/4Bjwrfv3GRCY71pWZvqN1gqoyU2.jpg",
                BackdropUrl = "https://picsum.photos/seed/forrest_bg/1920/1080",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/4Bjwrfv3GRCY71pWZvqN1gqoyU2.jpg",
                Rating = 8.8,
                Year = 1994,
                Description = "Історія життя чоловіка з низьким IQ, але добрим серцем, який випадково стає учасником найважливіших подій американської історії 20-го століття.",
                Duration = "142 хв",
                AgeRating = "12+",
                TrailerUrl = "https://www.youtube.com/watch?v=bLvqoHBptjg",
                TrailerDuration = "03:50",
                Genres = new List<string> { "Драма", "Мелодрама" },
                IsFavorite = false,
                VideoType = VideoType.Movie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Том Генкс", Character = "Форрест Ґамп", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/oFvZoKI6lvU03n4YoNGAll9rkas.jpg0" },
                    new ActorViewModel { Name = "Робін Райт", Character = "Дженні Каррен", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/d3rIv0y2p0jMsQ7ViR7O1606NZa.jpg" },
                    new ActorViewModel { Name = "Гері Сініз", Character = "Лейтенант Ден", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/olRjiV8ZhBixQiTvrGwXhpVXxsV.jpg" },
                    new ActorViewModel { Name = "Майкелті Вільямсон", Character = "Бабба", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/dR16zD9AjnHWbeN5OVmJWE0vSax.jpg" },
                    new ActorViewModel { Name = "Саллі Філд", Character = "Місіс Ґамп", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/5fBK36MdmdwQQMuP0W70rXADXih.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/esIkb7Wkfk016ZNpqX24w0gbgkb.jpg", SceneName = "Зупинка" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/buJOnU5FK6iIXL0iQIRfgbl5dsH.jpg", SceneName = "В'єтнам" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/xNmo08DQ4rlY9EZtKe8jOJyE0X3.jpg", SceneName = "Дерево" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/zujN1md554VNrvOATMxSAcPG6p1.jpg", SceneName = "Біг" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/fod8DLpiqPmJp6hbPfkT58f8UuS.jpg", SceneName = "Човен" }
                }
            },

            // 15. Мандрівний замок (Мультфільм)
            new VideoCardViewModel
            {
                Id = 15,
                Title = "Мандрівний замок",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/4OwFjnPLftLhPeVLRBBzAKwl3dh.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/vwBa7djy1oxfxUjc7YtVgGNsjrT.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/4OwFjnPLftLhPeVLRBBzAKwl3dh.jpg",
                Rating = 8.2,
                Year = 2004,
                Description = "Зла відьма перетворює 18-річну Софі на стару бабусю. Дівчина тікає з міста і знаходить прихисток у дивовижному мандрівному замку чарівника Хаула.",
                Duration = "119 хв",
                AgeRating = "12+",
                TrailerUrl = "https://www.youtube.com/watch?v=iwROgK94zcM",
                TrailerDuration = "01:45",
                Genres = new List<string> { "Анімація", "Фентезі", "Пригоди" },
                IsFavorite = true,
                VideoType = VideoType.AnimatedMovie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Чіеко Байшо", Character = "Софі", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/b8ANR4WfdUZtoU4ktlnMFzbq759.jpg" },
                    new ActorViewModel { Name = "Такуя Кімура", Character = "Хаул", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/sswCg8kvFsgSaVJwcIKKe4K7jOe.jpg" },
                    new ActorViewModel { Name = "Акіхіро Міва", Character = "Відьма Пустища", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/pCfBeLJigKnUWOAy7hsdBR7K0UV.jpg" },
                    new ActorViewModel { Name = "Тацуя Ґашюїн", Character = "Кальцифер", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/fLqIdkShknsJmZy4EfBWuWyHN4C.jpg" },
                    new ActorViewModel { Name = "Рюносуке Камікі", Character = "Маркл", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/ut7ewXjdgUmgkhJ1EtbOo9tbc7s.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/sQSBPNPvmq8FDerPeFQsicj1faw.jpg", SceneName = "Замок" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/94QDjwjaueEwM2c8Vvz1cYh19lC.jpg", SceneName = "Софі" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/vyaE49HAGx2f6MhhMCcMlmcMwCQ.jpg", SceneName = "Хаул у небі" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/oZggdgTPWAOnVVUAUlWAbjm9i4R.jpg", SceneName = "Кальцифер" }
                }
            },

            // 16. Одержимість (Фільм)
            new VideoCardViewModel
            {
                Id = 16,
                Title = "Одержимість",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/jYluPsHLnN5Mx9lsSiKWEHBEeYv.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/wMONVOYJfkuk82nhb3cvMuwv8UC.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/jYluPsHLnN5Mx9lsSiKWEHBEeYv.jpg",
                Rating = 8.5,
                Year = 2014,
                Description = "Амбітний молодий джазовий барабанщик потрапляє під керівництво безжалісного викладача, який не зупиниться ні перед чим, щоб розкрити потенціал студента.",
                Duration = "106 хв",
                AgeRating = "16+",
                TrailerUrl = "https://www.youtube.com/watch?v=7d_jQycdQGo",
                TrailerDuration = "02:10",
                Genres = new List<string> { "Драма", "Музика" },
                IsFavorite = false,
                VideoType = VideoType.Movie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Майлз Теллер", Character = "Ендрю Німан", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/aciu7YM8fD0BzrrA6cJ5wDKZIA6.jpg" },
                    new ActorViewModel { Name = "Дж.К. Сіммонс", Character = "Теренс Флетчер", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/ScmKoJ9eiSUOthAt1PDNLi8Fkw.jpg" },
                    new ActorViewModel { Name = "Пол Райзер", Character = "Джим Німан", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/rGryzG00uSk8LsidacSBXVgo3iv.jpg" },
                    new ActorViewModel { Name = "Мелісса Бенойст", Character = "Ніколь", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/fUPIkDDVmyZPejPu67HyfdDar9W.jpg" },
                    new ActorViewModel { Name = "Остін Стовелл", Character = "Раян", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/At09XQpVXnChgedNsxu4ceR5W9i.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/fzEM34VXnBRy1DdheGEJd4xLezT.jpg", SceneName = "Репетиція" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/bF8eIIIJJoMZf2mFibAejqEGQcX.jpg", SceneName = "Барабани" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/fRGxZuo7jJUWQsVg9PREb98Aclp.jpg", SceneName = "Конфлікт" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/5LvMXqOdgNsSzfi3S4CFxalcMOq.jpg", SceneName = "Фінал" }
                }
            },

            // 17. Дикий робот (Мультфільм)
            new VideoCardViewModel
            {
                Id = 17,
                Title = "Дикий робот",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/2e2S5mAxx3zBJgy6762sDPHkv7K.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/ll1msvrkLWWl3g20bgN7g2ua3JA.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/2e2S5mAxx3zBJgy6762sDPHkv7K.jpg",
                Rating = 8.4,
                Year = 2024,
                Description = "Робот Роз зазнає аварії на безлюдному острові і мусить навчитися виживати в дикій природі, поступово будуючи стосунки з тваринами та стаючи названою матір'ю для осиротілого гусеняти.",
                Duration = "102 хв",
                AgeRating = "6+",
                TrailerUrl = "https://www.youtube.com/watch?v=67vbkQ_I9Zc",
                TrailerDuration = "02:25",
                Genres = new List<string> { "Анімація", "Сімейний", "Фантастика" },
                IsFavorite = true,
                VideoType = VideoType.AnimatedMovie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Лупіта Ніонго", Character = "Роз", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/y40Wu1T742kynOqtwXASc5Qgm49.jpg" },
                    new ActorViewModel { Name = "Педро Паскаль", Character = "Фінк", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/cuhkTL3MezjArl80MnYl6QJQ4PQ.jpg" },
                    new ActorViewModel { Name = "Кіт Коннор", Character = "Брайтбілл", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/ut64CyBwiRudb3DxOgUa2j9Wxep.jpg" },
                    new ActorViewModel { Name = "Білл Наї", Character = "Лонгнек", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/ixFI2YCGNGJfwlpI8iyhvVZRg8C.jpg" },
                    new ActorViewModel { Name = "Стефані Сюй", Character = "Вонтра", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/8gb3lfIHKQAGOQyeC4ynQPsCiHr.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/u3F4Pw7VYFkG1PeQ7UkyCtuRMcJ.jpg", SceneName = "Аварія" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/1pmXyN3sKeYoUhu5VBZiDU4BX21.jpg", SceneName = "Ліс" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/9mJ9dxCGpudxyBtlC0M9Y4pTyXN.jpg", SceneName = "Гусеня" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/kH45I8RnDb1Dad3IZGfISdQGj5A.jpg", SceneName = "Лисиця" }
                }
            },

            // 18. Мій друг Тоторо (Мультфільм)
            new VideoCardViewModel
            {
                Id = 18,
                Title = "Мій сусід Тоторо",
                PosterUrl = "https://media.themoviedb.org/t/p/w440_and_h660_face/5xdgLzKYB9MZ7VXXNBLKsv82ArX.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/fxYazFVeOCHpHwuqGuiqcCTw162.jpg",
                ThumbnailUrl = "https://media.themoviedb.org/t/p/w440_and_h660_face/m0yS5wGtZkIX0chMarijkQsUKC2.jpg",
                Rating = 8.6,
                Year = 1988,
                Description = "Дві сестри переїжджають до села, щоб бути ближче до хворої матері, і відкривають для себе чарівних лісових духів, серед яких великий і добрий Тоторо.",
                Duration = "86 хв",
                AgeRating = "0+",
                TrailerUrl = "https://www.youtube.com/watch?v=92a7Hj0ijLs",
                TrailerDuration = "01:30",
                Genres = new List<string> { "Анімація", "Сімейний", "Фентезі" },
                IsFavorite = true,
                VideoType = VideoType.AnimatedMovie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Норіко Хідака", Character = "Сацукі", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/43OuwsjqGf7JxpFpUvB75OdDDXQ.jpg" },
                    new ActorViewModel { Name = "Чіка Сакамото", Character = "Мей", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/lIIwnLmcgGpifpRflBq0kLW9EpK.jpg" },
                    new ActorViewModel { Name = "Шиґесато Ітой", Character = "Тацуо (Батько)", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/2V17CMIcxb6JEHT5Qp3FKdlHUoE.jpg" },
                    new ActorViewModel { Name = "Сумі Шімамото", Character = "Ясуко (Мати)", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/eCw8GSp5cmye3xgzm2cvv2KmWX4.jpg" },
                    new ActorViewModel { Name = "Таніе Кітабаяші", Character = "Канта", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/vGG6ErgXfrZuRsVfDP3Po3XReST.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/6O1mOoTXuc1WqjKd2R7MFQHZ7Eb.jpg", SceneName = "Новий дім" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/8VucBqrBa0UQwEgCzkzz4vSVzDp.jpg", SceneName = "Зустріч з Тоторо" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/bOqqPwoPAPwCMtp1TUCTfLWdZ3S.jpg", SceneName = "Котобус" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/ArRiOqY2w3oF19b6DnWqY0FiZ8j.jpg", SceneName = "Дерево" }
                }
            },

            // 19. Леон (Фільм)
            new VideoCardViewModel
            {
                Id = 19,
                Title = "Леон",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/bHQQkJJ87lK3j7lRXBJQNUFkdIr.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/exlkyIr3JrQfRmyaraunYlc3JZt.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/bHQQkJJ87lK3j7lRXBJQNUFkdIr.jpg",
                Rating = 8.5,
                Year = 1994,
                Description = "Професійний найманий вбивця бере під свою опіку 12-річну дівчинку після того, як корумпований поліцейський вбиває всю її родину.",
                Duration = "110 хв",
                AgeRating = "16+",
                TrailerUrl = "https://www.youtube.com/watch?v=aNQqoExfQsg",
                TrailerDuration = "02:15",
                Genres = new List<string> { "Екшн", "Кримінал", "Драма" },
                IsFavorite = false,
                VideoType = VideoType.Movie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Жан Рено", Character = "Леон", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/mw0EZJYz3kiFq9fNxsML773gotF.jpg" },
                    new ActorViewModel { Name = "Наталі Портман", Character = "Матильда", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/edPU5HxncLWa1YkgRPNkSd68ONG.jpg" },
                    new ActorViewModel { Name = "Ґері Олдмен", Character = "Стенсфілд", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/yhaSM5habNNI1Tf4ALRwRk3VvSZ.jpg" },
                    new ActorViewModel { Name = "Денні Аєлло", Character = "Тоні", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/2WiZ8SkiFU355GUT2QuSPlenrfM.jpg" },
                    new ActorViewModel { Name = "Пітер Аппел", Character = "Малкі", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/AvOZjWVwklfJHNHD2AwLmYRhSXw.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/cgWmHDUw8e4OzLW4cWrrQ4C8mb3.jpg", SceneName = "Знайомство" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/jRJrQ72VLyEnVsvwfep8Xjlvu8c.jpg", SceneName = "Тренування" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/1UWszQdHI7j3zBqA4kx8Lk60Di8.jpg", SceneName = "Квітка" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/smhMMlzncdXHidQRcE140ph0Ngy.jpg", SceneName = "Протистояння" }
                }
            },

            // 20. П'ятий елемент (Фільм)
            new VideoCardViewModel
            {
                Id = 20,
                Title = "П'ятий елемент",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/y30mICVaZquegYznH0RKc5dn9v5.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/wgvc3PmjQGtYYDWaeuV867mnFDs.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/y30mICVaZquegYznH0RKc5dn9v5.jpg",
                Rating = 7.6,
                Year = 1997,
                Description = "У яскравому майбутньому водій таксі випадково стає ключовою фігурою в пошуках легендарної космічної зброї, здатної зупинити Абсолютне Зло.",
                Duration = "126 хв",
                AgeRating = "12+",
                TrailerUrl = "https://www.youtube.com/watch?v=fQ9RqgcR24g",
                TrailerDuration = "02:00",
                Genres = new List<string> { "Фантастика", "Екшн", "Комедія" },
                IsFavorite = true,
                VideoType = VideoType.Movie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Брюс Вілліс", Character = "Корбен Даллас", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/w3aXr1e7gQCn8MSp1vW4sXHn99P.jpg" },
                    new ActorViewModel { Name = "Мілла Йовович", Character = "Лілу", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/usWnHCzbADijULREZYSJ0qfM00y.jpg" },
                    new ActorViewModel { Name = "Ґері Олдмен", Character = "Зорґ", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/yhaSM5habNNI1Tf4ALRwRk3VvSZ.jpg" },
                    new ActorViewModel { Name = "Кріс Такер", Character = "Рубі Род", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/k0oLIL0xTgDR6Qn3yCsNuLCJhFT.jpg0" },
                    new ActorViewModel { Name = "Іен Голм", Character = "Отець Корнеліус", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/cOJDgvgj4nMec6Inzj1H5nugTO5.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/3LLhHo8UJgwQU36k4TOdAAdWdLd.jpg", SceneName = "Таксі" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/cwBMFjJpTIGWoVwK192NlOXNAr8.jpg", SceneName = "Лілу" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/bx1W729hyWQqNQoiq9LsX30FBf.jpg", SceneName = "Космопорт" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/gvd0Gy7quhD3KrDQ5avlTDIvczK.jpg", SceneName = "Опера" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/8a35VAcLRNk7YMCM0gcqnIQPGIq.jpg", SceneName = "Команда" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/nbSwyE90WWvd7TSyXdmaxOI1zWy.jpg", SceneName = "Такер" }
                }
            },

            // 21. Кролик Джоджо (Фільм)
            new VideoCardViewModel
            {
                Id = 21,
                Title = "Кролик Джоджо",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/zpNCDu7U2qI6HwoB73F9N21TKiq.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/lTyikzfGgRX5ZqIfVeT26APYfRL.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/zpNCDu7U2qI6HwoB73F9N21TKiq.jpg",
                Rating = 7.9,
                Year = 2019,
                Description = "Самотній німецький хлопчик під час Другої світової війни виявляє, що його мати ховає на горищі єврейську дівчинку. Йому доводиться переглянути свої погляди на світ.",
                Duration = "108 хв",
                AgeRating = "12+",
                TrailerUrl = "https://www.youtube.com/watch?v=tL4McUzXfFI",
                TrailerDuration = "02:22",
                Genres = new List<string> { "Комедія", "Драма", "Військовий" },
                IsFavorite = false,
                VideoType = VideoType.Movie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Роман Гріффін Девіс", Character = "Джоджо", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/jEox6Bq4TlINrnp5EUjqSlDK3eP.jpg" },
                    new ActorViewModel { Name = "Томасін МакКензі", Character = "Ельза", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/WOpnEFG5Q8LWxP81MtUrskmVox.jpg" },
                    new ActorViewModel { Name = "Скарлетт Йоганссон", Character = "Розі", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/mjReG6rR7NPMEIWb1T4YWtV11ty.jpg" },
                    new ActorViewModel { Name = "Тайка Вайтіті", Character = "Адольф", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/ww6L2ksfJNMbuiIdDuvVKndUHsv.jpg" },
                    new ActorViewModel { Name = "Сем Роквелл", Character = "Капітан Кленцендорф", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/afYhNpLwpa65Yy0Q0g00FNFhzx5.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/nxytR2iIQErGgAjrsy5ZrBB06WH.jpg", SceneName = "Табір" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/oFQRRGG63s7hYYEfTozpoFNoAl9.jpg", SceneName = "Горище" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/jUl2Kd5AJDRSwVpbbxMab57jHxw.jpg", SceneName = "Місто" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/yedyKGFpRhEPAvFS4VdDENAn6mJ.jpg", SceneName = "Взуття" }
                }
            },

            // 22. Легенда про піаніста (Фільм)
            new VideoCardViewModel
            {
                Id = 22,
                Title = "Легенда про піаніста",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/dwsWjhk2Ksvh1gqGYfYy2oV8mdW.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/qmZvzubZwGbhzGdHJEu4LfBgDr4.jpg",
                ThumbnailUrl = "https://media.themoviedb.org/t/p/w440_and_h660_face/dwsWjhk2Ksvh1gqGYfYy2oV8mdW.jpg",
                Rating = 8.1,
                Year = 1998,
                Description = "Дивовижна історія геніального піаніста, який народився на океанському лайнері і жодного разу за все своє життя не сходив на берег.",
                Duration = "165 хв",
                AgeRating = "12+",
                TrailerUrl = "https://www.youtube.com/watch?v=hOqFzmdA2o4",
                TrailerDuration = "02:18",
                Genres = new List<string> { "Драма", "Музика" },
                IsFavorite = true,
                VideoType = VideoType.Movie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Тім Рот", Character = "Денні Будман Т.Д. Лемон 1900", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/qSizF2i9gz6c6DbAC5RoIq8sVqX.jpg" },
                    new ActorViewModel { Name = "Прюітт Тейлор Вінс", Character = "Макс Тоні", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/jqC1v8tF92QcmkQycnaLSuJiQfl.jpg" },
                    new ActorViewModel { Name = "Мелані Тьєррі", Character = "Дівчина", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/bNXGy4D6PpDthKjjrzxwTbcHIeT.jpg" },
                    new ActorViewModel { Name = "Білл Нанн", Character = "Денні Будман", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/trxNvS6g5yvwbXzx2LK6JqutE5z.jpg" },
                    new ActorViewModel { Name = "Кларенс Вільямс III", Character = "Джеллі Ролл Мортон", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/6tzuvVTlBxx0oWjoT3hFTfbVqUp.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/u1W9eokqr6KHU7IeIw7gZLVyyUH.jpg", SceneName = "Корабель" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/g8DGsMM4PB3IffD2nHcHSqntdp.jpg", SceneName = "Фортепіано" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/6rmb35g7XoMCMQtnbH0rUecFZlV.jpg", SceneName = "Дуель" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/1nalJQa6K8p0Y9uxLGKKwzVX3pw.jpg", SceneName = "Запис" }
                }
            },

            // 23. Зелена книга (Фільм)
            new VideoCardViewModel
            {
                Id = 23,
                Title = "Зелена книга",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/u9y5ggnkXlhF6lovwbh6Cb0fWhm.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/205t5YwbjdcLtxfsds09ZifIlFZ.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/u9y5ggnkXlhF6lovwbh6Cb0fWhm.jpg",
                Rating = 8.2,
                Year = 2018,
                Description = "Вишибала італо-американського походження стає водієм афроамериканського класичного піаніста під час туру американським Півднем у 1960-х роках.",
                Duration = "130 хв",
                AgeRating = "12+",
                TrailerUrl = "https://www.youtube.com/watch?v=QkZxoko_HC0",
                TrailerDuration = "02:30",
                Genres = new List<string> { "Біографія", "Комедія", "Драма" },
                IsFavorite = false,
                VideoType = VideoType.Movie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Вігго Мортенсен", Character = "Тоні Ліп", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/vH5gVSpHAMhDaFWfh0Q7BG61O1y.jpg" },
                    new ActorViewModel { Name = "Магершала Алі", Character = "Доктор Дон Ширлі", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/9ZmSejm5lnUVY5IJ1iNx2QEjnHb.jpg" },
                    new ActorViewModel { Name = "Лінда Карделліні", Character = "Долорес", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/bcycvynDprC1rrhBNrnBjn5uOUd.jpg" },
                    new ActorViewModel { Name = "Себастьян Маніскалко", Character = "Джонні Венере", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/8TvA9HEwURJmY9MkkUruB4Sl0lR.jpg" },
                    new ActorViewModel { Name = "Дімітар Марінов", Character = "Олег", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/lZwHZ27xqsPsuswcxyx6uWSh5VP.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/yJCOTcyVyO6J5OJhaSH9gmUqVlh.jpg", SceneName = "Автомобіль" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/jfnXCmMRCDVPihi98KgCiLUWHPE.jpg", SceneName = "Концерт" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/b05DiO4cFFKSNSE4tu3XpoiRDRw.jpg", SceneName = "Лист" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/vMbFlVopC5geNbfDJMrnAkuVYUp.jpg", SceneName = "Бар" }
                }
            },

            // 24. Термінал (Фільм)
            new VideoCardViewModel
            {
                Id = 24,
                Title = "Термінал",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/wvM5wravwMKNZ4aqt0n5sPvs4uR.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/zywtNiaZ9r7azrcNdl2j0jOgrkw.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/wvM5wravwMKNZ4aqt0n5sPvs4uR.jpg",
                Rating = 7.4,
                Year = 2004,
                Description = "Турист зі Східної Європи опиняється в пастці в аеропорту імені Джона Кеннеді після того, як у його рідній країні стається переворот, і його паспорт стає недійсним.",
                Duration = "128 хв",
                AgeRating = "12+",
                TrailerUrl = "https://www.youtube.com/watch?v=iZqQRmhRvyg",
                TrailerDuration = "02:30",
                Genres = new List<string> { "Драма", "Комедія", "Мелодрама" },
                IsFavorite = true,
                VideoType = VideoType.Movie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Том Генкс", Character = "Віктор Наворскі", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/oFvZoKI6lvU03n4YoNGAll9rkas.jpg" },
                    new ActorViewModel { Name = "Кетрін Зета-Джонс", Character = "Амелія Воррен", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/bBZKAbjNCGS9VpDKaK6TWGsL3ws.jpg" },
                    new ActorViewModel { Name = "Стенлі Туччі", Character = "Френк Діксон", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/q4TanMDI5Rgsvw4SfyNbPBh4URr.jpg" },
                    new ActorViewModel { Name = "Чі МакБрайд", Character = "Малрой", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/cesCeJZ5gSywA9lTYReB5uhkfek.jpg" },
                    new ActorViewModel { Name = "Дієго Луна", Character = "Енріке Крус", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/qwbjcyDN37OHiln4a6P4LP31o7F.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/cciMqAHjpRsAcVMO4Md39U2H9s4.jpg", SceneName = "Аеропорт" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/8Mk2WfPOOxlUHI6VNQh0anJPnCZ.jpg", SceneName = "Очікування" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/y6d5lcxJAGuwTLTcIVSiZWaOWNA.jpg", SceneName = "Побачення" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/8rCFtUj1aB6iQvmKULFwnS4zeaN.jpg", SceneName = "Робота" }
                }
            },

            // 25. Джанґо вільний (Фільм)
            new VideoCardViewModel
            {
                Id = 25,
                Title = "Джанґо вільний",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/effwvCvNGs23voTkvsDVfhkNJea.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/oXGt9e7FIwojD99Cn1p764C83eO.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/effwvCvNGs23voTkvsDVfhkNJea.jpg",
                Rating = 8.4,
                Year = 2012,
                Description = "Звільнений раб об'єднується з німецьким мисливцем за головами, щоб врятувати свою дружину від жорстокого власника плантації в Міссісіпі.",
                Duration = "165 хв",
                AgeRating = "18+",
                TrailerUrl = "https://www.youtube.com/watch?v=0fUCuvNlOxc",
                TrailerDuration = "02:45",
                Genres = new List<string> { "Вестерн", "Драма", "Екшн" },
                IsFavorite = false,
                VideoType = VideoType.Movie,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Джеймі Фокс", Character = "Джанґо", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/25zzvFA6yx2Q9BYnugsbd4JWDfu.jpg" },
                    new ActorViewModel { Name = "Крістоф Вальц", Character = "Доктор Шульц", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/jMvLGCVXLaBqjRLf5olyvEucZob.jpg" },
                    new ActorViewModel { Name = "Леонардо ДіКапріо", Character = "Келвін Кенді", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/vo4fltT9zZ1kH8nhLetz8MED6jp.jpg" },
                    new ActorViewModel { Name = "Керрі Вашингтон", Character = "Брунгільда", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/hCi43gRO7zfv3Mu8X1bpqtloyHT.jpg" },
                    new ActorViewModel { Name = "Семюел Л. Джексон", Character = "Стівен", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/AiAYAqwpM5xmiFrAIeQvUXDCVvo.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/c1KGjSNrN4xsia1vSAJlg9sqoXb.jpg", SceneName = "Зустріч" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/166E3iHhlJ6vvQ3GssgdvpkWGUW.jpg", SceneName = "Плантація" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/lky8kYyCpJU4Vq1yCRzQazLfVNY.jpg", SceneName = "Кенділенд" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/1nKlIkYuDPef9R28PlGVjMQHlTA.jpg", SceneName = "Перестрілка" }
                }
            },

            // 26. Аватар: Останній Захисник (Мультсеріал)
            new VideoCardViewModel
            {
                Id = 26,
                Title = "Аватар: Останній Захисник",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/4BD2KIoyJDEEKOp7iHrrWCJ6rhp.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/7oBGhqJIghRBvOwo5Qe0yM0cnMc.jpg",
                ThumbnailUrl = "https://media.themoviedb.org/t/p/w440_and_h660_face/kSNwkqnskky7NxwCJ5vQnxrs2sw.jpg",
                Rating = 9.3,
                Year = 2005,
                Description = "У світі, розірваному війною, Аватар Аанг мусить опанувати всі чотири стихії, щоб зупинити націю Вогню та відновити баланс у світі.",
                Duration = "3 сезони",
                AgeRating = "6+",
                TrailerUrl = "https://www.youtube.com/watch?v=d1EnW4qw15E",
                TrailerDuration = "01:50",
                Genres = new List<string> { "Анімація", "Фентезі", "Пригоди" },
                IsFavorite = true,
                VideoType = VideoType.AnimatedSeries,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Зак Тайлер Айзен", Character = "Аанг", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/ifHd2Yoovlvu6FFEIxUsXVyrYUf.jpg" },
                    new ActorViewModel { Name = "Мей Вітман", Character = "Катара", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/x0DdzjoYN8K2PwjrnH3ogPYv2zo.jpg" },
                    new ActorViewModel { Name = "Джек ДеСена", Character = "Сокка", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/i9VlMsPol6XIicnRZRiwmYSyE4P.jpg" },
                    new ActorViewModel { Name = "Данте Баско", Character = "Зуко", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/2bfQho7MEo4wAQTmC687FkXUoKU.jpg" },
                    new ActorViewModel { Name = "Джессі Флауер", Character = "Тоф", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/4ghTS2mkdfHt4vNHIzDIyU1mVxT.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/41eUFDjNA7KMcCQJ9Vw3OkCUWYz.jpg", SceneName = "Пробудження" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/hAdoaI9rZOTcqmaM3FjHqfhPynI.jpg", SceneName = "Магія води" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/5wsY5FRTkDL3cUVRcA6F987khQW.jpg", SceneName = "Команда Аватара" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/uH7xQLxWIU2rTqyYqf6K0awpFjh.jpg", SceneName = "Зуко" }
                }
            },

            // 27. Зоряні війни: Війни клонів (Мультсеріал)
            new VideoCardViewModel
            {
                Id = 27,
                Title = "Зоряні війни: Війни клонів",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/cqebxlxWLKTPVg0nZWSpq6CEHtt.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/m6eRgkR1KC6Mr6gKx6gKCzSn6vD.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/cqebxlxWLKTPVg0nZWSpq6CEHtt.jpg",
                Rating = 8.4,
                Year = 2008,
                Description = "Джедаї борються за підтримання порядку і миру в галактиці, ведучи Армію Республіки проти дроїдів Сепаратистів під час Війн клонів.",
                Duration = "7 сезонів",
                AgeRating = "12+",
                TrailerUrl = "https://www.youtube.com/watch?v=ZLW2jkd6E7g",
                TrailerDuration = "02:15",
                Genres = new List<string> { "Анімація", "Фантастика", "Екшн" },
                IsFavorite = false,
                VideoType = VideoType.AnimatedSeries,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Метт Лантер", Character = "Енакін Скайвокер", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/2ms8DR9n4wh9ZU6lIuqsE58LPT9.jpg" },
                    new ActorViewModel { Name = "Ешлі Екштейн", Character = "Асока Тано", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/jdzSL5AJePycTs1KQpYzm6I55qC.jpg" },
                    new ActorViewModel { Name = "Джеймс Арнольд Тейлор", Character = "Обі-Ван Кенобі", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/xP7SNjPMhZ2m4aVuYboPa8W1RlB.jpg" },
                    new ActorViewModel { Name = "Ді Бредлі Бейкер", Character = "Клони", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/9oFnToDZWp0I484s7Ua1EzNQQ2m.jpg" },
                    new ActorViewModel { Name = "Том Кейн", Character = "Йода / Оповідач", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/sq49aVP56G50Nr5kCL7Ove6Z9jE.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/afjj0Npg7up7L3bQaUgvWlpzaZd.jpg", SceneName = "Битва" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/7dlMDWJgIASB1lcm4xGR88NCZ4X.jpg", SceneName = "Джедаї" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/vfOigR4EMbuOp5kiDqvDNkSud3l.jpg", SceneName = "Асока" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/dqjSErtMVTPtPnfnDV7h4habd4X.jpg", SceneName = "Світлові мечі" }
                }
            },

            // 28. Південний Парк (Мультсеріал)
            new VideoCardViewModel
            {
                Id = 28,
                Title = "Південний Парк",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/yodYPqA7x6eWsqTh5gyPtzD98AG.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/41neXsH222hV2zrsTyw8h7javon.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/yodYPqA7x6eWsqTh5gyPtzD98AG.jpg",
                Rating = 8.7,
                Year = 1997,
                Description = "Сатиричні пригоди чотирьох школярів — Стена, Кайла, Картмана та Кенні — у вигаданому містечку Південний Парк, штат Колорадо.",
                Duration = "26 сезонів",
                AgeRating = "18+",
                TrailerUrl = "https://www.youtube.com/watch?v=FjJEet2_D6E",
                TrailerDuration = "01:45",
                Genres = new List<string> { "Анімація", "Комедія", "Сатира" },
                IsFavorite = true,
                VideoType = VideoType.AnimatedSeries,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Трей Паркер", Character = "Стен / Картман", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/pVEfyxGOBoKoirRZtmSsJ7PX91V.jpg" },
                    new ActorViewModel { Name = "Метт Стоун", Character = "Кайл / Кенні", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/nS3BOaF0EHd7vyATV7WBnFEvTLr.jpg" },
                    new ActorViewModel { Name = "Ейпріл Стюарт", Character = "Ліен Картман", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/qmPAms01P6ZHp5wjQW2XkymwjCx.jpg" },
                    new ActorViewModel { Name = "Мона Маршалл", Character = "Шейла Брофловські", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/A2RCAt0Xmm3jLBKZogQAJX6eD9n.jpg" },
                    new ActorViewModel { Name = "Айзек Гейз", Character = "Шеф", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/wHZOIi0LJNZ55dswVMX5AqKtMlT.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/41neXsH222hV2zrsTyw8h7javon.jpg", SceneName = "Автобусна зупинка" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/kca4eCnoGrEi004S4Bf3WiaPCCT.jpg", SceneName = "Школа" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/u3x95JCFH2VS7jOVHG70YW590jy.jpg", SceneName = "Місто" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/5rZ9PiWtFDXM5a0qmKTfXEYg766.jpg", SceneName = "Картман" }
                }
            },

            // 29. Сімпсони (Мультсеріал)
            new VideoCardViewModel
            {
                Id = 29,
                Title = "Сімпсони",
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/aNFV1eTckRkyGyCsXkWiEOSeM8X.jpg",
                BackdropUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/ukzJIPKTTSUzdr7jQoGKdrvZGk7.jpg",
                ThumbnailUrl = "https://www.themoviedb.org/t/p/w1280/aNFV1eTckRkyGyCsXkWiEOSeM8X.jpg",
                Rating = 8.7,
                Year = 1989,
                Description = "Сатиричне зображення життя американського середнього класу на прикладі родини Сімпсонів, яка складається з Гомера, Мардж, Барта, Ліси та Меґґі.",
                Duration = "35 сезонів",
                AgeRating = "12+",
                TrailerUrl = "https://www.youtube.com/watch?v=HRV6tMR-VW8",
                TrailerDuration = "02:00",
                Genres = new List<string> { "Анімація", "Комедія", "Сімейний" },
                IsFavorite = false,
                VideoType = VideoType.AnimatedSeries,
                Actors = new List<ActorViewModel>
                {
                    new ActorViewModel { Name = "Ден Кастелланета", Character = "Гомер Сімпсон", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/AmeqWhP4A46AWkM4kVphg6jOTQX.jpg" },
                    new ActorViewModel { Name = "Джулі Кавнер", Character = "Мардж Сімпсон", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/87kSPYlWcHvqOVEkhdqxysiAf6w.jpg" },
                    new ActorViewModel { Name = "Ненсі Картрайт", Character = "Барт Сімпсон", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/kJQEz3NAwHGdb2sQzAnBf1RmMV4.jpg" },
                    new ActorViewModel { Name = "Ярдлі Сміт", Character = "Ліса Сімпсон", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/9AjPwbb3uz4GfgOPBYsy2ILvwkB.jpg0" },
                    new ActorViewModel { Name = "Гаррі Ширер", Character = "Містер Бернс", ImageUrl = "https://media.themoviedb.org/t/p/w132_and_h132_face/7PnGZGVKJNDTUv3DkbaMEnCseT0.jpg" }
                },
                Scenes = new List<SceneViewModel>
                {
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/8HHJUncPJ30rmYAuSRYjHpz2B3R.jpg", SceneName = "Диван" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/xeFQcrdWNVT5069ugPH3QCpvqHQ.jpg", SceneName = "Спрінгфілд" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/nu17MBlOzIUvs7E4dJFHEgEBu72.jpg", SceneName = "Таверна Мо" },
                    new SceneViewModel { SceneImageUrl = "https://media.themoviedb.org/t/p/w1000_and_h563_face/xWsTw6LhmNYQAwdv1m0ZNUmbym7.jpg", SceneName = "Школа" }
                }
            }
        };
        return videos;
    }
}