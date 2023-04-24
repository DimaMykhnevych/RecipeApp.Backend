using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeApp.Infrastructure.Migrations
{
    public partial class AddedConnectionBetweenRecipesAndAppUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_AppUserId",
                table: "Recipes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_AppUserId",
                table: "Recipes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_AppUserId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_AppUserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Recipes");
        }
    }
}
