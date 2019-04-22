using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFairway.Data.Migrations
{
    public partial class tourneydates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0cbbb667-43ec-4c71-a3b0-32ade91924bd", "23633f77-c98c-4991-acc9-a16bfb4640e5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "517b3750-1754-4f99-a20b-0a2cfde57d19", "6ff8c90a-fc47-415f-bcd0-31a67a730a46" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "99291d34-c519-46e0-9c81-eb84836f4385", "7db9e05a-d3e2-4bb0-bcba-e0230866b2d6" });

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Tournaments",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Tournaments",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3a5350d3-0224-44c8-8b4d-fdbd1a38f219", "ff53cdd8-c732-4524-9b5e-0d559ea2fdc5", "Commissioner", "COMMISSIONER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d522b66-5da6-47ae-a016-0e3bae2faaf3", "1d37c912-ea97-46f3-b22f-7cd598418fa9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2b12461-7105-488f-a790-fdd0a4d1e3ae", "a314fd0a-9ad8-4365-8e06-424b213ba3f2", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3a5350d3-0224-44c8-8b4d-fdbd1a38f219", "ff53cdd8-c732-4524-9b5e-0d559ea2fdc5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8d522b66-5da6-47ae-a016-0e3bae2faaf3", "1d37c912-ea97-46f3-b22f-7cd598418fa9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d2b12461-7105-488f-a790-fdd0a4d1e3ae", "a314fd0a-9ad8-4365-8e06-424b213ba3f2" });

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Tournaments",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Tournaments",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "517b3750-1754-4f99-a20b-0a2cfde57d19", "6ff8c90a-fc47-415f-bcd0-31a67a730a46", "Commissioner", "COMMISSIONER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0cbbb667-43ec-4c71-a3b0-32ade91924bd", "23633f77-c98c-4991-acc9-a16bfb4640e5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99291d34-c519-46e0-9c81-eb84836f4385", "7db9e05a-d3e2-4bb0-bcba-e0230866b2d6", "User", "USER" });
        }
    }
}
