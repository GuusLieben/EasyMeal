using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemoveFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietRestrictions_Dishes_DietRestrictions_RestrictionId",
                table: "DietRestrictions");

            migrationBuilder.RenameColumn(
                name: "DietRestrictions_RestrictionId",
                table: "DietRestrictions",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_DietRestrictions_DietRestrictions_RestrictionId",
                table: "DietRestrictions",
                newName: "IX_DietRestrictions_DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietRestrictions_Dishes_DishId",
                table: "DietRestrictions",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietRestrictions_Dishes_DishId",
                table: "DietRestrictions");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "DietRestrictions",
                newName: "DietRestrictions_RestrictionId");

            migrationBuilder.RenameIndex(
                name: "IX_DietRestrictions_DishId",
                table: "DietRestrictions",
                newName: "IX_DietRestrictions_DietRestrictions_RestrictionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietRestrictions_Dishes_DietRestrictions_RestrictionId",
                table: "DietRestrictions",
                column: "DietRestrictions_RestrictionId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
