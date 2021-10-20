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
    public class LayoutController : Controller
    {
        private IBL _bl;
        public LayoutController(IBL bl)
        {
            _bl = bl;
        }

        /// <summary>
        /// Gets all the layouts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Layout> allLayouts = await _bl.GetAllLayoutsAsync();
            if (allLayouts != null)
            {
                return Ok(allLayouts);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// for Login and Layout Page
        /// get by api/Layout/<id>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Layout foundLayout = await _bl.GetLayoutByIdAsync(id);
            if (foundLayout != null)
            {
                return Ok(foundLayout);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Adds a new Layout to the database. 
        /// </summary>
        /// <param name="newLayout"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Layout newLayout)
        {
            Layout addedLayout = (Layout) await _bl.AddObjectAsync(newLayout);
            return Created("api/[controller]", addedLayout);
        }

        /// <summary>
        /// Updates a Layout in the database
        /// </summary>
        /// <param name="updateLayout"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Layout updateLayout)
        {
            await _bl.UpdateObjectAsync(updateLayout);
            return Ok(updateLayout);
        }

        /// <summary>
        /// Deletes a Layout from the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task Delete(int id)
        {
            Layout deleteLayout = (Layout) await _bl.GetLayoutByIdAsync(id);
            await _bl.DeleteObjectAsync(deleteLayout);
        }
    }
}
