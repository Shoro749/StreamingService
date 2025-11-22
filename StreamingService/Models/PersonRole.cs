using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StreamingService.Models;

[Table("person_roles")]
public partial class PersonRole
{
    [Key]
    public int Id { get; set; }


    [Required, StringLength(256)]
    public string Code { get; set; }

    public List<PersonVideo> PersonsVideos { get; set; } = new();
}
