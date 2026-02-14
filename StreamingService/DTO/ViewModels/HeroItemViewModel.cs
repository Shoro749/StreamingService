namespace StreamingService.DTO.ViewModels
{
    public class HeroItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        // Основні теги зверху зліва
        public string Duration { get; set; }
        public int Year { get; set; }
        public string AgeRating { get; set; }

        // Категорія та жанри. 
        public List<string> Genres { get; set; } = new();

        // Дані для трейлера
        public string TrailerUrl { get; set; }
        public string TrailerDuration { get; set; }

        // Стан кнопки "Улюблене"
        public bool IsFavorite { get; set; }
    }
}
