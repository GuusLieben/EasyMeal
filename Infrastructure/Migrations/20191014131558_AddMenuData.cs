using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddMenuData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d4ee0397-20f7-4ef7-a49b-41581bd4ad32");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DietRestrictions",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "b44f9db1-49fd-4c52-8d6a-50de1f3593f7", 0, "ed137c8b-aa5e-4034-9207-dc0e6e0d47dd", "Cook", "h.d@avans.nl", false, false, null, null, null, null, null, false, null, false, "h.d@avans.nl", "Henk", "Dekker", null, "0612345678" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b44f9db1-49fd-4c52-8d6a-50de1f3593f7");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DietRestrictions",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "d4ee0397-20f7-4ef7-a49b-41581bd4ad32", 0, "6408fc76-a8d6-4610-a84f-9ecbf5b44b14", "Cook", "h.d@avans.nl", false, false, null, null, null, null, null, false, null, false, "h.d@avans.nl", "Henk", "Dekker", null, "0612345678" });
        }
    }
}
