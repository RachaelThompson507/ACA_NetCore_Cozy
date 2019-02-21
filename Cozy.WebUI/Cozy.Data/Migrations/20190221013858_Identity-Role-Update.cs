using Microsoft.EntityFrameworkCore.Migrations;

namespace Cozy.Data.Migrations
{
    public partial class IdentityRoleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cb99499-6fa1-4083-ba5b-870dc464aa38", "1bab8cfe-18ae-4b96-b438-f0fe6435ff7f", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87931f87-fa85-44f1-84d5-d444c89affef", "7364f4b2-8f17-4f5a-bf47-312b74fb56ec", "Tenant", "TENANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "7cb99499-6fa1-4083-ba5b-870dc464aa38", "1bab8cfe-18ae-4b96-b438-f0fe6435ff7f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "87931f87-fa85-44f1-84d5-d444c89affef", "7364f4b2-8f17-4f5a-bf47-312b74fb56ec" });
        }
    }
}
