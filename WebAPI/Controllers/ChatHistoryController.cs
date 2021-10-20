using Microsoft.AspNetCore.Mvc;
using Models;
using BattleshipBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatHistoryController : Controller
    {
        private IBL _bl;
        public ChatHistoryController(IBL bl)
        {
            _bl = bl;
        }

        /// <summary>
        /// Gets all the chat histories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ChatHistory> allChatHistories = await _bl.GetAllChatHistoriesAsync();
            if (allChatHistories != null)
            {
                return Ok(allChatHistories);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// for Login and ChatHistory Page
        /// get by api/ChatHistory/<id>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ChatHistory foundChatHistory = await _bl.GetChatHistoryByIdAsync(id);
            if (foundChatHistory != null)
            {
                return Ok(foundChatHistory);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Adds a new ChatHistory to the database. 
        /// </summary>
        /// <param name="newChatHistory"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChatHistory newChatHistory)
        {
            ChatHistory addedChatHistory = (ChatHistory) await _bl.AddObjectAsync(newChatHistory);
            return Created("api/[controller]", addedChatHistory);
        }

        /// <summary>
        /// Updates a ChatHistory in the database
        /// </summary>
        /// <param name="updateChatHistory"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ChatHistory updateChatHistory)
        {
            await _bl.UpdateObjectAsync(updateChatHistory);
            return Ok(updateChatHistory);
        }

        /// <summary>
        /// Deletes a ChatHistory from the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task Delete(int id)
        {
            ChatHistory deleteChatHistory = (ChatHistory) await _bl.GetChatHistoryByIdAsync(id);
            await _bl.DeleteObjectAsync(deleteChatHistory);
        }
    }
}
