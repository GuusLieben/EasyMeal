using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddMenuDataAltered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7afa576-0de5-4aa6-9a26-a27c62e3ab05");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "f2a07c42-e2a6-45ce-8024-b4211eab9ea2", 0, "f937054a-7706-4cf7-9cdf-b919c015469f", "Cook", "h.d@avans.nl", false, false, null, null, null, null, null, false, null, false, "h.d@avans.nl", "Henk", "Dekker", null, "0612345678" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Meals", "Week" },
                values: new object[] { -6, "[-5]", new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2a07c42-e2a6-45ce-8024-b4211eab9ea2");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "c7afa576-0de5-4aa6-9a26-a27c62e3ab05", 0, "5906c030-10bc-4585-aaeb-6f67e682a6c5", "Cook", "h.d@avans.nl", false, false, null, null, null, null, null, false, null, false, "h.d@avans.nl", "Henk", "Dekker", null, "0612345678" });
        }
    }
}
