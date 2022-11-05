using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreEndProject.Migrations
{
    public partial class AddDisCountColumnToProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DisCount",
                table: "Products",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisCount",
                table: "Products");
        }
    }
}
