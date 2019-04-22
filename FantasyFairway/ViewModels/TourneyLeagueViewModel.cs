using FantasyFairway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyFairway.ViewModels
{
    public class TourneyLeagueViewModel
    {
        public int leagueID { get; set; }
        public string leagueName {get;set;}
        public List<TourneyTeamViewModel> teams { get; set; }
    }
}
