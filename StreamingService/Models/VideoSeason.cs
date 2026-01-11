using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models;

[Table("video_seasons")]
public partial class VideoSeason
{
    [Key]
    public int Id { get; set; }

    public int? NumberOfSeason { get; set; }


    [ForeignKey(nameof(Video))]
    public int VideoId { get; set; }
    [Required]
    public required Video Video { get; set; }

    public List<VideoEpisode> Episodes { get; set; } = new();
}
