using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class MenuTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Link = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Link", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "/Home/Index", "Home", 0 },
                    { 2, "/Shop/Index", "Shop", 0 },
                    { 3, "/Product/Details", "Product", 0 },
                    { 4, "/Blog/Index", "Blog", 0 },
                    { 5, "/Blog/Index", "Blog Pages", 2 },
                    { 6, "/Blog/Details", "Blog Details", 2 },
                    { 7, "/Cart/Index", "Cart", 0 },
                    { 8, "/Checkout/Index", "Checkout", 0 },
                    { 9, "/Account/Index", "My Account", 3 },
                    { 10, "/Account/Login", "Login", 3 },
                    { 11, "/Contact/Index", "Contact", 3 },
                    { 12, "/Wishlist/Index", "Wishlist", 0 },
                    { 14, "/Home/Index", "Home", 1 },
                    { 15, "/Shop/Index", "Shop", 1 },
                    { 16, "/Product/Details", "Product", 1 },
                    { 17, "/Blog/Index", "Blog", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
