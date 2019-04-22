using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFairway.Data.Migrations
{
    public partial class phonenumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AppUser",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2928383-e95a-43ce-bbf4-bd6694561f47", "8d7b2150-a796-43bb-b96c-d6496cf8ee4c", "Commissioner", "COMMISSIONER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff4f6015-9699-403c-b3a0-0464e53951e4", "b8ffeaff-9edb-43a5-a1ce-1297135d5e16", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59bfd146-c2d4-42a0-a876-68f81e8a4794", "0b5493ae-58e6-4274-a093-990a5aefadc9", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "59bfd146-c2d4-42a0-a876-68f81e8a4794", "0b5493ae-58e6-4274-a093-990a5aefadc9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b2928383-e95a-43ce-bbf4-bd6694561f47", "8d7b2150-a796-43bb-b96c-d6496cf8ee4c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ff4f6015-9699-403c-b3a0-0464e53951e4", "b8ffeaff-9edb-43a5-a1ce-1297135d5e16" });

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AppUser");

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
    }
}
