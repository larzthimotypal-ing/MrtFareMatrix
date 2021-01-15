using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app.repository.Migrations
{
    public partial class Cards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(nullable: false),
                    AccountsID = table.Column<int>(nullable: true),
                    CardClassifications = table.Column<string>(maxLength: 50, nullable: true),
                    CreditPoints = table.Column<float>(nullable: false),
                    UsageNumber = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    StolenCards = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_cards_accounts_AccountsID",
                        column: x => x.AccountsID,
                        principalTable: "accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad30f529-3f32-47eb-b2fb-e1a9df157da3", "AQAAAAEAACcQAAAAEKV8t1OhvDruMgm8OGnkyhnG145nt+6aj0EQWM/A6UJE74pCuKFiIrv8CB8VHW+EBA==", "2816dbaa-233a-4855-82d4-61f1c27c8182" });

            migrationBuilder.CreateIndex(
                name: "IX_cards_AccountsID",
                table: "cards",
                column: "AccountsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cards");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4da428f1-9e25-47c7-9b58-2996997636c6", "AQAAAAEAACcQAAAAEIE0ncXCIdEnZwRme/CEF24IKs8qHLJ903bNma3FLtWzuBir1LdLTEPSJP/uQuJEdQ==", "3e20ff3b-5881-4ab2-9858-385aae43a91b" });
        }
    }
}
