using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolSystem.Database.Migrations
{
    public partial class AddScope : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "CmsUsers");

            migrationBuilder.AddColumn<int>(
                name: "Scope",
                table: "CmsUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scope",
                table: "CmsUsers");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "CmsUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
