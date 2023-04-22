using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebForSell.Migrations
{
    public partial class initProductImage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImage2",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage2",
                table: "Product");
        }
    }
}
