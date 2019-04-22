using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFairway.Data.Migrations
{
    public partial class userCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "10e58279-4364-45ac-8f92-8518dfdddf30", "1c7ea3c7-df1e-4e01-8cb2-9ca92b7a0c3a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4f5c6ca1-4a87-4df0-b8a3-460a7ca7a3cb", "31849cb7-2ded-4d9a-ae7b-81d4ac4ee698" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d6f73693-1411-4c72-aac9-824457392045", "285406a3-5798-47f9-b877-ac671f2602ce" });

            migrationBuilder.AddColumn<int>(
                name: "userCount",
                table: "Leagues",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "userCount",
                table: "Leagues");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6f73693-1411-4c72-aac9-824457392045", "285406a3-5798-47f9-b877-ac671f2602ce", "Commissioner", "COMMISSIONER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "10e58279-4364-45ac-8f92-8518dfdddf30", "1c7ea3c7-df1e-4e01-8cb2-9ca92b7a0c3a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f5c6ca1-4a87-4df0-b8a3-460a7ca7a3cb", "31849cb7-2ded-4d9a-ae7b-81d4ac4ee698", "User", "USER" });
        }
    }
}
