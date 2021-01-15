using Microsoft.EntityFrameworkCore.Migrations;

namespace app.repository.Migrations
{
    public partial class Issue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00c32901-a10e-4574-b0f9-f7f7ac43d7d4", "AQAAAAEAACcQAAAAEIsamAwkdelwfv8bR9TePFGch9rseVLdnyzwXSm7ZQ8Jo3WbBPdCLlwz0OjWKcW7nQ==", "0e0e3376-01f4-45bf-adfe-1d98646e5057" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f8f6341-08da-431d-bed9-5f3605f12378", "AQAAAAEAACcQAAAAELP+TkX5b2bR6JWjn6djZk6imkaVeJYR7h/XptUDTiEDU3N9+Jig9C+3R5iTR8sxiQ==", "ad546ed7-024b-4111-b9fe-4c3ab16844f7" });
        }
    }
}
