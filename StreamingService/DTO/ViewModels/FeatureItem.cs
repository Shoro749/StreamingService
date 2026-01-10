namespace StreamingService.DTO.ViewModels
{
    public class FeatureItem
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Icon { get; set; } = "";
        static public List<FeatureItem> GetFeatures()
        {
            return new List<FeatureItem>
            {
                new FeatureItem
                {
                    Title = "Дивись на будь-якому екрані",
                    Description = "Smart TV, ноутбук, планшет чи смартфон — переглядай, де зручно, без обмежень у якості.",
                    Icon = "/images/landing/icons/Image 1.svg"
                },
                new FeatureItem
                {
                    Title = "Переглядай навіть без інтернету",
                    Description = "Завантажуй улюблені фільми, серіали чи мультфільми заздалегідь і дивись офлайн — у дорозі, у подорожі чи вдома без Wi-Fi.",
                    Icon = "/images/landing/icons/Image 2.svg"
                },
                new FeatureItem
                {
                    Title = "Твої історії завжди поруч",
                    Description = "Без обмежень у перегляді — уся бібліотека доступна в будь-який момент, у твоєму власному темпі.",
                    Icon = "/images/landing/icons/Image 3.svg"
                },
                new FeatureItem
                {
                    Title = "Окремий простір для дітей",
                    Description = "Безпечна зона з добіркою мультфільмів, сімейних шоу та дитячих серіалів — тільки перевірений контент для найменших.",
                    Icon = "/images/landing/icons/Image 4.svg"
                },
            };
        }
    }
}
