using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFairway.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace FantasyFairway.Models
{
    public class League
    {
        [Key]
        public int LeagueId { get; set; }

        [Required]
        public string LeagueName { get; set; }
        public bool Active {get; set;}
        public string Picture { get; set; }
        public int userCount { get; set; }
    }
}