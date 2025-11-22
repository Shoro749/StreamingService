using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("audiotracks")]
public partial class Audiotrack
{
    [Key]
    public int Id { get; set; }


    [Required, StringLength(8)]
    public string LocaleCode { get; set; }


    [Required, StringLength(32)]
    public string AudioCodec { get; set; }


    [Required]
    public long SizeBytes { get; set; }

    [Required]
    public int BitrateKbps { get; set; }


    [Required, StringLength(32)]
    public string ContentType { get; set; }


    [Required, StringLength(256)]
    public string BlobContainer { get; set; }


    [Required, StringLength(512)]
    public string BlobPath { get; set; }


    [Required, ForeignKey(nameof(Models.VideoEpisode))]
    public int VideoEpisodesId { get; set; }
    public VideoEpisode VideoEpisode { get; set; }
}
