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
    public string Title { get; set; }


    [Required, StringLength(8)]
    public string LocaleCode { get; set; }


    [Required, StringLength(256)]
    public string BlobContainer { get; set; }


    [Required, StringLength(512)]
    public string BlobPath { get; set; }


    [Required, ForeignKey(nameof(Models.VideoEpisode))]
    public int VideoEpisodesId { get; set; }
    public VideoEpisode VideoEpisodes { get; set; }
}
