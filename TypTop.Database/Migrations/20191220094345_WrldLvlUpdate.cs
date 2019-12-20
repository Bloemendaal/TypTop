using Microsoft.EntityFrameworkCore.Migrations;

namespace TypTop.Database.Migrations
{
    public partial class WrldLvlUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "World");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Level");

            migrationBuilder.AddColumn<string>(
                name: "Button",
                table: "World",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoverButton",
                table: "World",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Button",
                table: "World");

            migrationBuilder.DropColumn(
                name: "HoverButton",
                table: "World");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "World",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Level",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
