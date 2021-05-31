using Microsoft.EntityFrameworkCore.Migrations;

namespace Catologo_Blazor.Server.Migrations
{
    public partial class AjusteImageProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Produtos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "Produtos",
                type: "nvarchar(260)",
                maxLength: 260,
                nullable: true);
        }
    }
}
