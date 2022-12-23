using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashViewer_backend.DAL.Migrations
{
    public partial class ShopUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Shops",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Shops");
        }
    }
}
