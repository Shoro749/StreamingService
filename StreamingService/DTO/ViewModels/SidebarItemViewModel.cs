namespace StreamingService.DTO.ViewModels
{
    public class SidebarItemViewModel
    {
        public string PageName { get; set; } = "";
        public string PageUrl { get; set; } = "";
        public string InactiveIcon { get; set; } = "";
        public string ActiveIcon { get; set; } = "";
        public bool IsActive { get; set; }
        public bool HasSeparator { get; set; } = false;
    }
}

