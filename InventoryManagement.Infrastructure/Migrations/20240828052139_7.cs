using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "productName",
                table: "products",
                newName: "ProductName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "products",
                newName: "productName");
        }
    }
}
