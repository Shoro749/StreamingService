using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models;

[Table("video_translations")]
public partial class VideoTranslation
{
    [Key]
    public int Id { get; set; }


    [Required, StringLength(8)]
    public required string LocaleCode { get; set; }
    public bool? IsOriginal { get; set; }

    [Required, StringLength(256)]
    public required string Title { get; set; }

    [Required, StringLength(4000)]
    public required string Description { get; set; }


    [Required, ForeignKey(nameof(Video))]
    public int VideoId { get; set; }
    [Required]
    public required Video Video { get; set; }
}
