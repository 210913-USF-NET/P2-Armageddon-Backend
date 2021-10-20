﻿using System;
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
    }
}