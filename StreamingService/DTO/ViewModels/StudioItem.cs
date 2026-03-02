namespace StreamingService.DTO.ViewModels
{
    public class StudioItem
    {
        public string StudioName { get; set; } = "";
        public string StudioLogo { get; set; } = "";
        static public List<StudioItem> GetStudios()
        {
            return new List<StudioItem>
            {
                new StudioItem { StudioName = "Netflix", StudioLogo = "/images/landing/logos/netflix.svg" },
                new StudioItem { StudioName = "Disney", StudioLogo = "/images/landing/logos/disney.svg" },
                new StudioItem { StudioName = "Universal", StudioLogo = "/images/landing/logos/universal.svg" },
                new StudioItem { StudioName = "Dream Works", StudioLogo = "/images/landing/logos/dream_works.svg" },
                new StudioItem { StudioName = "Pixar", StudioLogo = "/images/landing/logos/pixar.svg" },
                new StudioItem { StudioName = "Warner", StudioLogo = "/images/landing/logos/warner.svg" },
                new StudioItem { StudioName = "Paramount", StudioLogo = "/images/landing/logos/paramount.svg" },
                new StudioItem { StudioName = "Sony", StudioLogo = "/images/landing/logos/sony.svg" },
                new StudioItem { StudioName = "Fox", StudioLogo = "/images/landing/logos/fox.svg" },
                new StudioItem { StudioName = "Illumination", StudioLogo = "/images/landing/logos/illumination.svg" },
                new StudioItem { StudioName = "Columbia", StudioLogo = "/images/landing/logos/columbia.svg" },
                new StudioItem { StudioName = "Hbo", StudioLogo = "/images/landing/logos/hbo.svg" },
                new StudioItem { StudioName = "Apple", StudioLogo = "/images/landing/logos/apple.svg" },
                new StudioItem { StudioName = "Amazon", StudioLogo = "/images/landing/logos/amazon.svg" },
                new StudioItem { StudioName = "Peacock", StudioLogo = "/images/landing/logos/peacock.svg" },
            };
        }
    }
}
