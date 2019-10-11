using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_MealOptionals_DishId1",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "DietRestrictions");

            migrationBuilder.DeleteData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "Dishes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DishId1",
                table: "Dishes",
                newName: "MealId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_DishId1",
                table: "Dishes",
                newName: "IX_Dishes_MealId");

            migrationBuilder.AddColumn<string>(
                name: "DietRestrictions",
                table: "Dishes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Cooks",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { -1, "h.d@gmail.com", "Henk", "Dekker", "1234", "0612345678" });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Description", "DietRestrictions", "DishSize", "Type", "ImageUri", "MealId", "Name", "Price" },
                values: new object[,]
                {
                    { -3, "A dish of meat or fish, thinly sliced or pounded thin, and served raw", "[]", 0, 0, "google.com", null, "Carpaccio", 5.7999999999999998 },
                    { -4, "A steak cut of beef taken from the smaller end of the tenderloin, or psoas major of the cow carcass", "[]", 1, 1, "google.com", null, "Filet Mignons", 28.300000000000001 },
                    { -2, "Moist, delicious layer cake with caramel icing", "[\"No salt\"]", 1, 2, "google.com", null, "Salted Caramel Cake", 3.9500000000000002 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_MealOptionals_MealId",
                table: "Dishes",
                column: "MealId",
                principalTable: "MealOptionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_MealOptionals_MealId",
                table: "Dishes");

            migrationBuilder.DeleteData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DropColumn(
                name: "DietRestrictions",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Dishes",
                newName: "DishId");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "Dishes",
                newName: "DishId1");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_MealId",
                table: "Dishes",
                newName: "IX_Dishes_DishId1");

            migrationBuilder.CreateTable(
                name: "DietRestrictions",
                columns: table => new
                {
                    RestrictionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DishId = table.Column<int>(nullable: true),
                    Setting = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietRestrictions", x => x.RestrictionId);
                    table.ForeignKey(
                        name: "FK_DietRestrictions_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cooks",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Hash", "PhoneNumber" },
                values: new object[] { 5, "h.d@gmail.com", "Henk", "Dekker", "1234", "0612345678" });

            migrationBuilder.CreateIndex(
                name: "IX_DietRestrictions_DishId",
                table: "DietRestrictions",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_MealOptionals_DishId1",
                table: "Dishes",
                column: "DishId1",
                principalTable: "MealOptionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
