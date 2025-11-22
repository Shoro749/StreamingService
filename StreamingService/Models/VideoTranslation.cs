using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("video_translations")]
public partial class VideoTranslation
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


    [Required, ForeignKey(nameof(Models.Video))]
    public int VideoId { get; set; }
    public Video Video { get; set; }
}
