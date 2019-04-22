using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFairway.Data.Migrations
{
    public partial class dbfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Earnings",
                table: "TournamentPlayer");

            migrationBuilder.DropColumn(
                name: "FedexPoints",
                table: "TournamentPlayer");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Players",
                newName: "Value");

            migrationBuilder.AddColumn<int>(
                name: "RoundFour",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoundOne",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoundThree",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoundTwo",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TournamentTotal",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Leagues",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Leagues",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RoundFour",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RoundOne",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RoundThree",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RoundTwo",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TournamentTotal",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Leagues");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Players",
                newName: "Age");

            migrationBuilder.AddColumn<int>(
                name: "Earnings",
                table: "TournamentPlayer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FedexPoints",
                table: "TournamentPlayer",
                nullable: false,
                defaultValue: 0);

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
    }
}
