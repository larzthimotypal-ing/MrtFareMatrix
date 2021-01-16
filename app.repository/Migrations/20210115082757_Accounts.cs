using Microsoft.EntityFrameworkCore.Migrations;

namespace app.repository.Migrations
{
    public partial class Accounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleInitial = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4da428f1-9e25-47c7-9b58-2996997636c6", "AQAAAAEAACcQAAAAEIE0ncXCIdEnZwRme/CEF24IKs8qHLJ903bNma3FLtWzuBir1LdLTEPSJP/uQuJEdQ==", "3e20ff3b-5881-4ab2-9858-385aae43a91b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf909399-d382-4854-9fff-eef96a3eba65", "AQAAAAEAACcQAAAAEL4EKxepSoT/U1h/7+7C/LNhxQDjPF36U7MHWFjzGq5Nqt+FRmcKCHBybMPS3dJiVA==", "1d05dc29-ccfe-4911-8f7d-f816eb547981" });
        }
    }
}
