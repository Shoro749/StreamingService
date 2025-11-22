using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("video_seasons")]
public partial class VideoSeason
{
    [Key]
    public int Id { get; set; }

    public int? NumberOfSeason { get; set; }


    [Required, ForeignKey(nameof(Models.Video))]
    public int VideoId { get; set; }
    public Video Video { get; set; }

    public List<VideoEpisode> Episodes { get; set; } = new();
}
