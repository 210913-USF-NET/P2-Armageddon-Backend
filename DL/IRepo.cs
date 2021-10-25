using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface IRepo
    {
        Task<User> AddObjectAsync(User objectToAdd);

        Task<Object> AddObjectAsync(Object objectToAdd);
        Task UpdateObjectAsync(Object objectToUpdate);

        Task DeleteObjectAsync(Object objectToDelete);

        Task<User> GetOneUserByIdAsync(int userId);

        Task<Match> GetOneMatchByIdAsync(int matchId);

        Task<Turn> GetOneTurnByIdAsync(int turnId);
        Task<ChatHistory> GetChatHistoryByIdAsync(int chatHistoryId);

        Task<Friends> GetFriendsByIdAsync(int friendsId);

        Task<Layout> GetLayoutByIdAsync(int layoutId);

        Task<List<User>> GetAllUsersAsync();

        Task<List<Match>> GetAllMatchesAsync();

        Task<List<Turn>> GetAllTurnsAsync();

        Task<List<ChatHistory>> GetAllChatHistoriesAsync();

        Task<List<Layout>> GetAllLayoutsAsync();

        Task<List<Friends>> GetAllFriendsAsync();

        Task<List<User>> GetUsersByNameAsync(string entry);

        Task<User> GetOneUserByUsernameAsync(string username);
    }
}
