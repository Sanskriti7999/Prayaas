using Microsoft.EntityFrameworkCore.Migrations;

namespace Prayaas_Website.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "userType",
                keyColumn: "UserTypeID",
                keyValue: 3,
                column: "UserType",
                value: "Admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "userType",
                keyColumn: "UserTypeID",
                keyValue: 3,
                column: "UserType",
                value: "Institution");
        }
    }
}
