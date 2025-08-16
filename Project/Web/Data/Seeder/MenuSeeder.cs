using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data.Seeder;

public static class MenuSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>().HasData(
            new Menu { Id = 1, Title = "Home", Link = "/Home/Index", Type = "Main" },
            new Menu { Id = 2, Title = "Shop", Link = "/Shop/Index", Type = "Main" },
            new Menu { Id = 3, Title = "Product", Link = "/Product/Details", Type = "Main" },
            new Menu { Id = 4, Title = "Blog", Link = "/Blog/Index", Type = "Main" },
            new Menu { Id = 5, Title = "Blog Pages", Link = "/Blog/Index", Type = "Sub" },
            new Menu { Id = 6, Title = "Blog Details", Link = "/Blog/Details", Type = "Sub" },
            new Menu { Id = 7, Title = "Cart", Link = "/Cart/Index", Type = "Main" },
            new Menu { Id = 8, Title = "Checkout", Link = "/Checkout/Index", Type = "Main" },
            new Menu { Id = 9, Title = "My Account", Link = "#", Type = "Account" },
            new Menu { Id = 10, Title = "Login", Link = "#", Type = "Account" },
            new Menu { Id = 11, Title = "Contact", Link = "#", Type = "Account" }
        );
    }
}