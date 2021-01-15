using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app.repository.Migrations
{
    public partial class Admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "issue",
                columns: table => new
                {
                    IssueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Problem = table.Column<string>(nullable: true),
                    ReorderedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issue", x => x.IssueID);
                });

            migrationBuilder.CreateTable(
                name: "destination",
                columns: table => new
                {
                    DestinationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueID = table.Column<int>(nullable: true),
                    RailStations = table.Column<string>(nullable: true),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    EstimatedTravelTime = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    Fare = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_destination", x => x.DestinationID);
                    table.ForeignKey(
                        name: "FK_destination_issue_IssueID",
                        column: x => x.IssueID,
                        principalTable: "issue",
                        principalColumn: "IssueID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountsID = table.Column<int>(nullable: true),
                    CardsID = table.Column<int>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true),
                    DestinationID = table.Column<int>(nullable: true),
                    BlockedUsers = table.Column<string>(nullable: true),
                    DisabledAccounts = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_admin_accounts_AccountsID",
                        column: x => x.AccountsID,
                        principalTable: "accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_admin_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_admin_cards_CardsID",
                        column: x => x.CardsID,
                        principalTable: "cards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_admin_destination_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "destination",
                        principalColumn: "DestinationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9297bda-5a7d-4b2f-9934-3ebf1839c7a2", "AQAAAAEAACcQAAAAELnjM/bg4HXOvWVpGpaULnxMpzQSs0S/f+EbaM1Im5CfeT7FnHfP8OdTZADrh10klw==", "c451781a-c6ef-4e3e-9781-0f13305867c0" });

            migrationBuilder.CreateIndex(
                name: "IX_admin_AccountsID",
                table: "admin",
                column: "AccountsID");

            migrationBuilder.CreateIndex(
                name: "IX_admin_AppUserId",
                table: "admin",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_admin_CardsID",
                table: "admin",
                column: "CardsID");

            migrationBuilder.CreateIndex(
                name: "IX_admin_DestinationID",
                table: "admin",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_destination_IssueID",
                table: "destination",
                column: "IssueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "destination");

            migrationBuilder.DropTable(
                name: "issue");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad30f529-3f32-47eb-b2fb-e1a9df157da3", "AQAAAAEAACcQAAAAEKV8t1OhvDruMgm8OGnkyhnG145nt+6aj0EQWM/A6UJE74pCuKFiIrv8CB8VHW+EBA==", "2816dbaa-233a-4855-82d4-61f1c27c8182" });
        }
    }
}
