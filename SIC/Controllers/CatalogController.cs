using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIC.Controllers
{
    [Route("api/Catalog")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly SICContext _context;

        public CatalogController(SICContext context)
        {
            _context = context;
        }

        // GET: api/Catalog
        [HttpGet]
        public IEnumerable<Catalog> GetCatalog()
        {
            return _context.Catalog;
        }

        // GET: api/Catalog/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatalog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var catalog = await _context.Catalog.FindAsync(id);

            if (catalog == null)
            {
                return NotFound();
            }

            return Ok(catalog);
        }

        // PUT: api/Catalog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalog([FromRoute] int id, [FromBody] Catalog catalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catalog.CatalogId)
            {
                return BadRequest();
            }

            _context.Entry(catalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogExists(id))
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

        // POST: api/Catalog
        [HttpPost]
        public async Task<IActionResult> PostCatalog([FromBody] Catalog catalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Catalog.Add(catalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalog", new { id = catalog.CatalogId }, catalog);
        }

        // DELETE: api/Catalog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var catalog = await _context.Catalog.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }

            _context.Catalog.Remove(catalog);
            await _context.SaveChangesAsync();

            return Ok(catalog);
        }

        private bool CatalogExists(int id)
        {
            return _context.Catalog.Any(e => e.CatalogId == id);
        }
    }
}