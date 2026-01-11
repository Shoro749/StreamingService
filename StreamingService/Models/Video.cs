using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models;

[Table("videos")]
public partial class Video
{
    [Key]
    public int Id { get; set; }
    public long RatingCount { get; set; }
    public long RatingSum { get; set; }


    [ForeignKey(nameof(SubscriptionLevel))]
    public int MinAccess { get; set; }
    [Required]
    public required SubscriptionLevel SubscriptionLevel { get; set; }


    public List<VideoSeason> Seasons { get; set; } = new();
    public List<VideoImage> Images { get; set; } = new();
    public List<VideoTranslation> Translations { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    public List<UserVideoFavorite> Favorites { get; set; } = new();
    public List<UserVideoRating> Ratings { get; set; } = new();
    public List<GenreVideo> GenreVideos { get; set; } = new();
    public List<PersonVideo> PersonVideos { get; set; } = new();
}
