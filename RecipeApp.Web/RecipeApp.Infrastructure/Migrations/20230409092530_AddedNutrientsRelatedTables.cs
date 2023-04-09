using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeApp.Infrastructure.Migrations
{
    public partial class AddedNutrientsRelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nutrients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StoredIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExpirationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoredIngredients_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoredIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ForbiddenNutrients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RequiredPercentageOfDailyNeeds = table.Column<double>(type: "double", nullable: true),
                    NutrientId = table.Column<int>(type: "int", nullable: false),
                    ExternalUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForbiddenNutrients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForbiddenNutrients_ExternalUsers_ExternalUserId",
                        column: x => x.ExternalUserId,
                        principalTable: "ExternalUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForbiddenNutrients_Nutrients_NutrientId",
                        column: x => x.NutrientId,
                        principalTable: "Nutrients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NutrientIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    PercentOfDailyNeeds = table.Column<double>(type: "double", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    NutrientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrientIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutrientIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NutrientIngredients_Nutrients_NutrientId",
                        column: x => x.NutrientId,
                        principalTable: "Nutrients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ForbiddenNutrients_ExternalUserId",
                table: "ForbiddenNutrients",
                column: "ExternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ForbiddenNutrients_NutrientId",
                table: "ForbiddenNutrients",
                column: "NutrientId");

            migrationBuilder.CreateIndex(
                name: "IX_NutrientIngredients_IngredientId",
                table: "NutrientIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_NutrientIngredients_NutrientId",
                table: "NutrientIngredients",
                column: "NutrientId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredIngredients_AppUserId",
                table: "StoredIngredients",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredIngredients_IngredientId",
                table: "StoredIngredients",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForbiddenNutrients");

            migrationBuilder.DropTable(
                name: "NutrientIngredients");

            migrationBuilder.DropTable(
                name: "StoredIngredients");

            migrationBuilder.DropTable(
                name: "Nutrients");
        }
    }
}
