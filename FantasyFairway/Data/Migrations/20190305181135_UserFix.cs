using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FantasyFairway.Data.Migrations
{
    public partial class UserFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Players_PlayerForeignKey",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLeagues_AspNetUsers_UserForeignKey",
                table: "UserLeagues");

            migrationBuilder.DropIndex(
                name: "IX_UserLeagues_UserForeignKey",
                table: "UserLeagues");

            migrationBuilder.DropIndex(
                name: "IX_Teams_PlayerForeignKey",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "UserForeignKey",
                table: "UserLeagues");

            migrationBuilder.DropColumn(
                name: "PlayerForeignKey",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "AppUserForeignKey",
                table: "UserLeagues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LeagueName",
                table: "Leagues",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    PictureURL = table.Column<string>(nullable: true),
                    IdentityUserForeignKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_AspNetUsers_IdentityUserForeignKey",
                        column: x => x.IdentityUserForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTeam",
                columns: table => new
                {
                    PlayerTeamID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TeamForeignKey = table.Column<int>(nullable: false),
                    PlayerForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeam", x => x.PlayerTeamID);
                    table.ForeignKey(
                        name: "FK_PlayerTeam_Players_PlayerForeignKey",
                        column: x => x.PlayerForeignKey,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTeam_Teams_PlayerForeignKey",
                        column: x => x.PlayerForeignKey,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLeagues_AppUserForeignKey",
                table: "UserLeagues",
                column: "AppUserForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_IdentityUserForeignKey",
                table: "AppUser",
                column: "IdentityUserForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeam_PlayerForeignKey",
                table: "PlayerTeam",
                column: "PlayerForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLeagues_AppUser_AppUserForeignKey",
                table: "UserLeagues",
                column: "AppUserForeignKey",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLeagues_AppUser_AppUserForeignKey",
                table: "UserLeagues");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "PlayerTeam");

            migrationBuilder.DropIndex(
                name: "IX_UserLeagues_AppUserForeignKey",
                table: "UserLeagues");

            migrationBuilder.DropColumn(
                name: "AppUserForeignKey",
                table: "UserLeagues");

            migrationBuilder.AddColumn<string>(
                name: "UserForeignKey",
                table: "UserLeagues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerForeignKey",
                table: "Teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LeagueName",
                table: "Leagues",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_UserLeagues_UserForeignKey",
                table: "UserLeagues",
                column: "UserForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PlayerForeignKey",
                table: "Teams",
                column: "PlayerForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Players_PlayerForeignKey",
                table: "Teams",
                column: "PlayerForeignKey",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLeagues_AspNetUsers_UserForeignKey",
                table: "UserLeagues",
                column: "UserForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
