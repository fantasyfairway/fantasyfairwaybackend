using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFairway.Data.Migrations
{
    public partial class teamreqchang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "df0d3271-744d-4873-942d-0f6bad0a4f43", "14b41ca6-f2f9-48a6-96e9-7d011d972f96", "Commissioner", "COMMISSIONER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "227b09c1-13a0-44df-aa33-319cfdbec169", "af710f96-bf95-4ea0-b267-09e05971ee58", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6652d72e-8e53-400b-a355-8a0f5358b797", "b17878f0-30dc-4485-afe6-ae9b6ae3396f", "User", "USER" });
        }
    }
}
