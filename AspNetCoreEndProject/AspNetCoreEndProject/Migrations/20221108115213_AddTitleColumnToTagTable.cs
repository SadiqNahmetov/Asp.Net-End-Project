using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreEndProject.Migrations
{
    public partial class AddTitleColumnToTagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tags",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tags");
        }
    }
}
