using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeApp.Infrastructure.Migrations
{
    public partial class AddedSummaryPropertyToRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Recipes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Recipes");
        }
    }
}
