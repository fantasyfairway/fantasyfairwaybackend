using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFairway.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FantasyFairway.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        [Required]
        public string PlayerName { get; set; }
        public int RoundOne { get; set; }
        public int RoundTwo { get; set; }
        public int RoundThree { get; set; }
        public int RoundFour { get; set; }
        public int TournamentTotal {get; set;}
        public int Value { get; set; }
        [Required]
        public int Rank { get; set; }                 //global rank(poistion) for golfer 
    }
}