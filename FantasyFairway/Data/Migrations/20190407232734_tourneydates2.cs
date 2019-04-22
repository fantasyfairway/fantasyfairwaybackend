using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFairway.Data.Migrations
{
    public partial class tourneydates2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Tournaments");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Tournaments",
                newName: "TournamentDates");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12e9bc01-f58f-461f-908c-be86354f8f4f", "b803a401-f4b2-43ed-b1dd-392734254304", "Commissioner", "COMMISSIONER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a8dd2c3-6cf5-4212-91e5-67431b771637", "6e7d23f2-5a21-4ae3-803b-c6d42df9cfbd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "854a6dc5-ef23-473c-980a-ea8c88fe9a0f", "da798bec-2f2c-4777-837b-96b0d8bb30a2", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "12e9bc01-f58f-461f-908c-be86354f8f4f", "b803a401-f4b2-43ed-b1dd-392734254304" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5a8dd2c3-6cf5-4212-91e5-67431b771637", "6e7d23f2-5a21-4ae3-803b-c6d42df9cfbd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "854a6dc5-ef23-473c-980a-ea8c88fe9a0f", "da798bec-2f2c-4777-837b-96b0d8bb30a2" });

            migrationBuilder.RenameColumn(
                name: "TournamentDates",
                table: "Tournaments",
                newName: "StartDate");

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                table: "Tournaments",
                nullable: false,
                defaultValue: "");

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
    }
}
