using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFairway.Data.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c39baa1-3127-4905-8eed-b2c98e9295a6", "122db8c3-bfd6-4cf8-bb9a-90524fde3169", "Commissioner", "COMMISSIONER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d59b2b87-5695-4b85-a1f6-f2c18ad58bba", "8025c3b6-fe43-47bc-a893-8aaf7f7928df", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "06eca5e5-6bf6-44fe-9734-8b24a103852d", "f20a9815-86ae-4b61-abce-5a851522cde0", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "06eca5e5-6bf6-44fe-9734-8b24a103852d", "f20a9815-86ae-4b61-abce-5a851522cde0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2c39baa1-3127-4905-8eed-b2c98e9295a6", "122db8c3-bfd6-4cf8-bb9a-90524fde3169" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d59b2b87-5695-4b85-a1f6-f2c18ad58bba", "8025c3b6-fe43-47bc-a893-8aaf7f7928df" });
        }
    }
}
