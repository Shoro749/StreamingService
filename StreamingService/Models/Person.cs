using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models;

[Table("persons")]
public partial class Person
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(64)]
    public required string Name { get; set; }

    [StringLength(64)]
    public string? LastName { get; set; }

    [StringLength(64)]
    public string? Patronymic { get; set; }

    public DateOnly? Birthday { get; set; }

    [StringLength(4000)]
    public string? Biography { get; set; }

    public List<PersonTranslation> PersonTranslations { get; set; } = new();
    public List<PersonVideo> PersonsVideos { get; set; } = new();
}
