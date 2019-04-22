using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFairway.Data.Migrations
{
    public partial class playerteamfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeam_Teams_PlayerForeignKey",
                table: "PlayerTeam");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "545c18cb-eb57-46a6-8255-f2ff56c64716", "21e38910-efea-451d-ba05-19c4964586ae" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6cb334e1-66d8-4595-aefb-c18a8580e16f", "5f55d729-08b6-4464-aca0-147da7c61ec4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e52c4832-499a-4289-98a2-e60d85fc4773", "baac4f46-4f61-4bd0-a90b-812fbd0da0fc" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3a32dd96-dfc3-4022-8978-870a3f8dd578", "0754c50b-368d-4ae8-aecb-3a4eaef08cd9", "Commissioner", "COMMISSIONER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b131ddd0-2ef6-4647-b3ae-f5691de10b6b", "25b39fb8-6a1b-47e5-9293-025da07f443e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab31c20d-7798-44d0-b4ef-bc2ecb986ab9", "17901f3a-a1ea-4236-8d53-b2773f235f82", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeam_TeamForeignKey",
                table: "PlayerTeam",
                column: "TeamForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeam_Teams_TeamForeignKey",
                table: "PlayerTeam",
                column: "TeamForeignKey",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeam_Teams_TeamForeignKey",
                table: "PlayerTeam");

            migrationBuilder.DropIndex(
                name: "IX_PlayerTeam_TeamForeignKey",
                table: "PlayerTeam");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3a32dd96-dfc3-4022-8978-870a3f8dd578", "0754c50b-368d-4ae8-aecb-3a4eaef08cd9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ab31c20d-7798-44d0-b4ef-bc2ecb986ab9", "17901f3a-a1ea-4236-8d53-b2773f235f82" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b131ddd0-2ef6-4647-b3ae-f5691de10b6b", "25b39fb8-6a1b-47e5-9293-025da07f443e" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e52c4832-499a-4289-98a2-e60d85fc4773", "baac4f46-4f61-4bd0-a90b-812fbd0da0fc", "Commissioner", "COMMISSIONER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "545c18cb-eb57-46a6-8255-f2ff56c64716", "21e38910-efea-451d-ba05-19c4964586ae", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6cb334e1-66d8-4595-aefb-c18a8580e16f", "5f55d729-08b6-4464-aca0-147da7c61ec4", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeam_Teams_PlayerForeignKey",
                table: "PlayerTeam",
                column: "PlayerForeignKey",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
