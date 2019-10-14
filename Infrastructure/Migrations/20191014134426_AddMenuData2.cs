using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddMenuData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Menus_MenuId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MenuId",
                table: "Meals");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b44f9db1-49fd-4c52-8d6a-50de1f3593f7");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Menus",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Meals",
                table: "Menus",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "c7afa576-0de5-4aa6-9a26-a27c62e3ab05", 0, "5906c030-10bc-4585-aaeb-6f67e682a6c5", "Cook", "h.d@avans.nl", false, false, null, null, null, null, null, false, null, false, "h.d@avans.nl", "Henk", "Dekker", null, "0612345678" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7afa576-0de5-4aa6-9a26-a27c62e3ab05");

            migrationBuilder.DropColumn(
                name: "Meals",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Menus",
                newName: "MenuId");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Meals",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "b44f9db1-49fd-4c52-8d6a-50de1f3593f7", 0, "ed137c8b-aa5e-4034-9207-dc0e6e0d47dd", "Cook", "h.d@avans.nl", false, false, null, null, null, null, null, false, null, false, "h.d@avans.nl", "Henk", "Dekker", null, "0612345678" });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MenuId",
                table: "Meals",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Menus_MenuId",
                table: "Meals",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
