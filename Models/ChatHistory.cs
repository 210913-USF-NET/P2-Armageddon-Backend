using System;
using System.Collections.Generic;

namespace Models
{
    public class ChatHistory
    {
        public ChatHistory() { }
        public ChatHistory(int id, int userId, string message, DateTime time)
        {
            this.Id = id;
            this.UserId = userId;
            this.Message = message;
            this.Time = time;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }

        public DateTime Time { get; set; }
    }
}