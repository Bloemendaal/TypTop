using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TypTop.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "User",
                table => new
                {
                    UserId = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    LastLogin = table.Column<DateTime>(),
                    Teacher = table.Column<bool>(),
                    TeacherId = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_User", x => x.UserId); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "User");
        }
    }
}