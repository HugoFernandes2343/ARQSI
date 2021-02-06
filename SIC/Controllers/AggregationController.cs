using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIC.DTOs;
using SIC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregationController : ControllerBase
    {
        private readonly SICContext _context;

        public AggregationController(SICContext context)
        {
            _context = context;
        }

        // GET: api/Aggregation
        [HttpGet]
        public IEnumerable<AggregationDto> GetAggregation()
        {
            List<AggregationDto> AggregationDtos = new List<AggregationDto>();
            foreach (Aggregation aggregation in _context.Aggregation)
            {
                AggregationDtos.Add(new AggregationDto(aggregation));
            }
            return AggregationDtos;
        }

        // GET: api/Aggregation/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAggregation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aggregation = await _context.Aggregation.FindAsync(id);

            if (aggregation == null)
            {
                return NotFound();
            }

            return Ok(new AggregationDto(aggregation));
        }

        // POST: api/Aggregation
        [HttpPost]
        public async Task<IActionResult> PostAggregation([FromBody] AggregationDto aggregationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var containingProduct = await _context.Product.SingleOrDefaultAsync(p => p.name == aggregationDto.containingProduct);
            var containedProduct = await _context.Product.SingleOrDefaultAsync(p => p.name == aggregationDto.containedProduct);

            if (containedProduct == null || containingProduct == null)
            {
                return BadRequest("One doesnt exist");
            }

            if (_context.Aggregation.Any(c => c.containedProduct.name == aggregationDto.containedProduct && c.containingProduct.name == aggregationDto.containingProduct))
            {
                return BadRequest("Aggregation already exists");
            }

            Aggregation aggregation;

            try
            {
                aggregation = new Aggregation(containingProduct, containedProduct);
            }
            catch (Exception)
            {
                return BadRequest("The products cant be aggregated");
            }

            _context.Aggregation.Add(aggregation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAggregation", new { id = aggregation.AggregationId }, new AggregationDto(aggregation));
        }

        // DELETE: api/Aggregation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAggregation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aggregation = await _context.Aggregation.FindAsync(id);
            if (aggregation == null)
            {
                return NotFound();
            }

            _context.Aggregation.Remove(aggregation);
            await _context.SaveChangesAsync();

            return Ok(aggregation);
        }

        private bool AggregationExists(int id)
        {
            return _context.Aggregation.Any(e => e.AggregationId == id);
        }
    }
}