using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateMealReferences2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_MealOptionals_MealId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_MealOptionals_MealId1",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_MealId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_MealId1",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "MealId1",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "DessertId",
                table: "MealOptionals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MainId",
                table: "MealOptionals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StarterId",
                table: "MealOptionals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionals_DessertId",
                table: "MealOptionals",
                column: "DessertId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionals_MainId",
                table: "MealOptionals",
                column: "MainId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionals_StarterId",
                table: "MealOptionals",
                column: "StarterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealOptionals_Dishes_DessertId",
                table: "MealOptionals",
                column: "DessertId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_MealOptionals_Dishes_DessertId",
                table: "MealOptionals");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOptionals_Dishes_MainId",
                table: "MealOptionals");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOptionals_Dishes_StarterId",
                table: "MealOptionals");

            migrationBuilder.DropIndex(
                name: "IX_MealOptionals_DessertId",
                table: "MealOptionals");

            migrationBuilder.DropIndex(
                name: "IX_MealOptionals_MainId",
                table: "MealOptionals");

            migrationBuilder.DropIndex(
                name: "IX_MealOptionals_StarterId",
                table: "MealOptionals");

            migrationBuilder.DropColumn(
                name: "DessertId",
                table: "MealOptionals");

            migrationBuilder.DropColumn(
                name: "MainId",
                table: "MealOptionals");

            migrationBuilder.DropColumn(
                name: "StarterId",
                table: "MealOptionals");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealId1",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MealId",
                table: "Dishes",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MealId1",
                table: "Dishes",
                column: "MealId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_MealOptionals_MealId",
                table: "Dishes",
                column: "MealId",
                principalTable: "MealOptionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_MealOptionals_MealId1",
                table: "Dishes",
                column: "MealId1",
                principalTable: "MealOptionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
