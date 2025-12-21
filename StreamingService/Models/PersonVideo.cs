using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("person_videos")]
public partial class PersonVideo
{
    [Key]
    public int Id { get; set; }


    [Required, ForeignKey(nameof(Person))]
    public int PersonId { get; set; }
    public required Person Person { get; set; }


    [ForeignKey(nameof(PersonRole))]
    public int PersonRoleId { get; set; }
    [Required]
    public required PersonRole PersonRole { get; set; }


    [ForeignKey(nameof(Video))]
    public int VideoId { get; set; }
    [Required]
    public required Video Video { get; set; }
}
