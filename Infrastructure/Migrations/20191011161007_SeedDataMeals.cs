using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class SeedDataMeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Cooks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Hash",
                table: "Cooks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Cooks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Cooks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Cooks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "MealDishes",
                columns: table => new
                {
                    DishId = table.Column<int>(nullable: false),
                    MealId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealDishes", x => new { x.MealId, x.DishId });
                    table.ForeignKey(
                        name: "FK_MealDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealDishes_MealOptionals_MealId",
                        column: x => x.MealId,
                        principalTable: "MealOptionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MealOptionals",
                columns: new[] { "Id", "DateValid", "MenuId" },
                values: new object[] { -5, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_MealDishes_DishId",
                table: "MealDishes",
                column: "DishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealDishes");

            migrationBuilder.DeleteData(
                table: "MealOptionals",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Cooks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hash",
                table: "Cooks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Cooks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Cooks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Cooks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
