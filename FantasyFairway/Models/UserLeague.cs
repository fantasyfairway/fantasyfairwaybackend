using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFairway.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyFairway.Models
{
    public class UserLeague
    {
        [Key]
        public int UserLeagueID { get; set; }

        public int AppUserForeignKey { get; set; }
        public int LeagueForeignKey { get; set; }
        public int TeamForeignKey {get; set;}

        [ForeignKey("AppUserForeignKey")]
        public AppUser AppUser { get; set; }
        [ForeignKey("LeagueForeignKey")]
        public League League { get; set; }
        [ForeignKey("TeamForeignKey")]
        public Team Team { get; set; }

    }
}