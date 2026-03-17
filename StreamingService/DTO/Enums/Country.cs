using System.ComponentModel.DataAnnotations;

namespace StreamingService.DTO.Enums;

public enum Country
{
    [Display(Name = "Грузія", ShortName = "Грузії")]
    Georgia,

    [Display(Name = "Данія", ShortName = "Данії")]
    Denmark,

    [Display(Name = "Естонія", ShortName = "Естонії")]
    Estonia,

    [Display(Name = "Латвія", ShortName = "Латвії")]
    Latvia,

    [Display(Name = "Литва", ShortName = "Литві")]
    Lithuania,

    [Display(Name = "Молдова", ShortName = "Молдові")]
    Moldova,

    [Display(Name = "Польща", ShortName = "Польщі")]
    Poland,

    [Display(Name = "Португалія", ShortName = "Португалії")]
    Portugal,

    [Display(Name = "Румунія", ShortName = "Румунії")]
    Romania,

    [Display(Name = "Словаччина", ShortName = "Словаччині")]
    Slovakia,

    [Display(Name = "Угорщина", ShortName = "Угорщині")]
    Hungary,

    [Display(Name = "Узбекистан", ShortName = "Узбекистані")]
    Uzbekistan,

    [Display(Name = "Україна", ShortName = "Україні")]
    Ukraine,

    [Display(Name = "Чехія", ShortName = "Чехії")]
    Czechia,

    [Display(Name = "Швейцарія", ShortName = "Швейцарії")]
    Switzerland
}
