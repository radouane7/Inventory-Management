using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_suppliers_SupplierID",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_suppliers",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "suppliers");

            migrationBuilder.RenameTable(
                name: "suppliers",
                newName: "Supplier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Supplier_SupplierID",
                table: "products",
                column: "SupplierID",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Supplier_SupplierID",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "suppliers");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_suppliers",
                table: "suppliers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_suppliers_SupplierID",
                table: "products",
                column: "SupplierID",
                principalTable: "suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
