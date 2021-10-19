using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public class DBRepo : IRepo
    {
        private BattleshipDBContext _context;
        public DBRepo(BattleshipDBContext context)
        {
            _context = context;
        }
    }
}
