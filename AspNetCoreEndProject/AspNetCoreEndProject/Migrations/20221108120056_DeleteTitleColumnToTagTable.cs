using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreEndProject.Migrations
{
    public partial class DeleteTitleColumnToTagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
