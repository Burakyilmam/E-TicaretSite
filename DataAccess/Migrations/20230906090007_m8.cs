using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class m8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MainCategory_MainCategoryId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainCategory",
                table: "MainCategory");

            migrationBuilder.RenameTable(
                name: "MainCategory",
                newName: "MainCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainCategories",
                table: "MainCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MainCategories_MainCategoryId",
                table: "Categories",
                column: "MainCategoryId",
                principalTable: "MainCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MainCategories_MainCategoryId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainCategories",
                table: "MainCategories");

            migrationBuilder.RenameTable(
                name: "MainCategories",
                newName: "MainCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainCategory",
                table: "MainCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MainCategory_MainCategoryId",
                table: "Categories",
                column: "MainCategoryId",
                principalTable: "MainCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
