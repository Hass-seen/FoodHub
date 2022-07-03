using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.Migrations
{
    public partial class changerKeyOfRecieToName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Ingreadiants_Recipes_RecipeID",
                table: "Recipes_Ingreadiants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes_Ingreadiants",
                table: "Recipes_Ingreadiants");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_Ingreadiants_RecipeID",
                table: "Recipes_Ingreadiants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "Recipes_Ingreadiants");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Ingreadiants",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "RecipeName",
                table: "Recipes_Ingreadiants",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes_Ingreadiants",
                table: "Recipes_Ingreadiants",
                columns: new[] { "IngreadiantName", "RecipeName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Ingreadiants_RecipeName",
                table: "Recipes_Ingreadiants",
                column: "RecipeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Ingreadiants_Recipes_RecipeName",
                table: "Recipes_Ingreadiants",
                column: "RecipeName",
                principalTable: "Recipes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Ingreadiants_Recipes_RecipeName",
                table: "Recipes_Ingreadiants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes_Ingreadiants",
                table: "Recipes_Ingreadiants");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_Ingreadiants_RecipeName",
                table: "Recipes_Ingreadiants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeName",
                table: "Recipes_Ingreadiants");

            migrationBuilder.AddColumn<int>(
                name: "RecipeID",
                table: "Recipes_Ingreadiants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Ingreadiants",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes_Ingreadiants",
                table: "Recipes_Ingreadiants",
                columns: new[] { "IngreadiantName", "RecipeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Ingreadiants_RecipeID",
                table: "Recipes_Ingreadiants",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Ingreadiants_Recipes_RecipeID",
                table: "Recipes_Ingreadiants",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
