using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFairway.Data.Migrations
{
    public partial class playerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "854117bd-158d-4d18-aeef-8fc960947e2d", "f527462c-4a8d-42f7-bcdc-b75e4206386e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9ee57c09-0c00-4576-9960-066bf4301bf5", "fc3265a8-e34f-4b81-9f05-3d850d141b3a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c4384ea6-cf93-46ae-ab2e-08799f58926c", "ea143b44-50a8-4e37-8a9b-8e6e3d034e18" });

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Players",
                newName: "PlayerName");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "PlayerName",
                table: "Players",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Players",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4384ea6-cf93-46ae-ab2e-08799f58926c", "ea143b44-50a8-4e37-8a9b-8e6e3d034e18", "Commissioner", "COMMISSIONER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "854117bd-158d-4d18-aeef-8fc960947e2d", "f527462c-4a8d-42f7-bcdc-b75e4206386e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ee57c09-0c00-4576-9960-066bf4301bf5", "fc3265a8-e34f-4b81-9f05-3d850d141b3a", "User", "USER" });
        }
    }
}
