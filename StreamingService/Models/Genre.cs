using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("genres")]
public partial class Genre
{
    [Key]
    public int Id { get; set; }


    [Required, StringLength(256)]
    public required string Code { get; set; }


    public List<GenreTranslation> GenreTranslations { get; set; } = new();
    public List<GenreVideo> GenreVideos { get; set; } = new();
    public List<Genre> Genres { get; set; } = new();
}
