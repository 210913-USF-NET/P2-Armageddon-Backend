using System;
using System.Collections.Generic;

namespace Models
{
    public class Layout
    {
        public Layout() {}
        public int Id {get; set;}
        public int PlayerId {get; set;}
        public int MatchId {get; set;}
        public string shipType {get; set;}
        public int startLocation {get; set;}
        public string direction {get; set;}

    }
}
