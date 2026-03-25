namespace StreamingService.DTO.ViewModels
{
    public class PersonAdminViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateOnly? BirthDate { get; set; }
        public string PhotoUrl { get; set; } = "";
        public int MoviesCount { get; set; }
    }
}
