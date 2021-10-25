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
    public class FriendsController : Controller
    {
        private IBL _bl;
        public FriendsController(IBL bl)
        {
            _bl = bl;
        }

        /// <summary>
        /// Gets all the friends
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Friends> allFriends = await _bl.GetAllFriendsAsync();
            if (allFriends != null)
            {
                return Ok(allFriends);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// for Login and Friend Page
        /// get by api/Friend/<id>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            List<Friends> foundFriend = await _bl.GetFriendsBySelfIdAsync(id);
            if (foundFriend != null)
            {
                return Ok(foundFriend);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Adds a new Friend to the database. 
        /// </summary>
        /// <param name="newFriend"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Friends newFriend)
        {
            Friends addedFriend = (Friends) await _bl.AddObjectAsync(newFriend);
            return Created("api/[controller]", addedFriend);
        }

        /// <summary>
        /// Updates a Friend in the database
        /// </summary>
        /// <param name="updateFriend"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Friends updateFriend)
        {
            await _bl.UpdateObjectAsync(updateFriend);
            return Ok(updateFriend);
        }

        /// <summary>
        /// Deletes a Friend from the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task Delete(int id)
        {
            Friends deleteFriend = (Friends) await _bl.GetFriendsByIdAsync(id);
            await _bl.DeleteObjectAsync(deleteFriend);
        }
    }
}
