using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateMealDishFK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MealId",
                table: "Dishes",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_MealOptionals_MealId",
                table: "Dishes",
                column: "MealId",
                principalTable: "MealOptionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_MealOptionals_MealId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_MealId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Dishes");
        }
    }
}
