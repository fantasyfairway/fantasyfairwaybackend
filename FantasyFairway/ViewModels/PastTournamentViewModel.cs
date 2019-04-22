using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyFairway.ViewModels
{
    public class PastTournamentViewModel
    {
        public int tournamentID { get; set; }
        public string tournamentName { get; set; }
        public List<TourneyLeagueViewModel> leagues { get; set; }
    }
}
