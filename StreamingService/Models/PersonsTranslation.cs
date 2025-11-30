using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("persons_translations")]
public partial class PersonTranslation
{
    [Key]
    public int Id { get; set; }


    [Required, StringLength(8)]
    public required string LocaleCode { get; set; }

    public bool? IsOriginal { get; set; }

    [Required, StringLength(64)]
    public required string Name { get; set; }

    [StringLength(64)]
    public string? LastName { get; set; }

    [StringLength(64)]
    public string? Patronymic { get; set; }

    [ForeignKey(nameof(Person))]
    public int PersonId { get; set; }
    [Required]
    public required Person Person { get; set; }
}
