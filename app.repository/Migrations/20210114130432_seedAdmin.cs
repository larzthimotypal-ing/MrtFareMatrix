using Microsoft.EntityFrameworkCore.Migrations;

namespace app.repository.Migrations
{
    public partial class seedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "Role" },
                values: new object[] { "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 0, "bf909399-d382-4854-9fff-eef96a3eba65", "AppUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEL4EKxepSoT/U1h/7+7C/LNhxQDjPF36U7MHWFjzGq5Nqt+FRmcKCHBybMPS3dJiVA==", null, false, "1d05dc29-ccfe-4911-8f7d-f816eb547981", false, "admin", "admin", "admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6");
        }
    }
}
