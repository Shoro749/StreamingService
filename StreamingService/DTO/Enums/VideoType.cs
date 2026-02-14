using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace StreamingService.DTO.Enums
{
    public enum VideoType
    {
        [Display(Name = "Фільми", Description = "Фільм")]
        Movie,
        [Display(Name = "Серіали", Description = "Серіал")]
        Series,
        [Display(Name = "Мультфільми", ShortName = "Мультф.", Description = "Мультфільм")]
        AnimatedMovie,
        [Display(Name = "Мультсеріали", ShortName = "Мультс.", Description = "Мультсеріал")]    
        AnimatedSeries
    }
}
