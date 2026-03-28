namespace StreamingService.DTO.ViewModels
{
    public class SearchResultsViewModel
    {
        public string? Query { get; set; }
        public int? SelectedGenreId { get; set; }
        public string? SortBy { get; set; }

        public List<VideoCardViewModel> Videos { get; set; } = new();

        public int TotalResults { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
