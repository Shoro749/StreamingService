namespace StreamingService.DTO.ViewModels
{
    public class GenreAdminViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = "";
        public List<GenreTranslationViewModel> Translations { get; set; } = new();
    }
}
