using Microsoft.EntityFrameworkCore.Migrations;

namespace app.repository.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3083e47c-48d6-48e8-9f77-4662d2b6659d", "AQAAAAEAACcQAAAAEJRNWjmZLgGUImEbgREvDbHdt6j2GnsLfYbxpU7F1OtSq3FVHNNa/k/gAL4UstJi2g==", "a1128880-289c-4f24-89b8-2c57f0b8a4a7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf909399-d382-4854-9fff-eef96a3eba65", "AQAAAAEAACcQAAAAEL4EKxepSoT/U1h/7+7C/LNhxQDjPF36U7MHWFjzGq5Nqt+FRmcKCHBybMPS3dJiVA==", "1d05dc29-ccfe-4911-8f7d-f816eb547981" });
        }
    }
}
