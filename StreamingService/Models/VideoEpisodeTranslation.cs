using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("video_episode_translations")]
public partial class VideoEpisodeTranslation
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


    [ForeignKey(nameof(VideoEpisode))]
    public int VideoEpisodesId { get; set; }
    [Required]
    public required VideoEpisode VideoEpisode { get; set; }
}
