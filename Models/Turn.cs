namespace Models
{
    public class Turn
    {
        Turn() {}
        public int Id {get; set;}
        public int playerId {get; set;}
        public int targetId {get; set;}
        public int matchId {get; set;}
        public List<int> shotLocation {get; set;}
        public int turnNumber {get; set;}
    }
}