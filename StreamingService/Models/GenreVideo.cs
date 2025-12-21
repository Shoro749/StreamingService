using StreamingService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("genre_videos")]
public class GenreVideo
{
    [Key]
    public int Id { get; set; }


    [ForeignKey(nameof(Video))]
    public int VideoId { get; set; }
    [Required]
    public required Video Video { get; set; }


    [ForeignKey(nameof(Genre))]
    public int GenreId { get; set; }
    [Required]
    public required Genre Genre { get; set; }
}
