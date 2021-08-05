using Microsoft.EntityFrameworkCore.Migrations;

namespace Blazor_Catalogo.Server.Migrations
{
    public partial class AddMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9bdc0758-4154-45c8-bc04-c07bd70e41d0", "a5040c35-fded-4cc8-a932-299139c2aeb5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bc268a4-671c-4f54-afbe-5709647a31ac", "0fa04f78-f43e-4468-86e3-0b03278c7581", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bc268a4-671c-4f54-afbe-5709647a31ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bdc0758-4154-45c8-bc04-c07bd70e41d0");
        }
    }
}
