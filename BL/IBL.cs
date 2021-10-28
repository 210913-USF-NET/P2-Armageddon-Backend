using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BattleshipBL
{
    public interface IBL
    {
        /// <summary>
        /// Generic method to add an corresponding Object to the database
        /// </summary>
        /// <param name="objectToAdd"></param>
        /// <returns>corresponding object from the DB</returns>
      
        Task<User> AddObjectAsync(User objectToAdd);
      
        Task<Object> AddObjectAsync(Object objectToAdd);
      
        Task UpdateObjectAsync(Object objectToUpdate);

        Task DeleteObjectAsync(Object objectToDelete);

        Task<User> GetOneUserByIdAsync(int userId);

        Task<Match> GetOneMatchByIdAsync(int matchId);

        Task<List<Turn>> GetTurnsByIdAsync(int turnId);
        Task<List<Turn>> GetAllTurnsAsync();
        Task<ChatHistory> GetChatHistoryByIdAsync(int chatHistoryId);
        Task<List<Friends>> GetFriendsBySelfIdAsync(int selfId);
        Task<Friends> GetFriendsByIdAsync(int friendsId);

        Task<Layout> GetLayoutByIdAsync(int layoutId);

        Task<List<User>> GetAllUsersAsync();

        Task<List<Match>> GetAllMatchesAsync();


        Task<List<ChatHistory>> GetAllChatHistoriesAsync();

        Task<List<Layout>> GetAllLayoutsAsync();
        Task<List<Friends>> GetAllFriendsAsync();

        Task<List<User>> GetUsersByNameAsync(string entry);

        Task<User> GetOneUserByUsernameAsync(string username);
    }
}
