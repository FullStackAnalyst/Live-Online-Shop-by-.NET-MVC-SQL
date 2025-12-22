using Web.Enums;

namespace Web.Models;

public class Menu
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Link { get; set; }

    public MenuType Type { get; set; }
}