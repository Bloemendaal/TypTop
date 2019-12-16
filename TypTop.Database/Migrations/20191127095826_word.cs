using Microsoft.EntityFrameworkCore.Migrations;

namespace TypTop.Database.Migrations
{
    public partial class word : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Word",
                table => new
                {
                    Letters = table.Column<string>()
                },
                constraints: table => { table.PrimaryKey("PK_Word", x => x.Letters); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Word");
        }
    }
}