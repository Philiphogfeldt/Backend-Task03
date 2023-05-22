using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Task03.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Beers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beers_AccountID",
                table: "Beers",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Accounts_AccountID",
                table: "Beers",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Accounts_AccountID",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_AccountID",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Beers");
        }
    }
}
