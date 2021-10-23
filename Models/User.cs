using System;
using System.Collections.Generic;

namespace Models
{
    public class User
    {
        public User() {}
        public User(string Username, string Email, int winStreak, int shotStreak, int totalWins, int totalMatches)
        {
            this.Username = Username;
            this.Email = Email;
            this.winStreak = winStreak;
            this.shotStreak = shotStreak;
            this.totalWins = totalWins;
            this.totalMatches = totalMatches;
        }
        public int Id {get; set;}
        public string Username {get; set;}
        public string Email {get; set;}
        public int winStreak {get; set;}
        public int shotStreak {get; set;}
        public int totalWins {get; set;}
        public int totalMatches {get; set;}

    }
}
