using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Task03.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenIDIssuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenIDSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brewery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EAN13 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoesFish = table.Column<bool>(type: "bit", nullable: true),
                    GoesMeat = table.Column<bool>(type: "bit", nullable: true),
                    GoesVeg = table.Column<bool>(type: "bit", nullable: true),
                    GoesBird = table.Column<bool>(type: "bit", nullable: true),
                    GoesDessert = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    BeerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Review_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Beers_BeerID",
                        column: x => x.BeerID,
                        principalTable: "Beers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_AccountID",
                table: "Review",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_BeerID",
                table: "Review",
                column: "BeerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Beers");
        }
    }
}
