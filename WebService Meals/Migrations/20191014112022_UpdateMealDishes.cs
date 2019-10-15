using Microsoft.EntityFrameworkCore.Migrations;

namespace WebService_Meals.Migrations
{
    public partial class UpdateMealDishes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6f14beb-5800-465e-9beb-9a8339a460fd");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "81e22e94-67c2-4bc6-9648-f172d2e86142", 0, "03b8e62c-ebb1-4175-895e-eb7bbc40b356", "Cook", "h.d@avans.nl", false, false, null, null, null, null, null, false, null, false, "h.d@avans.nl", "Henk", "Dekker", null, "0612345678" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81e22e94-67c2-4bc6-9648-f172d2e86142");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "IdentityUser_PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "e6f14beb-5800-465e-9beb-9a8339a460fd", 0, "f852abae-f499-404b-9fe4-94734d0fd6c7", "Cook", "h.d@avans.nl", false, false, null, null, null, null, null, false, null, false, null, "Henk", "Dekker", null, "0612345678" });
        }
    }
}
