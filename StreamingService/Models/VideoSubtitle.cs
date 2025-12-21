using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("video_subtitles")]
public partial class VideoSubtitle
{
    [Key]
    public int Id { get; set; }


    [Required, StringLength(64)]
    public required string Title { get; set; }

    [Required, StringLength(8)]
    public required string LocaleCode { get; set; }

    [Required, StringLength(256)]
    public required string BlobContainer { get; set; }

    [Required, StringLength(512)]
    public required string BlobPath { get; set; }


    [Required, ForeignKey(nameof(VideoEpisode))]
    public int VideoEpisodesId { get; set; }
    [Required]
    public required VideoEpisode VideoEpisodes { get; set; }
}
