using System;
using System.Collections.Generic;

namespace Models
{
    public class User
    {
        User() {}
        public int Id {get; set;}
        public string Username {get; set;}
        public string Email {get; set;}
        public int winStreak {get; set;}
        public int shotStreak {get; set;}
        public int totalWins {get; set;}
        public int totalMatches {get; set;}

    }
}
