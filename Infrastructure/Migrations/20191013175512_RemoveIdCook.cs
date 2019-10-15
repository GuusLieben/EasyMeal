using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemoveIdCook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cooks",
                table: "Cooks");

            migrationBuilder.DeleteData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cooks");

            migrationBuilder.AddColumn<string>(
                name: "CookId",
                table: "Cooks",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cooks",
                table: "Cooks",
                column: "CookId");

            migrationBuilder.InsertData(
                table: "Cooks",
                columns: new[] { "CookId", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { "beta", "Henk", "Dekker", "1234", "0612345678" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cooks",
                table: "Cooks");

            migrationBuilder.DeleteData(
                table: "Cooks",
                keyColumn: "CookId",
                keyValue: "beta");

            migrationBuilder.DropColumn(
                name: "CookId",
                table: "Cooks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cooks",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cooks",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cooks",
                table: "Cooks",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Cooks",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { -1, "h.d@gmail.com", "Henk", "Dekker", "1234", "0612345678" });
        }
    }
}
