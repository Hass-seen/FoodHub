using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.Migrations
{
    public partial class madecompositeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes_Ingreadiants",
                table: "Recipes_Ingreadiants");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_Ingreadiants_IngreadiantName",
                table: "Recipes_Ingreadiants");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Recipes_Ingreadiants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes_Ingreadiants",
                table: "Recipes_Ingreadiants",
                columns: new[] { "IngreadiantName", "RecipeID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes_Ingreadiants",
                table: "Recipes_Ingreadiants");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Recipes_Ingreadiants",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes_Ingreadiants",
                table: "Recipes_Ingreadiants",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Ingreadiants_IngreadiantName",
                table: "Recipes_Ingreadiants",
                column: "IngreadiantName");
        }
    }
}
