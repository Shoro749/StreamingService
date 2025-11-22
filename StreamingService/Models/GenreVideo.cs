using StreamingService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("genres_videos")]
public class GenreVideo
{
    [Key]
    public int Id { get; set; }


    [Required, ForeignKey(nameof(Video))]
    public int VideoId { get; set; }
    public Video Video { get; set; }


    [Required, ForeignKey(nameof(Genre))]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}
