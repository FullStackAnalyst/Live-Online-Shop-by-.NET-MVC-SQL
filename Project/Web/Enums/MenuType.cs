using System.ComponentModel.DataAnnotations;

namespace Web.Enums;

public enum MenuType
{
    [Display(Name = "Top Navigation")]
    Top,

    [Display(Name = "Bottom Navigation")]
    Bottom,

    [Display(Name = "Sub Navigation")]
    Sub,

    [Display(Name = "Account Section")]
    Account
}