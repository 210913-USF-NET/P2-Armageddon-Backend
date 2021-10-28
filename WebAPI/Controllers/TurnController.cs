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
    public class TurnController : Controller
    {
        private IBL _bl;
        public TurnController(IBL bl)
        {
            _bl = bl;
        }

        /// <summary>
        /// Gets all the turns
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Turn> allTurns = await _bl.GetAllTurnsAsync();
            if (allTurns != null)
            {
                return Ok(allTurns);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// for Login and Turn Page
        /// get by api/Turn/<id>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            List<Turn> foundTurns = await _bl.GetTurnsByIdAsync(id);
            foundTurns.OrderBy(x => x.turnNumber);
            if (foundTurns != null && foundTurns.Count > 0)
            {
                return Ok(foundTurns);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Adds a new Turn to the database. 
        /// </summary>
        /// <param name="newTurn"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Turn newTurn)
        {
            Turn addedTurn = (Turn) await _bl.AddObjectAsync(newTurn);
            return Created("api/[controller]", addedTurn);
        }

        /// <summary>
        /// Updates a Turn in the database
        /// </summary>
        /// <param name="updateTurn"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Turn updateTurn)
        {
            await _bl.UpdateObjectAsync(updateTurn);
            return Ok(updateTurn);
        }

        /// <summary>
        /// Deletes a Turn from the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task Delete(int id)
        {
            Turn deleteTurn = (Turn) await _bl.GetOneTurnByIdAsync(id);
            await _bl.DeleteObjectAsync(deleteTurn);
        }
    }
}
