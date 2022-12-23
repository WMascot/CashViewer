using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashViewer_backend.DAL.Migrations
{
    public partial class AddedShopType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Shops",
                newName: "TypeId");

            migrationBuilder.CreateTable(
                name: "ShopTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_TypeId",
                table: "Shops",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_ShopTypes_TypeId",
                table: "Shops",
                column: "TypeId",
                principalTable: "ShopTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_ShopTypes_TypeId",
                table: "Shops");

            migrationBuilder.DropTable(
                name: "ShopTypes");

            migrationBuilder.DropIndex(
                name: "IX_Shops_TypeId",
                table: "Shops");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Shops",
                newName: "Type");
        }
    }
}
