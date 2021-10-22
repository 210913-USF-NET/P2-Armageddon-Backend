using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class PasswordToEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpponentId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "ChatHistory");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "Password");

            migrationBuilder.AddColumn<int>(
                name: "OpponentId",
                table: "Match",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "ChatHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
