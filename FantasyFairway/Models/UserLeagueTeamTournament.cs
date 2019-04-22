using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFairway.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyFairway.Models
{
    public class UserLeagueTeamTournament
    {
        [Key]
        public int UserLeagueTeamTournamentID { get; set; }
        public int TeamForeignKey { get; set; }
        public int TournamentForeignKey { get; set; }
        public int UserLeagueForeignKey { get; set; }
        public int TournamentScore {get;set;}

        [ForeignKey("TeamForeignKey")]
        public Team Team { get; set; }//reference navigation property of the Team type and the Team entity class 
        [ForeignKey("TournamentForeignKey")]
        public Tournament Tournament { get; set; }//reference navigation property of the Tournament type and the Tournament entity class 
        [ForeignKey("UserLeagueForeignKey")]
        public UserLeague UserLeague { get; set; }//reference navigation property of the UserLeague type and the UserLeague entity class 

    }
}