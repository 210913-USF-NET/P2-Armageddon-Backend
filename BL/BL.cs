using System;
using DL;
using Models;

namespace BattleshipBL
{
    public class BL : IBL
    {
        private IRepo _repo;

        public BL(IRepo repo)
        {
            _repo = repo;
        }
    }
}
