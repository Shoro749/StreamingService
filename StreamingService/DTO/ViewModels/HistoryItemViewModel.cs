namespace StreamingService.DTO.ViewModels;

public class HistoryItemViewModel
{
    public VideoCardViewModel Video { get; set; }
    public string ViewedDate { get; set; } = "";
    public string DeviceName { get; set; } = "";
    public string ViewProgress { get; set; } = "";
    public bool IsCompleted => ViewProgress == "100%";
}