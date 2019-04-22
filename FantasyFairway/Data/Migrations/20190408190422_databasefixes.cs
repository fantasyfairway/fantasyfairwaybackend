using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFairway.Data.Migrations
{
    public partial class databasefixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "TournamentScore",
                table: "UserLeagueTeamTournaments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamForeignKey",
                table: "UserLeagues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df0d3271-744d-4873-942d-0f6bad0a4f43", "14b41ca6-f2f9-48a6-96e9-7d011d972f96", "Commissioner", "COMMISSIONER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "227b09c1-13a0-44df-aa33-319cfdbec169", "af710f96-bf95-4ea0-b267-09e05971ee58", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6652d72e-8e53-400b-a355-8a0f5358b797", "b17878f0-30dc-4485-afe6-ae9b6ae3396f", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLeagues_TeamForeignKey",
                table: "UserLeagues",
                column: "TeamForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLeagues_Teams_TeamForeignKey",
                table: "UserLeagues",
                column: "TeamForeignKey",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLeagues_Teams_TeamForeignKey",
                table: "UserLeagues");

            migrationBuilder.DropIndex(
                name: "IX_UserLeagues_TeamForeignKey",
                table: "UserLeagues");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "227b09c1-13a0-44df-aa33-319cfdbec169", "af710f96-bf95-4ea0-b267-09e05971ee58" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6652d72e-8e53-400b-a355-8a0f5358b797", "b17878f0-30dc-4485-afe6-ae9b6ae3396f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "df0d3271-744d-4873-942d-0f6bad0a4f43", "14b41ca6-f2f9-48a6-96e9-7d011d972f96" });

            migrationBuilder.DropColumn(
                name: "TournamentScore",
                table: "UserLeagueTeamTournaments");

            migrationBuilder.DropColumn(
                name: "TeamForeignKey",
                table: "UserLeagues");

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
    }
}
