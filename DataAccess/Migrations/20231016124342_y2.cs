using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class y2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductAttributes",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributes_ProductId",
                table: "ProductAttributes",
                newName: "IX_ProductAttributes_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Categories_CategoryId",
                table: "ProductAttributes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Categories_CategoryId",
                table: "ProductAttributes");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ProductAttributes",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributes_CategoryId",
                table: "ProductAttributes",
                newName: "IX_ProductAttributes_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
