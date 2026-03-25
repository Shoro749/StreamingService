using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.ViewModels
{
    public class AddEpisodeViewModel
    {
        public int VideoId { get; set; }

        [Required]
        [Range(1, 100)]
        public int EpisodeNumber { get; set; }

        [Required]
        [Range(1, 500)]
        public int Duration { get; set; } // В хвилинах

        [Required]
        public DateOnly ReleaseDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    }
}
