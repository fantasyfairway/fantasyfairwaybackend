using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFairway.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class TournamentPlayer
    {
        [Key]
        public int TournamentPlayerID { get; set; }
        [Required]
        public int Rank { get; set; }                 //global rank(poistion) for golfer 
        [Required]  
        public double MoneyValue { get; set; }        //price of golfer based off rank (1-10: $500, 2-20: $200, 20+: 100)
        [Required] 
        public string Status { get; set; }            //active or inactive
        public int ParValue { get; set; }             //number of shots above or below par 
        public int RoundOne { get; set; }
        public int RoundTwo { get; set; }
        public int RoundThree { get; set; }
        public int RoundFour { get; set; }
        public int TournamentTotal { get; set; }      //sum of scores from rounds 1-4 

        public int TournamentForeignKey { get; set; } //reference navigation property of the tournament type and the Tournament entity class 
        public int PlayerForeingKey { get; set; }

        [ForeignKey("TournamentForeignKey")]
        public Tournament Tournament { get; set; }
        [ForeignKey("PlayerForeignKey")]
        public Player Player { get; set; }//reference navigation property of the Player type and the Player entity class 
    }
