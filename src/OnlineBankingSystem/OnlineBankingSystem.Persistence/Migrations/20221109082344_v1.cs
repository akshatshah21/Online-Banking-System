using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBankingSystem.Persistence.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_FromAccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_ToAccountId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ToAccountId",
                table: "Transactions",
                newName: "ToAccountAccountNumber");

            migrationBuilder.RenameColumn(
                name: "FromAccountId",
                table: "Transactions",
                newName: "FromAccountAccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ToAccountId",
                table: "Transactions",
                newName: "IX_Transactions_ToAccountAccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_FromAccountId",
                table: "Transactions",
                newName: "IX_Transactions_FromAccountAccountNumber");

            migrationBuilder.AddColumn<string>(
                name: "FromAccountNumber",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToAccountNumber",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_FromAccountAccountNumber",
                table: "Transactions",
                column: "FromAccountAccountNumber",
                principalTable: "BankAccounts",
                principalColumn: "AccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_ToAccountAccountNumber",
                table: "Transactions",
                column: "ToAccountAccountNumber",
                principalTable: "BankAccounts",
                principalColumn: "AccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_FromAccountAccountNumber",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_ToAccountAccountNumber",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FromAccountNumber",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ToAccountNumber",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ToAccountAccountNumber",
                table: "Transactions",
                newName: "ToAccountId");

            migrationBuilder.RenameColumn(
                name: "FromAccountAccountNumber",
                table: "Transactions",
                newName: "FromAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ToAccountAccountNumber",
                table: "Transactions",
                newName: "IX_Transactions_ToAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_FromAccountAccountNumber",
                table: "Transactions",
                newName: "IX_Transactions_FromAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_FromAccountId",
                table: "Transactions",
                column: "FromAccountId",
                principalTable: "BankAccounts",
                principalColumn: "AccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_ToAccountId",
                table: "Transactions",
                column: "ToAccountId",
                principalTable: "BankAccounts",
                principalColumn: "AccountNumber");
        }
    }
}
