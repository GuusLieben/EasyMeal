using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateMDKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealDishes",
                table: "MealDishes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75fa7442-e6cb-46fd-b180-0c29fda1cbe5");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MealDishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealDishes",
                table: "MealDishes",
                columns: new[] { "MealId", "DishId", "Id" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "5017fe01-92ad-4aee-948a-7962edc535be", 0, "c5f6b126-ddb4-4e30-94eb-452d11f96051", "Cook", "h.d@avans.nl", false, false, null, null, null, null, null, false, null, false, "h.d@avans.nl", "Henk", "Dekker", null, "0612345678" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: -6,
                column: "Week",
                value: new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealDishes",
                table: "MealDishes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5017fe01-92ad-4aee-948a-7962edc535be");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MealDishes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealDishes",
                table: "MealDishes",
                columns: new[] { "MealId", "DishId" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "75fa7442-e6cb-46fd-b180-0c29fda1cbe5", 0, "05cf5b97-3e44-4108-a974-ce247734bdf1", "Cook", "h.d@avans.nl", false, false, null, null, null, null, null, false, null, false, "h.d@avans.nl", "Henk", "Dekker", null, "0612345678" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: -6,
                column: "Week",
                value: new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
