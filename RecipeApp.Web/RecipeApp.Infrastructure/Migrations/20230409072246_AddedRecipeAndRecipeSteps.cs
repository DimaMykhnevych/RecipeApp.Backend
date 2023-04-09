using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeApp.Infrastructure.Migrations
{
    public partial class AddedRecipeAndRecipeSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Calories = table.Column<double>(type: "double", nullable: false),
                    Carbs = table.Column<double>(type: "double", nullable: false),
                    Fat = table.Column<double>(type: "double", nullable: false),
                    Protein = table.Column<double>(type: "double", nullable: false),
                    ReadyInMinutes = table.Column<double>(type: "double", nullable: false),
                    Vegan = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Healthy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: true),
                    Servings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RecipeSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeSteps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDays_RecipeId",
                table: "MealPlanDays",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSteps_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlanDays_Recipes_RecipeId",
                table: "MealPlanDays",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlanDays_Recipes_RecipeId",
                table: "MealPlanDays");

            migrationBuilder.DropTable(
                name: "RecipeSteps");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_MealPlanDays_RecipeId",
                table: "MealPlanDays");
        }
    }
}
