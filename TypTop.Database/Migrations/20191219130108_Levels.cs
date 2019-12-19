using Microsoft.EntityFrameworkCore.Migrations;

namespace TypTop.Database.Migrations
{
    public partial class Levels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLevel",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LevelId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Stars = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLevel", x => new { x.UserId, x.LevelId });
                });

            migrationBuilder.CreateTable(
                name: "World",
                columns: table => new
                {
                    WorldId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Index = table.Column<int>(nullable: false),
                    Stars = table.Column<int>(nullable: false),
                    Background = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_World", x => x.WorldId);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    LevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorldId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Index = table.Column<int>(nullable: false),
                    WinCondition = table.Column<int>(nullable: false),
                    ThresholdOneStar = table.Column<int>(nullable: false),
                    ThresholdTwoStars = table.Column<int>(nullable: false),
                    ThresholdThreeStars = table.Column<int>(nullable: false),
                    Variables = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.LevelId);
                    table.ForeignKey(
                        name: "ForeignKey_Level_World",
                        column: x => x.WorldId,
                        principalTable: "World",
                        principalColumn: "WorldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Level_Index",
                table: "Level",
                column: "Index",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Level_WorldId",
                table: "Level",
                column: "WorldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "UserLevel");

            migrationBuilder.DropTable(
                name: "World");
        }
    }
}
