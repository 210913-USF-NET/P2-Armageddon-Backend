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
    public class UserController : Controller
    {
        private IBL _bl;
        public UserController(IBL bl)
        {
            _bl = bl;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<User> allUsers = await _bl.GetAllUsersAsync();
            if (allUsers != null)
            {
                return Ok(allUsers);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// for Login and User Page
        /// get by api/user/<id>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User foundUser = await _bl.GetOneUserByIdAsync(id);
            if (foundUser != null)
            {
                return Ok(foundUser);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult> Get(string username)
        {
            User foundUser = await _bl.GetOneUserByUsernameAsync(username);
            if (foundUser != null)
            {
                return Ok(foundUser);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Adds a new user to the database. 
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User newUser)
        {
            User addedUser = (User) await _bl.AddObjectAsync(newUser);
            return Created("api/[controller]", addedUser);
        }

        /// <summary>
        /// Updates a user in the database
        /// </summary>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] User updateUser)
        {
            await _bl.UpdateObjectAsync(updateUser);
            return Ok(updateUser);
        }

        /// <summary>
        /// Deletes a user from the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task Delete(int id)
        {
            User deleteUser = (User) await _bl.GetOneUserByIdAsync(id);
            await _bl.DeleteObjectAsync(deleteUser);
        }
    }
}
