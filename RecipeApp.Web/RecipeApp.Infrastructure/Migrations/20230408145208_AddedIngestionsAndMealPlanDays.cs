using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeApp.Infrastructure.Migrations
{
    public partial class AddedIngestionsAndMealPlanDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Order = table.Column<int>(type: "int", nullable: false),
                    DishType = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingestions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MealPlanDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MealPlanId = table.Column<int>(type: "int", nullable: false),
                    IngestionId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Servings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlanDays_Ingestions_IngestionId",
                        column: x => x.IngestionId,
                        principalTable: "Ingestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealPlanDays_MealPlans_MealPlanId",
                        column: x => x.MealPlanId,
                        principalTable: "MealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDays_IngestionId",
                table: "MealPlanDays",
                column: "IngestionId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDays_MealPlanId",
                table: "MealPlanDays",
                column: "MealPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealPlanDays");

            migrationBuilder.DropTable(
                name: "Ingestions");
        }
    }
}
