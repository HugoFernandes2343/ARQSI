using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIC.Controllers
{
    [Route("api/Finish")]
    [ApiController]
    public class FinishController : ControllerBase
    {
        private readonly SICContext _context;

        public FinishController(SICContext context)
        {
            _context = context;
        }

        // GET: api/Finish
        [HttpGet]
        public IEnumerable<Finish> GetFinish()
        {
            return _context.Finish;
        }

        // GET: api/Finish/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFinish([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var finish = await _context.Finish.FindAsync(id);

            if (finish == null)
            {
                return NotFound();
            }

            return Ok(finish);
        }

        // PUT: api/Finish/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinish([FromRoute] int id, [FromBody] Finish finish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != finish.FinishId)
            {
                return BadRequest();
            }

            _context.Entry(finish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishExists(id))
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

        // POST: api/Finish
        [HttpPost]
        public async Task<IActionResult> PostFinish([FromBody] Finish finish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Finish.Add(finish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinish", new { id = finish.FinishId }, finish);
        }

        // DELETE: api/Finish/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinish([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var finish = await _context.Finish.FindAsync(id);
            if (finish == null)
            {
                return NotFound();
            }

            _context.Finish.Remove(finish);
            await _context.SaveChangesAsync();

            return Ok(finish);
        }

        private bool FinishExists(int id)
        {
            return _context.Finish.Any(e => e.FinishId == id);
        }
    }
}