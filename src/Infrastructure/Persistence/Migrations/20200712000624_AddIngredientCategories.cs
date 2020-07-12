using Microsoft.EntityFrameworkCore.Migrations;

namespace brewjournal.Infrastructure.Persistence.Migrations
{
    public partial class AddIngredientCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientCategory_CategoryId",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientCategory",
                table: "IngredientCategory");

            migrationBuilder.RenameTable(
                name: "IngredientCategory",
                newName: "IngredientCategories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IngredientCategories",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientCategories",
                table: "IngredientCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientCategories_CategoryId",
                table: "Ingredients",
                column: "CategoryId",
                principalTable: "IngredientCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientCategories_CategoryId",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientCategories",
                table: "IngredientCategories");

            migrationBuilder.RenameTable(
                name: "IngredientCategories",
                newName: "IngredientCategory");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "IngredientCategory",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientCategory",
                table: "IngredientCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientCategory_CategoryId",
                table: "Ingredients",
                column: "CategoryId",
                principalTable: "IngredientCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
