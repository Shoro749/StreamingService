namespace StreamingService.DTO.ViewModels
{
    public class PersonsPageViewModel
    {
        public List<PersonAdminViewModel> Persons { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Search { get; set; }
    }
}
