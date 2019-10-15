using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cooks",
                keyColumn: "CookId",
                keyValue: "beta");

            migrationBuilder.RenameColumn(
                name: "CookId",
                table: "Cooks",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Cooks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Cooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cooks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Cooks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Cooks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Cooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Cooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Cooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Cooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cook_PhoneNumber",
                table: "Cooks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Cooks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Cooks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Cooks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Cooks",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Cooks",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Hash", "PasswordHash", "Cook_PhoneNumber", "PhoneNumberConfirmed", "PhoneNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2c63047e-0a1d-445b-aab1-1a59b9810bad", 0, "2b39e3b4-37a3-4e5d-9696-6118dfe93577", "h.d@avans.nl", false, "Henk", "Dekker", false, null, null, null, "1234", null, null, false, "0612345678", null, false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: "2c63047e-0a1d-445b-aab1-1a59b9810bad");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "Cook_PhoneNumber",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Cooks");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cooks",
                newName: "CookId");

            migrationBuilder.InsertData(
                table: "Cooks",
                columns: new[] { "CookId", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "beta", "Henk", "Dekker", "1234", "0612345678" });
        }
    }
}
