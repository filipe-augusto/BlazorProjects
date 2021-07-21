using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShop.Server.Migrations
{
    public partial class Inicial_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Cake",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "Sabor",
                table: "Cake",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Peso",
                table: "Cake",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Cake",
                newName: "Flavor");

            migrationBuilder.RenameColumn(
                name: "DiasParaVencimento",
                table: "Cake",
                newName: "DaysToExpiration");

            migrationBuilder.RenameColumn(
                name: "DataPreparacao",
                table: "Cake",
                newName: "PreparationDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Cake",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Cake",
                newName: "Peso");

            migrationBuilder.RenameColumn(
                name: "PreparationDate",
                table: "Cake",
                newName: "DataPreparacao");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cake",
                newName: "Sabor");

            migrationBuilder.RenameColumn(
                name: "Flavor",
                table: "Cake",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "DaysToExpiration",
                table: "Cake",
                newName: "DiasParaVencimento");
        }
    }
}
