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

        public async Task<List<ChatHistory>> GetAllChatHistoriesAsync()
        {
            return await _context.ChatHistory.Select(ch => ch).ToListAsync();
        }

        public async Task<List<Friends>> GetAllFriendsAsync()
        {
            return await _context.Friends.Select(f => f).ToListAsync();
        }

        public async Task<List<Layout>> GetAllLayoutsAsync()
        {
            return await _context.Layout.Select(l => l).ToListAsync();
        }

        public async Task<List<Match>> GetAllMatchesAsync()
        {
            return await _context.Match.Select(m => m).ToListAsync();
        }

        public async Task<List<Turn>> GetAllTurnsAsync()
        {
            return await _context.Turn.Select(t => t).ToListAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.User.Select(u => u).ToListAsync();
        }

        public async Task<ChatHistory> GetChatHistoryByIdAsync(int chatHistoryId)
        {
            return await _context.ChatHistory.AsNoTracking().FirstOrDefaultAsync(ch => ch.Id == chatHistoryId);
        }

        public async Task<Friends> GetFriendsByIdAsync(int friendsId)
        {
            return await _context.Friends.AsNoTracking().FirstOrDefaultAsync(f => f.Id == friendsId);
        }
        public async Task<List<Friends>> GetFriendsBySelfIdAsync(int selfId)
        {
            return await _context.Friends.Where(f => f.user1Id == selfId || f.user2Id==selfId).ToListAsync();
        }

        public async Task<Layout> GetLayoutByIdAsync(int layoutId)
        {
            return await _context.Layout.AsNoTracking().FirstOrDefaultAsync(l => l.Id == layoutId);
        }

        public async Task<Match> GetOneMatchByIdAsync(int matchId)
        {
            return await _context.Match.AsNoTracking().FirstOrDefaultAsync(m => m.Id == matchId);
        }

        public async Task<Turn> GetOneTurnByIdAsync(int turnId)
        {
            return await _context.Turn.AsNoTracking().FirstOrDefaultAsync(t => t.Id == turnId);
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
