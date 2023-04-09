using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeApp.Infrastructure.Migrations
{
    public partial class AddedMealPlansTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MealPlanDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FamilyId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlans_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealPlans_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_AppUserId",
                table: "MealPlans",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_FamilyId",
                table: "MealPlans",
                column: "FamilyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealPlans");
        }
    }
}
