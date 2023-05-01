using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeApp.Infrastructure.Migrations
{
    public partial class UpdatedForbiddenIngredientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForbiddenIngredients_AspNetUsers_AppUserId",
                table: "ForbiddenIngredients");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ForbiddenIngredients",
                newName: "ExternalUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ForbiddenIngredients_AppUserId",
                table: "ForbiddenIngredients",
                newName: "IX_ForbiddenIngredients_ExternalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForbiddenIngredients_ExternalUsers_ExternalUserId",
                table: "ForbiddenIngredients",
                column: "ExternalUserId",
                principalTable: "ExternalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForbiddenIngredients_ExternalUsers_ExternalUserId",
                table: "ForbiddenIngredients");

            migrationBuilder.RenameColumn(
                name: "ExternalUserId",
                table: "ForbiddenIngredients",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ForbiddenIngredients_ExternalUserId",
                table: "ForbiddenIngredients",
                newName: "IX_ForbiddenIngredients_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForbiddenIngredients_AspNetUsers_AppUserId",
                table: "ForbiddenIngredients",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
