using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models;

[Table("video_images")]
public partial class VideoImage
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(32)]
    public required string Type { get; set; }

    [Required, StringLength(256)]
    public required string BlobContainer { get; set; }

    [Required, StringLength(512)]
    public required string BlobPath { get; set; }


    [ForeignKey(nameof(Video))]
    public int VideoId { get; set; }
    [Required]
    public required Video Video { get; set; }
}
