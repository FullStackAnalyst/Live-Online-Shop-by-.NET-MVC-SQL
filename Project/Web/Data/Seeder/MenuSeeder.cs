using Microsoft.EntityFrameworkCore;
using Web.Enums;
using Web.Models;

namespace Web.Data.Seeder;

public class MenuSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>().HasData(
            new Menu { Id = 1, Title = "Home", Link = "/Home/Index", Type = MenuType.Top },
            new Menu { Id = 2, Title = "Shop", Link = "/Shop/Index", Type = MenuType.Top },
            new Menu { Id = 3, Title = "Product", Link = "/Product/Details", Type = MenuType.Top },
            new Menu { Id = 4, Title = "Blog", Link = "/Blog/Index", Type = MenuType.Top },
            new Menu { Id = 7, Title = "Cart", Link = "/Cart/Index", Type = MenuType.Top },
            new Menu { Id = 8, Title = "Checkout", Link = "/Checkout/Index", Type = MenuType.Top },
            new Menu { Id = 12, Title = "Wishlist", Link = "/Wishlist/Index", Type = MenuType.Top },
            new Menu { Id = 5, Title = "Blog Pages", Link = "/Blog/Index", Type = MenuType.Sub },
            new Menu { Id = 6, Title = "Blog Details", Link = "/Blog/Details", Type = MenuType.Sub },
            new Menu { Id = 9, Title = "My Account", Link = "/Account/Index", Type = MenuType.Account },
            new Menu { Id = 10, Title = "Login", Link = "/Account/Login", Type = MenuType.Account },
            new Menu { Id = 11, Title = "Contact", Link = "/Contact/Index", Type = MenuType.Account },
            new Menu { Id = 14, Title = "Home", Link = "/Home/Index", Type = MenuType.Bottom },
            new Menu { Id = 15, Title = "Shop", Link = "/Shop/Index", Type = MenuType.Bottom },
            new Menu { Id = 16, Title = "Product", Link = "/Product/Details", Type = MenuType.Bottom },
            new Menu { Id = 17, Title = "Blog", Link = "/Blog/Index", Type = MenuType.Bottom }
        );
    }
}
