using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("video_files")]
public partial class VideoFile
{
    [Key]
    public int Id { get; set; }


    [Required, StringLength(32)]
    public required string Resolution { get; set; }

    [Required, StringLength(32)]
    public required string VideoCodec { get; set; }

    public long SizeBytes { get; set; }

    public int BitrateKbps { get; set; }

    [StringLength(32)]
    public required string ContentType { get; set; }

    [Required, StringLength(256)]
    public required string BlobContainer { get; set; }

    [Required, StringLength(512)]
    public required string BlobPath { get; set; }


    [Required, ForeignKey(nameof(VideoEpisode))]
    public int VideoEpisodesId { get; set; }
    [Required]
    public required VideoEpisode VideoEpisode { get; set; }
}
