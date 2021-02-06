using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIC.DTOs;
using SIC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIC.Controllers
{
    [Route("api/Restriction")]
    [ApiController]
    public class RestrictionController : ControllerBase
    {
        private readonly SICContext _context;

        public RestrictionController(SICContext context)
        {
            _context = context;
        }

        // GET: api/Restriction
        [HttpGet]
        public IEnumerable<Restriction> GetRestriction()
        {
            return _context.Restriction;
        }

        // GET: api/Restriction/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestriction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restriction = await _context.Restriction.FindAsync(id);

            if (restriction == null)
            {
                return NotFound();
            }

            if (restriction is RestrictionSizes)
            {
                RestrictionSizes rSizes = (RestrictionSizes)restriction;
                RestrictionSizesDto sizesDto = new RestrictionSizesDto();

                sizesDto.aggregation = new AggregationDto(rSizes.aggregation);
                sizesDto.restrictionId = rSizes.RestrictionId;

                sizesDto.x = rSizes.x;
                sizesDto.y = rSizes.y;
                sizesDto.z = rSizes.z;

                return Ok(sizesDto);
            }

            if (restriction is RestrictionMat)
            {
                RestrictionMat rMat = (RestrictionMat)restriction;
                RestrictionMatDto matDto = new RestrictionMatDto();

                matDto.aggregation = new AggregationDto(rMat.aggregation);
                matDto.restrictionId = rMat.RestrictionId;
                matDto.containingMaterial = rMat.containingMaterial;
                matDto.containedMaterial = rMat.containedMaterial;

                return Ok(matDto);
            }

            return Ok(restriction);
        }

        // PUT: api/Restriction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestriction([FromRoute] int id, [FromBody] Restriction restriction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restriction.RestrictionId)
            {
                return BadRequest();
            }

            _context.Entry(restriction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestrictionExists(id))
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

        // POST: api/Restriction/Sizes
        [HttpPost("Sizes")]
        public async Task<IActionResult> PostRestrictionSizes([FromBody] RestrictionSizesDto restrictionSizesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Aggregation aggregation = await _context.Aggregation.SingleOrDefaultAsync(a => a.containedProduct.name == restrictionSizesDto.aggregation.containedProduct && a.containingProduct.name == restrictionSizesDto.aggregation.containingProduct);

            if (aggregation == null)
            {
                return BadRequest("There is no such aggregation");
            }

            RestrictionSizes restSizes = new RestrictionSizes();

            restSizes.aggregation = (Aggregation)aggregation;

            if (!restSizes.algorithm(restrictionSizesDto.x, restrictionSizesDto.y, restrictionSizesDto.z))
            {
                // restSizes.x = restrictionSizesDto.x;
                // restSizes.y = restrictionSizesDto.y;
                // restSizes.z = restrictionSizesDto.z;

                _context.Restriction.Add(restSizes);
                await _context.SaveChangesAsync();

                restrictionSizesDto.restrictionId = restSizes.RestrictionId;
                return CreatedAtAction("GetRestriction", restrictionSizesDto);
            }
            else
            {
                return BadRequest("error incompatable values");
            }
        }

        // POST: api/Restriction/Materials
        [HttpPost("Materials")]
        public async Task<IActionResult> PostRestrictionMat([FromBody] RestrictionMatDto restrictionMatDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Aggregation aggregation = await _context.Aggregation.SingleOrDefaultAsync(a => a.containedProduct.name == restrictionMatDto.aggregation.containedProduct && a.containingProduct.name == restrictionMatDto.aggregation.containingProduct);

            if (aggregation == null)
            {
                return BadRequest("There is no such aggregation");
            }

            int containedMaterialId = restrictionMatDto.containedMaterial;
            int containingMaterialId = restrictionMatDto.containingMaterial;

            RestrictionMat restMat = new RestrictionMat();

            restMat.aggregation = (Aggregation)aggregation;

            if (!restMat.algorithm(containingMaterialId, containedMaterialId))
            {
                return BadRequest("Error, material incopatability");
            }
            else
            {
                //  restMat.containingMaterial = containingMaterialId;
                //restMat.containedMaterial = containedMaterialId;

                _context.Restriction.Add(restMat);
                await _context.SaveChangesAsync();

                restrictionMatDto.restrictionId = restMat.RestrictionId;
                return CreatedAtAction("GetRestriction", restrictionMatDto);
            }
        }

        // DELETE: api/Restriction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestriction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restriction = await _context.Restriction.FindAsync(id);
            if (restriction == null)
            {
                return NotFound();
            }

            _context.Restriction.Remove(restriction);
            await _context.SaveChangesAsync();

            return Ok(restriction);
        }

        private bool RestrictionExists(int id)
        {
            return _context.Restriction.Any(e => e.RestrictionId == id);
        }
    }
}