using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyFairway.ViewModels
{
    public class PlayerTeamViewModel
    {
        public List<string> playerNames { get; set; }
        public int teamID { get; set; }
        public string tournamentName { get; set; }
    }
}
