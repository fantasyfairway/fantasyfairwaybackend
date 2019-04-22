using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyFairway.ViewModels
{
    public class PlayerViewModel
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int RoundOne { get; set; }
        public int RoundTwo{get;set;}  
        public int RoundThree { get; set; }
        public int RoundFour { get; set; }
        public string PhoneNumber {get; set; }
        public int Value { get; set; }
        public int Rank { get; set; }    
    }
}
