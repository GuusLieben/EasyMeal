using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class FirstVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Hash = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeekMenus",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Week = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekMenus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "MealOptionals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateValid = table.Column<DateTime>(nullable: false),
                    MenuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOptionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealOptionals_WeekMenus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "WeekMenus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    DishId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ImageUri = table.Column<string>(nullable: false),
                    DishSize = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    DishId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DishId);
                    table.ForeignKey(
                        name: "FK_Dishes_MealOptionals_DishId1",
                        column: x => x.DishId1,
                        principalTable: "MealOptionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DietRestrictions",
                columns: table => new
                {
                    RestrictionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Setting = table.Column<int>(nullable: false),
                    DishId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DishId1",
                table: "Dishes",
                column: "DishId1");

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionals_MenuId",
                table: "MealOptionals",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cooks");

            migrationBuilder.DropTable(
                name: "DietRestrictions");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "MealOptionals");

            migrationBuilder.DropTable(
                name: "WeekMenus");
        }
    }
}
