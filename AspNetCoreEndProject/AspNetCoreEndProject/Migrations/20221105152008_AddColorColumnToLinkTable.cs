using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreEndProject.Migrations
{
    public partial class AddColorColumnToLinkTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Links",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Links");
        }
    }
}
