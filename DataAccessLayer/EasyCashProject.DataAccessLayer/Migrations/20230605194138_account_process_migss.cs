using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashProject.DataAccessLayer.Migrations
{
    public partial class account_process_migss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiverID",
                table: "AccountProcesses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderID",
                table: "AccountProcesses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountProcesses_ReceiverID",
                table: "AccountProcesses",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountProcesses_SenderID",
                table: "AccountProcesses",
                column: "SenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountProcesses_CustomerAccounts_ReceiverID",
                table: "AccountProcesses",
                column: "ReceiverID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountProcesses_CustomerAccounts_SenderID",
                table: "AccountProcesses",
                column: "SenderID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountProcesses_CustomerAccounts_ReceiverID",
                table: "AccountProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountProcesses_CustomerAccounts_SenderID",
                table: "AccountProcesses");

            migrationBuilder.DropIndex(
                name: "IX_AccountProcesses_ReceiverID",
                table: "AccountProcesses");

            migrationBuilder.DropIndex(
                name: "IX_AccountProcesses_SenderID",
                table: "AccountProcesses");

            migrationBuilder.DropColumn(
                name: "ReceiverID",
                table: "AccountProcesses");

            migrationBuilder.DropColumn(
                name: "SenderID",
                table: "AccountProcesses");
        }
    }
}
