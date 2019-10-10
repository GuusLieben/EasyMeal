using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Meals : Migration
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
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DishId);
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
                name: "DietRestrictions",
                columns: table => new
                {
                    RestrictionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Setting = table.Column<int>(nullable: false),
                    DietRestrictions_RestrictionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietRestrictions", x => x.RestrictionId);
                    table.ForeignKey(
                        name: "FK_DietRestrictions_Dishes_DietRestrictions_RestrictionId",
                        column: x => x.DietRestrictions_RestrictionId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealOptionals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StarterId = table.Column<int>(nullable: false),
                    MainId = table.Column<int>(nullable: false),
                    DessertId = table.Column<int>(nullable: false),
                    DateValid = table.Column<DateTime>(nullable: false),
                    MenuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOptionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealOptionals_Dishes_DessertId",
                        column: x => x.DessertId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealOptionals_Dishes_MainId",
                        column: x => x.MainId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealOptionals_WeekMenus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "WeekMenus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealOptionals_Dishes_StarterId",
                        column: x => x.StarterId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_Email",
                table: "Cooks",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_DietRestrictions_DietRestrictions_RestrictionId",
                table: "DietRestrictions",
                column: "DietRestrictions_RestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Name",
                table: "Dishes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionals_DateValid",
                table: "MealOptionals",
                column: "DateValid");

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionals_DessertId",
                table: "MealOptionals",
                column: "DessertId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionals_MainId",
                table: "MealOptionals",
                column: "MainId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionals_MenuId",
                table: "MealOptionals",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionals_StarterId",
                table: "MealOptionals",
                column: "StarterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cooks");

            migrationBuilder.DropTable(
                name: "DietRestrictions");

            migrationBuilder.DropTable(
                name: "MealOptionals");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "WeekMenus");
        }
    }
}
