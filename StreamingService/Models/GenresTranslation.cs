using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("genre_translations")]
public partial class GenreTranslation
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(8)]
    public required string LocaleCode { get; set; }
    public bool? IsOriginal { get; set; }

    [Required, StringLength(256)]
    public required string Name { get; set; }

    [ForeignKey(nameof(Genre))]
    public int GenreId { get; set; }
    [Required]
    public required Genre Genre { get; set; }
}
