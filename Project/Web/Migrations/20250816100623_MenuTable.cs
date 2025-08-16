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
                    Type = table.Column<string>(type: "TEXT", nullable: true)
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
                    { 1, "/Home/Index", "Home", "Main" },
                    { 2, "/Shop/Index", "Shop", "Main" },
                    { 3, "/Product/Details", "Product", "Main" },
                    { 4, "/Blog/Index", "Blog", "Main" },
                    { 5, "/Blog/Index", "Blog Pages", "Sub" },
                    { 6, "/Blog/Details", "Blog Details", "Sub" },
                    { 7, "/Cart/Index", "Cart", "Main" },
                    { 8, "/Checkout/Index", "Checkout", "Main" },
                    { 9, "#", "My Account", "Account" },
                    { 10, "#", "Login", "Account" },
                    { 11, "#", "Contact", "Account" }
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
