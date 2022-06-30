using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.Migrations
{
    public partial class ManyToManyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingreadiants",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingreadiants", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Recipes_Ingreadiants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeID = table.Column<int>(type: "int", nullable: false),
                    IngreadiantName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes_Ingreadiants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recipes_Ingreadiants_Ingreadiants_IngreadiantName",
                        column: x => x.IngreadiantName,
                        principalTable: "Ingreadiants",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Ingreadiants_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Ingreadiants_IngreadiantName",
                table: "Recipes_Ingreadiants",
                column: "IngreadiantName");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Ingreadiants_RecipeID",
                table: "Recipes_Ingreadiants",
                column: "RecipeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes_Ingreadiants");

            migrationBuilder.DropTable(
                name: "Ingreadiants");
        }
    }
}
