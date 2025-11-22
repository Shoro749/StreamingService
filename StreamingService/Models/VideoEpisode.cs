using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("video_episodes")]
public partial class VideoEpisode
{
    [Key]
    public int Id { get; set; }


    [Required]
    public int Duration { get; set; }


    [Required]
    public DateOnly ReleaseDate { get; set; }


    public int? EpisodeNumber { get; set; }


    [Required, StringLength(32)]
    public string EpisodeType { get; set; }


    [Required, ForeignKey(nameof(Models.VideoSeason))]
    public int VideoSeasonId { get; set; }
    public VideoSeason VideoSeason { get; set; }


    public List<Audiotrack> Audiotracks { get; set; } = new();
    public List<VideoEpisodeTranslation> VideoEpisodeTranslations { get; set; } = new();
    public List<VideoFile> VideoFiles { get; set; } = new();
    public List<VideoSubtitle> VideoSubtitles { get; set; } = new();
}
