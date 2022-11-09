using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreEndProject.Migrations
{
    public partial class AddDescriptionSecondAndDescriptionThirdColumnToBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionSecond",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionThird",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionSecond",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "DescriptionThird",
                table: "Blogs");
        }
    }
}
