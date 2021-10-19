namespace Models
{
    public class Match
    {
        public Match() { }
        public Match(int id, int hostId, int turnCount, int winnerId, int opponentId)
        {
            this.Id = id;
            this.HostId = hostId;
            this.TurnCount = turnCount;
            this.WinnerId = winnerId;
            this.OpponentId = opponentId;

        }
        public int Id { get; set; }
        public int HostId { get; set; }
        public int TurnCount { get; set; }
        public int WinnerId { get; set; }
        public int OpponentId { get; set; }


    }
}