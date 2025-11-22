using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("video_images")]
public partial class VideoImage
{
    [Key]
    public int Id { get; set; }


    [Required, StringLength(32)]
    public string Type { get; set; }


    [Required, StringLength(256)]
    public string BlobContainer { get; set; }


    [Required, StringLength(512)]
    public string BlobPath { get; set; }


    [Required, ForeignKey(nameof(Models.Video))]
    public int VideoId { get; set; }
    public Video Video { get; set; }
}
