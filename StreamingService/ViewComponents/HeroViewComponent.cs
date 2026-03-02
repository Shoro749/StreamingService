using Microsoft.AspNetCore.Mvc;
using StreamingService.DTO.ViewModels;

namespace StreamingService.ViewComponents
{
    public class HeroViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var items = new List<HeroItemViewModel>
            {
                new HeroItemViewModel
                {
                    Id = 1,
                    Title = "Як приборкати дракона",
                    ImageUrl = "/images/movies/dragon_banner.png",
                    Duration = "125 хвилин",
                    Year = 2025,
                    AgeRating = "PG",
                    Genres = new List<string> { "сімейний", "фільм", "фентезі" },
                    TrailerUrl = "#", // поки заглушка
                    TrailerDuration = "2:30",
                    IsFavorite = false
                },
                new HeroItemViewModel
                {
                    Id = 2,
                    Title = "Дюна: Частина друга",
                    ImageUrl = "/images/movies/dune_pII_banner.png",
                    Duration = "166 хвилин",
                    Year = 2024,
                    AgeRating = "12+",
                    Genres = new List<string> { "фантастика", "екшн", "драма" },
                    TrailerUrl = "#",
                    TrailerDuration = "3:05",
                    IsFavorite = false
                },
                new HeroItemViewModel
                {
                    Id = 3,
                    Title = "Дім Дракона",
                    ImageUrl = "/images/movies/house_of_the_dragon_banner.png",
                    Duration = "60 хвилин", // Для серіалів вказую час епізоду
                    Year = 2022,
                    AgeRating = "18+",
                    Genres = new List<string> { "серіал", "фентезі", "драма" },
                    TrailerUrl = "#",
                    TrailerDuration = "1:55",
                    IsFavorite = true
                },
                new HeroItemViewModel
                {
                    Id = 4,
                    Title = "Ходячі мерці",
                    ImageUrl = "/images/movies/walking_dead_banner.png",
                    Duration = "45 хвилин",
                    Year = 2010,
                    AgeRating = "18+",
                    Genres = new List<string> { "серіал", "жахи", "трилер" },
                    TrailerUrl = "#",
                    TrailerDuration = "2:10",
                    IsFavorite = false
                }
            };

            return View(items);
        }
    }
}