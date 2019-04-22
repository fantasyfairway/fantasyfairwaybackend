using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyFairway.Models
{
    public class PlayerTeam
    {
        public int PlayerTeamID { get; set; }

        public int TeamForeignKey { get; set; }
        public int PlayerForeignKey { get; set; }


        [ForeignKey("TeamForeignKey")]
        public Team Team { get; set; } //reference navigation property of the Player type and the Player entity class 
        [ForeignKey("PlayerForeignKey")]
        public Player Player { get; set; } //reference navigation property of the Player type and the Player entity class 
    }
}
