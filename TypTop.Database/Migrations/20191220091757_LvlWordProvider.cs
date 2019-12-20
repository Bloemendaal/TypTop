using Microsoft.EntityFrameworkCore.Migrations;

namespace TypTop.Database.Migrations
{
    public partial class LvlWordProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WordProvider",
                table: "Level",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WordProvider",
                table: "Level");
        }
    }
}
