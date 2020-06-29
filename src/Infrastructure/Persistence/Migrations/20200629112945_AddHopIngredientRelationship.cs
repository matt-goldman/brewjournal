using Microsoft.EntityFrameworkCore.Migrations;

namespace brewjournal.Infrastructure.Persistence.Migrations
{
    public partial class AddHopIngredientRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HopAdditions_IngredientId",
                table: "HopAdditions",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_HopAdditions_Ingredients_IngredientId",
                table: "HopAdditions",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopAdditions_Ingredients_IngredientId",
                table: "HopAdditions");

            migrationBuilder.DropIndex(
                name: "IX_HopAdditions_IngredientId",
                table: "HopAdditions");
        }
    }
}
