using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIC.Controllers
{
    [Route("api/Dimensions")]
    [ApiController]
    public class DimensionsController : ControllerBase
    {
        private readonly SICContext _context;

        public DimensionsController(SICContext context)
        {
            _context = context;
        }

        // GET: api/Dimensions
        [HttpGet]
        public IEnumerable<Dimensions> GetDimensions()
        {
            return _context.Dimensions;
        }

        // GET: api/Dimensions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDimensions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dimensions = await _context.Dimensions.FindAsync(id);

            if (dimensions == null)
            {
                return NotFound();
            }

            return Ok(dimensions);
        }

        // PUT: api/Dimensions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDimensions([FromRoute] int id, [FromBody] Dimensions dimensions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dimensions.DimensionsId)
            {
                return BadRequest();
            }

            _context.Entry(dimensions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimensionsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dimensions
        [HttpPost]
        public async Task<IActionResult> PostDimensions([FromBody] Dimensions dimensions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dimensions.Add(dimensions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDimensions", new { id = dimensions.DimensionsId }, dimensions);
        }

        // DELETE: api/Dimensions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDimensions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dimensions = await _context.Dimensions.FindAsync(id);
            if (dimensions == null)
            {
                return NotFound();
            }

            _context.Dimensions.Remove(dimensions);
            await _context.SaveChangesAsync();

            return Ok(dimensions);
        }

        private bool DimensionsExists(int id)
        {
            return _context.Dimensions.Any(e => e.DimensionsId == id);
        }
    }
}