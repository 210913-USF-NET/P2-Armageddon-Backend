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
    public class MatchController : Controller
    {
        private IBL _bl;
        public MatchController(IBL bl)
        {
            _bl = bl;
        }

        /// <summary>
        /// Gets all the matches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Match> allMatches = await _bl.GetAllMatchesAsync();
            if (allMatches != null)
            {
                return Ok(allMatches);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// for Login and Match Page
        /// get by api/Match/<id>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            Match foundMatch = await _bl.GetOneMatchByIdAsync(id);
            if (foundMatch != null)
            {
                return Ok(foundMatch);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Adds a new Match to the database. 
        /// </summary>
        /// <param name="newMatch"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Match newMatch)
        {
            Match addedMatch = (Match) await _bl.AddObjectAsync(newMatch);
            return Created("api/[controller]", addedMatch);
        }

        /// <summary>
        /// Updates a Match in the database
        /// </summary>
        /// <param name="updateMatch"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Match updateMatch)
        {
            await _bl.UpdateObjectAsync(updateMatch);
            return Ok(updateMatch);
        }

        /// <summary>
        /// Deletes a Match from the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task Delete(int id)
        {
            Match deleteMatch = (Match) await _bl.GetOneMatchByIdAsync(id);
            await _bl.DeleteObjectAsync(deleteMatch);
        }
    }
}
