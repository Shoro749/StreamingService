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
    public string LocaleCode { get; set; }


    public bool? IsOriginal { get; set; }


    [Required, StringLength(256)]
    public string Title { get; set; }


    [Required, StringLength(4000)]
    public string Description { get; set; }


    [Required ,ForeignKey(nameof(Models.VideoEpisode))]
    public int VideoEpisodesId { get; set; }
    public VideoEpisode VideoEpisode { get; set; }
}
