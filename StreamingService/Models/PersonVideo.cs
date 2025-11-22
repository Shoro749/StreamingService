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


    [Required, ForeignKey(nameof(Models.Person))]
    public int PersonId { get; set; }
    public Person Person { get; set; }


    [Required, ForeignKey(nameof(Models.PersonRole))]
    public int PersonRoleId { get; set; }
    public PersonRole PersonRole { get; set; }


    [Required, ForeignKey(nameof(Models.Video))]
    public int VideoId { get; set; }
    public Video Video { get; set; }
}
