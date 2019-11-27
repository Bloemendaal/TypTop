***REMOVED***
using Microsoft.EntityFrameworkCore.Migrations;

***REMOVED***.Migrations
***REMOVED***
    public partial class InitialCreate : Migration
    ***REMOVED***
        protected override void Up(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                ***REMOVED***
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    Teacher = table.Column<bool>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                ***REMOVED***
                    table.PrimaryKey("PK_User", x => x.UserId);
            ***REMOVED***);
    ***REMOVED***

        protected override void Down(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.DropTable(
                name: "User");
    ***REMOVED***
***REMOVED***
***REMOVED***
