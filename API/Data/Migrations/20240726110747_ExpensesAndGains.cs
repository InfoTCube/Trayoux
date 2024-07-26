using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExpensesAndGains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_AspNetUsers_AppUserId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Gain_AspNetUsers_AppUserId",
                table: "Gain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gain",
                table: "Gain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.RenameTable(
                name: "Gain",
                newName: "Gains");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Gains",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Gain_AppUserId",
                table: "Gains",
                newName: "IX_Gains_UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Expenses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_AppUserId",
                table: "Expenses",
                newName: "IX_Expenses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gains",
                table: "Gains",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gains_AspNetUsers_UserId",
                table: "Gains",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_UserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Gains_AspNetUsers_UserId",
                table: "Gains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gains",
                table: "Gains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "Gains",
                newName: "Gain");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Gain",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Gains_UserId",
                table: "Gain",
                newName: "IX_Gain_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Expense",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_UserId",
                table: "Expense",
                newName: "IX_Expense_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gain",
                table: "Gain",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_AspNetUsers_AppUserId",
                table: "Expense",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gain_AspNetUsers_AppUserId",
                table: "Gain",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
