using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CookRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealDishes_MealOptionals_MealId",
                table: "MealDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOptionals_WeekMenus_MenuId",
                table: "MealOptionals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeekMenus",
                table: "WeekMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealOptionals",
                table: "MealOptionals");

            migrationBuilder.RenameTable(
                name: "WeekMenus",
                newName: "Menus");

            migrationBuilder.RenameTable(
                name: "MealOptionals",
                newName: "Meals");

            migrationBuilder.RenameIndex(
                name: "IX_MealOptionals_MenuId",
                table: "Meals",
                newName: "IX_Meals_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meals",
                table: "Meals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealDishes_Meals_MealId",
                table: "MealDishes",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Menus_MenuId",
                table: "Meals",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealDishes_Meals_MealId",
                table: "MealDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Menus_MenuId",
                table: "Meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meals",
                table: "Meals");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "WeekMenus");

            migrationBuilder.RenameTable(
                name: "Meals",
                newName: "MealOptionals");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_MenuId",
                table: "MealOptionals",
                newName: "IX_MealOptionals_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeekMenus",
                table: "WeekMenus",
                column: "MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealOptionals",
                table: "MealOptionals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealDishes_MealOptionals_MealId",
                table: "MealDishes",
                column: "MealId",
                principalTable: "MealOptionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOptionals_WeekMenus_MenuId",
                table: "MealOptionals",
                column: "MenuId",
                principalTable: "WeekMenus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
