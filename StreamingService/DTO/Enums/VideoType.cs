using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace StreamingService.DTO.Enums
{
    public enum VideoType
    {
        [Display(Name = "Фільми")]
        Movie,
        [Display(Name = "Серіали")]
        Series,
        [Display(Name = "Мультфільми", ShortName = "Мультф.")]
        AnimatedMovie,
        [Display(Name = "Мультсеріали", ShortName = "Мультс.")]    
        AnimatedSeries
    }
}
