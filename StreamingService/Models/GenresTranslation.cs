using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("genres_translations")]
public partial class GenreTranslation
{
    [Key]
    public int Id { get; set; }


    [Required, StringLength(8)]
    public string LocaleCode { get; set; }


    public bool? IsOriginal { get; set; }


    [Required, StringLength(256)]
    public string Name { get; set; }


    [Required, ForeignKey(nameof(Genre))]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}
