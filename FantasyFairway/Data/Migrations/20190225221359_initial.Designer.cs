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
    [Migration("20190225221359_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FantasyFairway.Models.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LeagueName");

                    b.HasKey("LeagueId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("FantasyFairway.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("Rank");

                    b.HasKey("PlayerID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FantasyFairway.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlayerForeignKey");

                    b.Property<string>("TeamName")
                        .IsRequired();

                    b.Property<int>("TeamPar");

                    b.HasKey("TeamID");

                    b.HasIndex("PlayerForeignKey");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FantasyFairway.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("TournamentName")
                        .IsRequired();

                    b.HasKey("TournamentID");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("FantasyFairway.Models.UserLeague", b =>
                {
                    b.Property<int>("UserLeagueID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LeagueForeignKey");

                    b.Property<string>("UserForeignKey");

                    b.HasKey("UserLeagueID");

                    b.HasIndex("LeagueForeignKey");

                    b.HasIndex("UserForeignKey");

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

                    b.Property<int>("Earnings");

                    b.Property<int>("FedexPoints");

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

            modelBuilder.Entity("FantasyFairway.Models.Team", b =>
                {
                    b.HasOne("FantasyFairway.Models.Player", "Player")
                        .WithMany("Teams")
                        .HasForeignKey("PlayerForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FantasyFairway.Models.UserLeague", b =>
                {
                    b.HasOne("FantasyFairway.Models.League", "League")
                        .WithMany("UserLeagues")
                        .HasForeignKey("LeagueForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "ApplicationUsers")
                        .WithMany()
                        .HasForeignKey("UserForeignKey");
                });

            modelBuilder.Entity("FantasyFairway.Models.UserLeagueTeamTournament", b =>
                {
                    b.HasOne("FantasyFairway.Models.Team", "Team")
                        .WithMany("UserLeagueTeamTournaments")
                        .HasForeignKey("TeamForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FantasyFairway.Models.Tournament", "Tournament")
                        .WithMany("UserLeagueTeamTournaments")
                        .HasForeignKey("TournamentForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FantasyFairway.Models.UserLeague", "UserLeague")
                        .WithMany("UserLeagueTeamTournaments")
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
                        .WithMany("TournamentPlayers")
                        .HasForeignKey("PlayerForeignKey");

                    b.HasOne("FantasyFairway.Models.Tournament", "Tournament")
                        .WithMany("TournamentPlayers")
                        .HasForeignKey("TournamentForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
