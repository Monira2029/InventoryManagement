using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Inventories",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Inventories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SupplierId",
                table: "Inventories",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Suppliers_SupplierId",
                table: "Inventories",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Suppliers_SupplierId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_SupplierId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Inventories");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Inventories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
