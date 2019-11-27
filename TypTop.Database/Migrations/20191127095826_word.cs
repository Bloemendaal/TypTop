using Microsoft.EntityFrameworkCore.Migrations;

***REMOVED***.Migrations
***REMOVED***
    public partial class word : Migration
    ***REMOVED***
        protected override void Up(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                ***REMOVED***
                    Letters = table.Column<string>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                ***REMOVED***
                    table.PrimaryKey("PK_Word", x => x.Letters);
            ***REMOVED***);
    ***REMOVED***

        protected override void Down(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.DropTable(
                name: "Word");
    ***REMOVED***
***REMOVED***
***REMOVED***
