using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Task03.Migrations
{
    public partial class eanUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Accounts_AccountID",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Beers_BeerID",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "EanCode",
                table: "Beers");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Review_BeerID",
                table: "Reviews",
                newName: "IX_Reviews_BeerID");

            migrationBuilder.RenameIndex(
                name: "IX_Review_AccountID",
                table: "Reviews",
                newName: "IX_Reviews_AccountID");

            migrationBuilder.AddColumn<string>(
                name: "EAN13",
                table: "Beers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Accounts_AccountID",
                table: "Reviews",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Beers_BeerID",
                table: "Reviews",
                column: "BeerID",
                principalTable: "Beers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Accounts_AccountID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Beers_BeerID",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "EAN13",
                table: "Beers");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BeerID",
                table: "Review",
                newName: "IX_Review_BeerID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_AccountID",
                table: "Review",
                newName: "IX_Review_AccountID");

            migrationBuilder.AddColumn<string>(
                name: "EanCode",
                table: "Beers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Accounts_AccountID",
                table: "Review",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Beers_BeerID",
                table: "Review",
                column: "BeerID",
                principalTable: "Beers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
