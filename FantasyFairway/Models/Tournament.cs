using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFairway.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FantasyFairway.Models
{
    public class Tournament
    {
        [Key]
        public int TournamentID { get; set; }
        [Required]
        public string TournamentName { get; set; }
        [Required]
        public string TournamentDates { get; set; }

    }
}