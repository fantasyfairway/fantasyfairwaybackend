using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FantasyFairway.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LeagueName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TournamentName = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentID);
                });

            migrationBuilder.CreateTable(
                name: "UserLeagues",
                columns: table => new
                {
                    UserLeagueID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserForeignKey = table.Column<string>(nullable: true),
                    LeagueForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLeagues", x => x.UserLeagueID);
                    table.ForeignKey(
                        name: "FK_UserLeagues_Leagues_LeagueForeignKey",
                        column: x => x.LeagueForeignKey,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLeagues_AspNetUsers_UserForeignKey",
                        column: x => x.UserForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TeamName = table.Column<string>(nullable: false),
                    TeamPar = table.Column<int>(nullable: false),
                    PlayerForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Players_PlayerForeignKey",
                        column: x => x.PlayerForeignKey,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentPlayer",
                columns: table => new
                {
                    TournamentPlayerID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Rank = table.Column<int>(nullable: false),
                    MoneyValue = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    ParValue = table.Column<int>(nullable: false),
                    RoundOne = table.Column<int>(nullable: false),
                    RoundTwo = table.Column<int>(nullable: false),
                    RoundThree = table.Column<int>(nullable: false),
                    RoundFour = table.Column<int>(nullable: false),
                    TournamentTotal = table.Column<int>(nullable: false),
                    Earnings = table.Column<int>(nullable: false),
                    FedexPoints = table.Column<int>(nullable: false),
                    TournamentForeignKey = table.Column<int>(nullable: false),
                    PlayerForeingKey = table.Column<int>(nullable: false),
                    PlayerForeignKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentPlayer", x => x.TournamentPlayerID);
                    table.ForeignKey(
                        name: "FK_TournamentPlayer_Players_PlayerForeignKey",
                        column: x => x.PlayerForeignKey,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentPlayer_Tournaments_TournamentForeignKey",
                        column: x => x.TournamentForeignKey,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLeagueTeamTournaments",
                columns: table => new
                {
                    UserLeagueTeamTournamentID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TeamForeignKey = table.Column<int>(nullable: false),
                    TournamentForeignKey = table.Column<int>(nullable: false),
                    UserLeagueForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLeagueTeamTournaments", x => x.UserLeagueTeamTournamentID);
                    table.ForeignKey(
                        name: "FK_UserLeagueTeamTournaments_Teams_TeamForeignKey",
                        column: x => x.TeamForeignKey,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLeagueTeamTournaments_Tournaments_TournamentForeignKey",
                        column: x => x.TournamentForeignKey,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLeagueTeamTournaments_UserLeagues_UserLeagueForeignKey",
                        column: x => x.UserLeagueForeignKey,
                        principalTable: "UserLeagues",
                        principalColumn: "UserLeagueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PlayerForeignKey",
                table: "Teams",
                column: "PlayerForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayer_PlayerForeignKey",
                table: "TournamentPlayer",
                column: "PlayerForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayer_TournamentForeignKey",
                table: "TournamentPlayer",
                column: "TournamentForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_UserLeagues_LeagueForeignKey",
                table: "UserLeagues",
                column: "LeagueForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_UserLeagues_UserForeignKey",
                table: "UserLeagues",
                column: "UserForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_UserLeagueTeamTournaments_TeamForeignKey",
                table: "UserLeagueTeamTournaments",
                column: "TeamForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_UserLeagueTeamTournaments_TournamentForeignKey",
                table: "UserLeagueTeamTournaments",
                column: "TournamentForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_UserLeagueTeamTournaments_UserLeagueForeignKey",
                table: "UserLeagueTeamTournaments",
                column: "UserLeagueForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TournamentPlayer");

            migrationBuilder.DropTable(
                name: "UserLeagueTeamTournaments");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "UserLeagues");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
