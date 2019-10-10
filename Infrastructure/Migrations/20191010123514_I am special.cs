using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Iamspecial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealOptionals_Dishes_MainId",
                table: "MealOptionals");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOptionals_Dishes_StarterId",
                table: "MealOptionals");

            migrationBuilder.AddForeignKey(
                name: "FK_MealOptionals_Dishes_MainId",
                table: "MealOptionals",
                column: "MainId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOptionals_Dishes_StarterId",
                table: "MealOptionals",
                column: "StarterId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealOptionals_Dishes_MainId",
                table: "MealOptionals");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOptionals_Dishes_StarterId",
                table: "MealOptionals");

            migrationBuilder.AddForeignKey(
                name: "FK_MealOptionals_Dishes_MainId",
                table: "MealOptionals",
                column: "MainId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOptionals_Dishes_StarterId",
                table: "MealOptionals",
                column: "StarterId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
