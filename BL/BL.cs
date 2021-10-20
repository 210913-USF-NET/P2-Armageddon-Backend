using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<object> AddObjectAsync(object objectToAdd)
        {
            return await _repo.AddObjectAsync(objectToAdd);
        }

        public async Task DeleteObjectAsync(object objectToDelete)
        {
            await _repo.DeleteObjectAsync(objectToDelete);
        }

        public async Task<List<ChatHistory>> GetAllChatHistoriesAsync()
        {
            return await _repo.GetAllChatHistoriesAsync();
        }

        public async Task<List<Friends>> GetAllFriendsAsync()
        {
            return await _repo.GetAllFriendsAsync();
        }

        public async Task<List<Layout>> GetAllLayoutsAsync()
        {
            return await _repo.GetAllLayoutsAsync();
        }

        public async Task<List<Match>> GetAllMatchesAsync()
        {
            return await _repo.GetAllMatchesAsync();
        }

        public async Task<List<Turn>> GetAllTurnsAsync()
        {
            return await _repo.GetAllTurnsAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _repo.GetAllUsersAsync();
        }

        public async Task<ChatHistory> GetChatHistoryByIdAsync(int chatHistoryId)
        {
            return await _repo.GetChatHistoryByIdAsync(chatHistoryId);
        }

        public async Task<Friends> GetFriendsByIdAsync(int friendsId)
        {
            return await _repo.GetFriendsByIdAsync(friendsId);
        }

        public async Task<Layout> GetLayoutByIdAsync(int layoutId)
        {
            return await _repo.GetLayoutByIdAsync(layoutId);
        }

        public async Task<Match> GetOneMatchByIdAsync(int matchId)
        {
            return await _repo.GetOneMatchByIdAsync(matchId);
        }

        public async Task<Turn> GetOneTurnByIdAsync(int turnId)
        {
            return await _repo.GetOneTurnByIdAsync(turnId);
        }

        public async Task<User> GetOneUserByIdAsync(int userId)
        {
            return await _repo.GetOneUserByIdAsync(userId);
        }

        public async Task UpdateObjectAsync(object objectToUpdate)
        {
            await _repo.UpdateObjectAsync(objectToUpdate);
        }
    }
}
