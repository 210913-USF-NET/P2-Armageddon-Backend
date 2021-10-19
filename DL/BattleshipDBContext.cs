using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class BattleshipDBContext : DbContext
    {
        public BattleshipDBContext() : base() { }
        public BattleshipDBContext(DbContextOptions options) : base(options) { }

        public DbSet<ChatHistory> ChatHistory { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Layout> Layout { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<Turn> Turn { get; set; }
        public DbSet<User> User { get; set; }
    }
}
