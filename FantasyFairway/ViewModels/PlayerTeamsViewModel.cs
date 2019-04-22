using FantasyFairway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyFairway.ViewModels
{
    public class PlayerTeamsViewModel
    {
        public List<Player> players { get; set; }
        public int teamID { get; set; }
        public string teamName { get; set; }
        public string leagueName { get; set; }
        public string userName { get; set; }
        public int scoreSoFar { get; set; }
    }
}
