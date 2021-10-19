using System;

namespace Models
{
    public class ChatHistory
    {
        public ChatHistory() { }
        public ChatHistory(int id, int userId, int matchId, string message, DateTime time)
        {
            this.Id = id;
            this.UserId = userId;
            this.MatchId = matchId;
            this.Message = message;
            this.Time = time;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MatchId { get; set; }
        public string Message { get; set; }

        public DateTime Time { get; set; }
    }
}