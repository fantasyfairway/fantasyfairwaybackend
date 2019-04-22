using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FantasyFairway.Models;

namespace FantasyFairway.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {


        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<UserLeague> UserLeagues { get; set; }
        public DbSet<UserLeagueTeamTournament> UserLeagueTeamTournaments { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<TournamentPlayer> TournamentPlayer { get; set; }
        public DbSet<PlayerTeam> PlayerTeam { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Commissioner", NormalizedName = "Commissioner".ToUpper() });
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "User".ToUpper() });

    }
    }

    
}
