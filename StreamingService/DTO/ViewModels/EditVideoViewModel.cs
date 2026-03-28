namespace StreamingService.DTO.ViewModels
{
    public class EditVideoViewModel
    {
        public int Id { get; set; }
        public string AgeRating { get; set; } = "12+";
        public string? TrailerUrl { get; set; }
        public int? TrailerDuration { get; set; }
        public string? PosterUrl { get; set; }

        public List<VideoTranslationViewModel> Translations { get; set; } = new();
        public List<int> SelectedGenreIds { get; set; } = new();
        public List<SeasonAdminViewModel> Seasons { get; set; } = new();
        public List<PersonSummaryViewModel> Actors { get; set; } = new();
    }
}
