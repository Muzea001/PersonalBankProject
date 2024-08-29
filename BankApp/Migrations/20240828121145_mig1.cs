using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankApp.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankName = table.Column<string>(type: "TEXT", nullable: false),
                    SumOfHoldings = table.Column<decimal>(type: "TEXT", nullable: false),
                    SumOfDebt = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Member = table.Column<bool>(type: "INTEGER", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountType = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    DebtSum = table.Column<decimal>(type: "TEXT", nullable: false),
                    LoanId = table.Column<int>(type: "INTEGER", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: false),
                    userId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Bank_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Bank",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    RentPercentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    totalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Loans_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Downpayments",
                columns: table => new
                {
                    DownpaymentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoanId = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Downpayments", x => x.DownpaymentId);
                    table.ForeignKey(
                        name: "FK_Downpayments_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    isDeposit = table.Column<bool>(type: "INTEGER", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    isLoan = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsProcessed = table.Column<bool>(type: "INTEGER", nullable: false),
                    DownpaymentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Downpayments_DownpaymentId",
                        column: x => x.DownpaymentId,
                        principalTable: "Downpayments",
                        principalColumn: "DownpaymentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "accountTransactions",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountTransactions", x => new { x.AccountId, x.TransactionId });
                    table.ForeignKey(
                        name: "FK_accountTransactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accountTransactions_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "BankId", "BankName", "SumOfDebt", "SumOfHoldings" },
                values: new object[] { 1, "MyBank1", 0m, 100000000m });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "DownpaymentId", "IsProcessed", "TransactionAmount", "TransactionDate", "isDeposit", "isLoan" },
                values: new object[] { 1, null, true, 1000m, new DateTime(2024, 8, 28, 14, 11, 45, 12, DateTimeKind.Local).AddTicks(3677), true, false });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BankId", "Member", "UserName" },
                values: new object[,]
                {
                    { 1, 1, false, "Mike Smith" },
                    { 2, 1, true, "John Johnson" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountType", "Balance", "BankId", "DebtSum", "LoanId", "userId" },
                values: new object[,]
                {
                    { 1, "Regular", 0m, 1, 0m, 0, 1 },
                    { 2, "Savings", 0m, 1, 0m, 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanId", "AccountId", "BankId", "DeadLine", "RentPercentage", "totalAmount" },
                values: new object[] { 1, 1, 1, new DateTime(2026, 8, 28, 14, 11, 45, 12, DateTimeKind.Local).AddTicks(3618), 5m, 150.000m });

            migrationBuilder.InsertData(
                table: "accountTransactions",
                columns: new[] { "AccountId", "TransactionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Downpayments",
                columns: new[] { "DownpaymentId", "LoanId", "TransactionId" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "DownpaymentId", "IsProcessed", "TransactionAmount", "TransactionDate", "isDeposit", "isLoan" },
                values: new object[] { 2, 1, true, 2000m, new DateTime(2024, 8, 28, 14, 11, 45, 12, DateTimeKind.Local).AddTicks(3681), false, true });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_userId",
                table: "Accounts",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_accountTransactions_TransactionId",
                table: "accountTransactions",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Downpayments_LoanId",
                table: "Downpayments",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_AccountId",
                table: "Loans",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BankId",
                table: "Loans",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DownpaymentId",
                table: "Transactions",
                column: "DownpaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BankId",
                table: "Users",
                column: "BankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountTransactions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Downpayments");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Bank");
        }
    }
}
