using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        // Generic Methods
        public async Task<User> AddObjectAsync(User objectToAdd)
        {
            await _context.AddAsync(objectToAdd);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return objectToAdd;
        }
        public async Task<Object> AddObjectAsync(Object objectToAdd)
        {
            await _context.AddAsync(objectToAdd);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return objectToAdd;
        }
        public async Task UpdateObjectAsync(Object objectToUpdate)
        {
            _context.Update(objectToUpdate);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
        public async Task DeleteObjectAsync(Object objectToDelete)
        {
            _context.Remove(objectToDelete);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        // Chat History Methods
        public async Task<List<ChatHistory>> GetAllChatHistoriesAsync()
        {
            return await _context.ChatHistory.Select(ch => ch).ToListAsync();
        }
        public async Task<ChatHistory> GetChatHistoryByIdAsync(int chatHistoryId)
        {
            return await _context.ChatHistory.AsNoTracking().FirstOrDefaultAsync(ch => ch.Id == chatHistoryId);
        }

        // Friend Methods
        public async Task<List<Friends>> GetAllFriendsAsync()
        {
            return await _context.Friends.Select(f => f).ToListAsync();
        }
        public async Task<Friends> GetFriendsByIdAsync(int friendsId)
        {
            return await _context.Friends.AsNoTracking().FirstOrDefaultAsync(f => f.Id == friendsId);
        }
        public async Task<List<Friends>> GetFriendsBySelfIdAsync(int selfId)
        {
            return await _context.Friends.Where(f => f.user1Id == selfId || f.user2Id == selfId).ToListAsync();
        }

        // Layout Methods
        public async Task<List<Layout>> GetAllLayoutsAsync()
        {
            return await _context.Layout.Select(l => l).ToListAsync();
        }
        public async Task<Layout> GetLayoutByIdAsync(int matchId)
        {
            return await _context.Layout.AsNoTracking().FirstOrDefaultAsync(l => l.MatchId == matchId);
        }

        // Match Methods
        public async Task<List<Match>> GetAllMatchesAsync()
        {
            return await _context.Match.Select(m => m).ToListAsync();
        }
        public async Task<Match> GetOneMatchByIdAsync(int matchId)
        {
            return await _context.Match.AsNoTracking().FirstOrDefaultAsync(m => m.Id == matchId);
        }

        // Turn Methods
        public async Task<List<Turn>> GetAllTurnsAsync()
        {
            return await _context.Turn.Select(t => t).ToListAsync();
        }
        public async Task<Turn> GetOneTurnByIdAsync(int matchId)
        {
            return await _context.Turn.AsNoTracking().FirstOrDefaultAsync(t => t.matchId == matchId);
        }

        // User Methods
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.User.Select(u => u).ToListAsync();
        }
        public async Task<User> GetOneUserByIdAsync(int userId)
        {
            return await _context.User.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
        }
        public async Task<User> GetOneUserByUsernameAsync(string username)
        {
            return await _context.User.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<List<User>> GetUsersByNameAsync(string entry)
        {
            // [[TODO]] modify WHERE to be CONTAINS(entry) instead
            return await _context.User.Select(u => u).Where(u => u.Username == entry).ToListAsync();
        }

    }
}
