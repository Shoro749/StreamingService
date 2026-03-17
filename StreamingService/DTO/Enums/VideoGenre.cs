using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.Enums
{
    public enum VideoGenre
    {
        [Display(Name = "Бойовик")]
        Action,

        [Display(Name = "Пригоди")]
        Adventure,

        [Display(Name = "Комедія")]
        Comedy,

        [Display(Name = "Драма")]
        Drama,

        [Display(Name = "Жахи")]
        Horror,

        [Display(Name = "Фантастика")]
        SciFi,

        [Display(Name = "Фентезі")]
        Fantasy,

        [Display(Name = "Трилер")]
        Thriller,

        [Display(Name = "Сімейний")]
        Family,

        [Display(Name = "Документальний")]
        Documentary,

        [Display(Name = "Детектив")]
        Detective,

        [Display(Name = "Екшн")]
        ActionMovie, 

        [Display(Name = "Мелодрама")]
        Melodrama,

        [Display(Name = "Історичний")]
        Historical
    }
}
