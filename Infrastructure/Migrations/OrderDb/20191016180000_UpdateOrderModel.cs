using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.OrderDb
{
    public partial class UpdateOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ClientId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "Orders",
                newName: "DishId");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "HNAddition", "Birthdate", "City", "DietRestrictions", "FirstName", "HouseNumber", "LastName", "Hash", "PhoneNumber", "Street" },
                values: new object[] { "-1", 0, "1e519f03-10e7-4434-b1ac-a7ab7a4c8ba6", "Client", null, false, false, null, null, null, null, null, false, null, false, null, "A", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breda", "[]", "Guus", 16, "Lieben", null, null, "Lovensdijkstraat" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ClientId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-1");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "Orders",
                newName: "MealId");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
