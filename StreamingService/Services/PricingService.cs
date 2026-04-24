using StreamingService.DTO.ViewModels;

namespace StreamingService.Services
{
    public class PricingService
    {
        public List<PricingTier> GetPricingPlans()
        {
            return new List<PricingTier>
            {
                new PricingTier
                {
                    Title = "Безкоштовний",
                    Price = "0",
                    ButtonText = "Спробувати безкоштовно",
                    Features = new List<string> { "Обмежений каталог фільмів і серіалів",
                        "Якість відтворення до 720p",
                        "Один профіль користувача",
                        "Реклама під час перегляду",
                        "Без завантажень",
                        "Базові рекомендації",
                        "Лише онлайн-перегляд",
                        "Оновлення контенту щотижня"
                    }
                },
                new PricingTier
                {
                    Title = "Стандарт",
                    Price = "249",
                    ButtonText = "Увімкнути магію кіно",
                    Features = new List<string> { "Повний каталог фільмів і серіалів",
                        "Якість відтворення Full HD (1080p)",
                        "До двох профілів користувачів",
                        "Без реклами",
                        "Можливість завантаження офлайн",
                        "Розширені рекомендації",
                        "Перегляд на кількох пристроях",
                        "Оновлення контенту двічі на тиждень"
                    }
                },
                new PricingTier
                {
                    Title = "Преміум",
                    Price = "449",
                    ButtonText = "Дивись без меж",
                    Features = new List<string> { "Повний каталог + ексклюзиви",
                        "Якість 4K UHD + HDR",
                        "До чотирьох профілів користувачів",
                        "Без реклами",
                        "Dolby Atmos звук",
                        "Персональні рекомендаці",
                        "Ранній доступ до новинок",
                        "Постійні оновлення контенту"
                    }
                }

            };

        }
    }
}
