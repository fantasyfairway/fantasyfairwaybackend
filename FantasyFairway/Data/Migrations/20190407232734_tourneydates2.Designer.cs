﻿// <auto-generated />
using System;
using FantasyFairway.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FantasyFairway.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190407232734_tourneydates2")]
    partial class tourneydates2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FantasyFairway.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("FullName");

                    b.Property<string>("IdentityUserForeignKey");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PictureURL");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserForeignKey");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("FantasyFairway.Models.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("LeagueName")
                        .IsRequired();

                    b.Property<string>("Picture");

                    b.Property<int>("userCount");

                    b.HasKey("LeagueId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("FantasyFairway.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlayerName")
                        .IsRequired();

                    b.Property<int>("Rank");

                    b.Property<int>("RoundFour");

                    b.Property<int>("RoundOne");

                    b.Property<int>("RoundThree");

                    b.Property<int>("RoundTwo");

                    b.Property<int>("TournamentTotal");

                    b.Property<int>("Value");

                    b.HasKey("PlayerID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FantasyFairway.Models.PlayerTeam", b =>
                {
                    b.Property<int>("PlayerTeamID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlayerForeignKey");

                    b.Property<int>("TeamForeignKey");

                    b.HasKey("PlayerTeamID");

                    b.HasIndex("PlayerForeignKey");

                    b.ToTable("PlayerTeam");
                });

            modelBuilder.Entity("FantasyFairway.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TeamName")
                        .IsRequired();

                    b.Property<int>("TeamPar");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FantasyFairway.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TournamentDates")
                        .IsRequired();

                    b.Property<string>("TournamentName")
                        .IsRequired();

                    b.HasKey("TournamentID");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("FantasyFairway.Models.UserLeague", b =>
                {
                    b.Property<int>("UserLeagueID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppUserForeignKey");

                    b.Property<int>("LeagueForeignKey");

                    b.HasKey("UserLeagueID");

                    b.HasIndex("AppUserForeignKey");

                    b.HasIndex("LeagueForeignKey");

                    b.ToTable("UserLeagues");
                });

            modelBuilder.Entity("FantasyFairway.Models.UserLeagueTeamTournament", b =>
                {
                    b.Property<int>("UserLeagueTeamTournamentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TeamForeignKey");

                    b.Property<int>("TournamentForeignKey");

                    b.Property<int>("UserLeagueForeignKey");

                    b.HasKey("UserLeagueTeamTournamentID");

                    b.HasIndex("TeamForeignKey");

                    b.HasIndex("TournamentForeignKey");

                    b.HasIndex("UserLeagueForeignKey");

                    b.ToTable("UserLeagueTeamTournaments");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = "12e9bc01-f58f-461f-908c-be86354f8f4f", ConcurrencyStamp = "b803a401-f4b2-43ed-b1dd-392734254304", Name = "Commissioner", NormalizedName = "COMMISSIONER" },
                        new { Id = "5a8dd2c3-6cf5-4212-91e5-67431b771637", ConcurrencyStamp = "6e7d23f2-5a21-4ae3-803b-c6d42df9cfbd", Name = "Admin", NormalizedName = "ADMIN" },
                        new { Id = "854a6dc5-ef23-473c-980a-ea8c88fe9a0f", ConcurrencyStamp = "da798bec-2f2c-4777-837b-96b0d8bb30a2", Name = "User", NormalizedName = "USER" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TournamentPlayer", b =>
                {
                    b.Property<int>("TournamentPlayerID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("MoneyValue");

                    b.Property<int>("ParValue");

                    b.Property<int?>("PlayerForeignKey");

                    b.Property<int>("PlayerForeingKey");

                    b.Property<int>("Rank");

                    b.Property<int>("RoundFour");

                    b.Property<int>("RoundOne");

                    b.Property<int>("RoundThree");

                    b.Property<int>("RoundTwo");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<int>("TournamentForeignKey");

                    b.Property<int>("TournamentTotal");

                    b.HasKey("TournamentPlayerID");

                    b.HasIndex("PlayerForeignKey");

                    b.HasIndex("TournamentForeignKey");

                    b.ToTable("TournamentPlayer");
                });

            modelBuilder.Entity("FantasyFairway.Models.AppUser", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserForeignKey");
                });

            modelBuilder.Entity("FantasyFairway.Models.PlayerTeam", b =>
                {
                    b.HasOne("FantasyFairway.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FantasyFairway.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("PlayerForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FantasyFairway.Models.UserLeague", b =>
                {
                    b.HasOne("FantasyFairway.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FantasyFairway.Models.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FantasyFairway.Models.UserLeagueTeamTournament", b =>
                {
                    b.HasOne("FantasyFairway.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FantasyFairway.Models.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FantasyFairway.Models.UserLeague", "UserLeague")
                        .WithMany()
                        .HasForeignKey("UserLeagueForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TournamentPlayer", b =>
                {
                    b.HasOne("FantasyFairway.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerForeignKey");

                    b.HasOne("FantasyFairway.Models.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
