using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddImageUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a51b638-5b2b-4e42-bba3-a9a7e583236b");

            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "Dishes");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Dishes",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "c3119a66-f2b9-440a-abf9-35ba2ae661f1", 0, "0d412b7a-e4ff-4098-9f56-50a030a5bb09", "Cook", "h.d@avans.nl", false, false, null, null, null, null, null, false, null, false, "h.d@avans.nl", "Henk", "Dekker", null, "0612345678" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3119a66-f2b9-440a-abf9-35ba2ae661f1");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Dishes");

            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "Dishes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "7a51b638-5b2b-4e42-bba3-a9a7e583236b", 0, "5036e27c-d22b-4f9f-abe6-c88514d78d14", "Cook", "h.d@avans.nl", false, false, null, null, null, null, null, false, null, false, "h.d@avans.nl", "Henk", "Dekker", null, "0612345678" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: -4,
                column: "ImageUri",
                value: "google.com");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: -3,
                column: "ImageUri",
                value: "google.com");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: -2,
                column: "ImageUri",
                value: "google.com");
        }
    }
}
