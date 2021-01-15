using Microsoft.EntityFrameworkCore.Migrations;

namespace app.repository.Migrations
{
    public partial class Destination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f8f6341-08da-431d-bed9-5f3605f12378", "AQAAAAEAACcQAAAAELP+TkX5b2bR6JWjn6djZk6imkaVeJYR7h/XptUDTiEDU3N9+Jig9C+3R5iTR8sxiQ==", "ad546ed7-024b-4111-b9fe-4c3ab16844f7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9297bda-5a7d-4b2f-9934-3ebf1839c7a2", "AQAAAAEAACcQAAAAELnjM/bg4HXOvWVpGpaULnxMpzQSs0S/f+EbaM1Im5CfeT7FnHfP8OdTZADrh10klw==", "c451781a-c6ef-4e3e-9781-0f13305867c0" });
        }
    }
}
