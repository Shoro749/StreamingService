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
    public required string LocaleCode { get; set; }

    [Required, StringLength(32)]
    public required string AudioCodec { get; set; }
    public long SizeBytes { get; set; }
    public int BitrateKbps { get; set; }

    [Required, StringLength(32)]
    public required string ContentType { get; set; }

    [Required, StringLength(256)]
    public required string BlobContainer { get; set; }

    [Required, StringLength(512)]
    public required string BlobPath { get; set; }

    [Required, ForeignKey(nameof(VideoEpisode))]
    public int VideoEpisodesId { get; set; }
    public required VideoEpisode VideoEpisode { get; set; }
}
